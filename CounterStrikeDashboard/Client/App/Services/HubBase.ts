module csdash {
    'use strict';

    export class HubBase {
        public _hub: any;
        private _messageListeners: Array<MessageListenerFunc>;
        private _stateListeners: Array<StateListenerFunc>;
        private _self: HubBase;

        private fireStateChangedEvent(state: HubStates) {
            this._stateListeners.forEach(x => x(state));
        }

        addStateListener(listener: StateListenerFunc) {
            this._stateListeners.push(listener);
        }

        constructor() {
            _self = this;
            this._hub = $.connection.hub;
            this._messageListeners = [];
            this._stateListeners = [];

            var hub = $.connection.hub;
            hub.error(function (error) { /* TODO Add error */ this.fireStateChangedEvent(HubStates.Disconnected) });

            hub.stateChanged(function (change) {
                if (change.newState === $.signalR.connectionState.reconnecting) {
                    _self.fireStateChangedEvent(HubStates.Reconnecting);
                }
                else if (change.newState === $.signalR.connectionState.connected) {
                    _self.fireStateChangedEvent(HubStates.Connected);
                } 
            });

            hub.start();
        }
    }

    export enum HubStates { Connected, Connecting, Disconnected, Reconnecting }

    export interface MessageListenerFunc {
        (message: string): void;
    }

    export interface StateListenerFunc {
        (state: HubStates): void;
    }
}