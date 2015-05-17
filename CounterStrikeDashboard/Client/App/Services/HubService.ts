module csdash {
    export class HubService {
        public static $inject = [];
        private _stateListeners: Array<StateListenerFunc>;
        private _mainHub;

        private fireStateChangedEvent = (state: HubStates) => {
            this._stateListeners.forEach(x => x(state));
        }

        constructor() {
            this._stateListeners = [];

            this._mainHub = $.connection.hub;
            this._mainHub.error((error: any) => {
                console.log("MainHub error: " + error);
                this.fireStateChangedEvent(HubStates.Disconnected)
            });

            this._mainHub.stateChanged((change) => {
                if (change.newState === $.signalR.connectionState.reconnecting) {
                    console.log("MainHub reconnecting");
                    this.fireStateChangedEvent(HubStates.Reconnecting);
                }
                else if (change.newState === $.signalR.connectionState.connected) {
                    console.log("MainHub connected");
                    this.fireStateChangedEvent(HubStates.Connected);
                }
            });
        }

        addStateListener = (listener: StateListenerFunc) => {
            this._stateListeners.push(listener);
        }

        start = () => {
            this._mainHub.start();
        }
    }

    export enum HubStates { Connected, Connecting, Disconnected, Reconnecting }

    export interface StateListenerFunc {
        (state: HubStates): void;
    }
}