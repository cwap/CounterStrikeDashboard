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
        function EventHub() {
            var _this = this;
            _super.call(this, "eventHub");
            this.getScoreboard = function () {
                return _this.scoreboard;
            };

            this.scoreboard = new csdash.Scoreboard();

            this.hub.client.controlReset = function () {
                console.log("control reset");
            };

            this.hub.client.roundEnded = function (evt) {
                var obj = csdash.Serializer.deserializeObj(evt);
                _this.scoreboard.roundWon(obj.team);
            };

            this.hub.client.newMapStarted = function (evt) {
                var obj = csdash.Serializer.deserializeObj(evt);
                _this.scoreboard.startNewMap(obj.map);
            };

            this.hub.client.joinedTeam = function (evt) {
                var obj = csdash.Serializer.deserializeObj(evt);
                _this.scoreboard.changePlayerTeam(obj.player.uid, obj.team);
            };

            this.hub.client.playerAdded = function (evt) {
                var obj = csdash.Serializer.deserializeObj(evt);
                _this.scoreboard.playerAdded(obj.player.uid, obj.player.playerName, obj.player.team);
            };

            this.hub.client.playerKilled = function (evt) {
                console.log("someone died");
                var obj = csdash.Serializer.deserializeObj(evt);
            };
        }
        EventHub.$inject = [];
        return EventHub;
    })(csdash.HubBase);
    csdash.EventHub = EventHub;
})(csdash || (csdash = {}));
