var csdash;
(function (csdash) {
    'use strict';

    var HubBase = (function () {
        function HubBase() {
            _self = this;
            this._hub = $.connection.hub;
            this._messageListeners = [];
            this._stateListeners = [];

            var hub = $.connection.hub;
            hub.error(function (error) {
                this.fireStateChangedEvent(2 /* Disconnected */);
            });

            hub.stateChanged(function (change) {
                if (change.newState === $.signalR.connectionState.reconnecting) {
                    _self.fireStateChangedEvent(3 /* Reconnecting */);
                } else if (change.newState === $.signalR.connectionState.connected) {
                    _self.fireStateChangedEvent(0 /* Connected */);
                }
            });

            hub.start();
        }
        HubBase.prototype.fireStateChangedEvent = function (state) {
            this._stateListeners.forEach(function (x) {
                return x(state);
            });
        };

        HubBase.prototype.addStateListener = function (listener) {
            this._stateListeners.push(listener);
        };
        return HubBase;
    })();
    csdash.HubBase = HubBase;

    (function (HubStates) {
        HubStates[HubStates["Connected"] = 0] = "Connected";
        HubStates[HubStates["Connecting"] = 1] = "Connecting";
        HubStates[HubStates["Disconnected"] = 2] = "Disconnected";
        HubStates[HubStates["Reconnecting"] = 3] = "Reconnecting";
    })(csdash.HubStates || (csdash.HubStates = {}));
    var HubStates = csdash.HubStates;
})(csdash || (csdash = {}));
