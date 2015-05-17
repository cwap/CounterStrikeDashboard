var __extends = this.__extends || function (d, b) {
    for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p];
    function __() { this.constructor = d; }
    __.prototype = b.prototype;
    d.prototype = new __();
};
var csdash;
(function (csdash) {
    'use strict';

    var EventHub = (function (_super) {
        __extends(EventHub, _super);
        function EventHub(scoreService) {
            var _this = this;
            _super.call(this, "eventHub");
            this.scoreService = scoreService;

            this._scoreService = scoreService;

            this.hub.client.controlReset = function () {
                _this._scoreService.reset();
            };

            this.hub.client.roundEnded = function (dt, winner) {
            };

            this.hub.client.newMapStarted = function (dt, map) {
            };

            this.hub.client.joinedTeam = function (dt, playerUid, playerName, team) {
            };

            this.hub.client.playerAdded = function (dt, playerUid, playerName) {
            };

            this.hub.client.playerKilled = function (dt, killerUid, killerName, deadUid, deadName) {
                console.log(killerName + " killed " + deadName);
            };
        }
        EventHub.$inject = ['scoreService'];
        return EventHub;
    })(csdash.HubBase);
    csdash.EventHub = EventHub;
})(csdash || (csdash = {}));
