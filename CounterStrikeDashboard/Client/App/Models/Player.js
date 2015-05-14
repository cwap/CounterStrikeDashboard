var csdash;
(function (csdash) {
    'use strict';

    var Player = (function () {
        function Player() {
        }
        Object.defineProperty(Player.prototype, "name", {
            get: function () {
                return this._name;
            },
            set: function (name) {
                this._name = name;
            },
            enumerable: true,
            configurable: true
        });


        Object.defineProperty(Player.prototype, "kills", {
            get: function () {
                return this._kills;
            },
            set: function (kills) {
                this._kills = kills;
            },
            enumerable: true,
            configurable: true
        });


        Object.defineProperty(Player.prototype, "deaths", {
            get: function () {
                return this._deaths;
            },
            set: function (deaths) {
                this._deaths = deaths;
            },
            enumerable: true,
            configurable: true
        });


        Object.defineProperty(Player.prototype, "ping", {
            get: function () {
                return this._ping;
            },
            set: function (ping) {
                this._ping = ping;
            },
            enumerable: true,
            configurable: true
        });


        Object.defineProperty(Player.prototype, "ip", {
            get: function () {
                return this._ip;
            },
            set: function (ip) {
                this._ip = ip;
            },
            enumerable: true,
            configurable: true
        });

        return Player;
    })();
    csdash.Player = Player;
})(csdash || (csdash = {}));
