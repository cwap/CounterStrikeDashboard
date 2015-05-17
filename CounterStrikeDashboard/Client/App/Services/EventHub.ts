module csdash {
    'use strict';

    export class EventHub extends HubBase {

        private _newEventListeners: Array<NewEventListenerFunc>;

        constructor() {
            super("eventHub");

            this._newEventListeners = [];

            this.hub.client.lol = (msg) => {
                for (var i = 0; i < this._newEventListeners.length; i++) {
                    this._newEventListeners[i](msg);
                }
            };
        }

        addNewEventListener(listener: NewEventListenerFunc) {
            this._newEventListeners.push(listener);
        }
    }

    export interface NewEventListenerFunc {
        (event: string): void;
    }
}