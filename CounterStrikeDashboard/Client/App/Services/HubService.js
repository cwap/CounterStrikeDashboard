var csdash;
(function (csdash) {
    var HubService = (function () {
        function HubService() {
            var _this = this;
            this.fireStateChangedEvent = function (state) {
                _this._stateListeners.forEach(function (x) {
                    return x(state);
                });
            };
            this.addStateListener = function (listener) {
                _this._stateListeners.push(listener);
            };
            this.start = function () {
                _this._mainHub.start();
            };
            this._stateListeners = [];

            this._mainHub = $.connection.hub;
            this._mainHub.error(function (error) {
                console.log("MainHub error: " + error);
                _this.fireStateChangedEvent(2 /* Disconnected */);
            });

            this._mainHub.stateChanged(function (change) {
                if (change.newState === $.signalR.connectionState.reconnecting) {
                    console.log("MainHub reconnecting");
                    _this.fireStateChangedEvent(3 /* Reconnecting */);
                } else if (change.newState === $.signalR.connectionState.connected) {
                    console.log("MainHub connected");
                    _this.fireStateChangedEvent(0 /* Connected */);
                }
            });
        }
        HubService.$inject = [];
        return HubService;
    })();
    csdash.HubService = HubService;

    (function (HubStates) {
        HubStates[HubStates["Connected"] = 0] = "Connected";
        HubStates[HubStates["Connecting"] = 1] = "Connecting";
        HubStates[HubStates["Disconnected"] = 2] = "Disconnected";
        HubStates[HubStates["Reconnecting"] = 3] = "Reconnecting";
    })(csdash.HubStates || (csdash.HubStates = {}));
    var HubStates = csdash.HubStates;
})(csdash || (csdash = {}));
