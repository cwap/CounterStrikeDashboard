var csdash;
(function (csdash) {
    var KillEvent = (function () {
        function KillEvent() {
            this.__name__ = "KillEvent";
            this.start = new Date();
            this.mapName = "";
            this.players = [];
            this.teams = [];
            this.active = false;
        }
        return KillEvent;
    })();
    csdash.KillEvent = KillEvent;
})(csdash || (csdash = {}));
