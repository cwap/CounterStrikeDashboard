var csdash;
(function (csdash) {
    var PlayerTuple = (function () {
        function PlayerTuple() {
            this.__name__ = "PlayerTuple";
            this.name = "Unknown";
            this.uniqueIdentifier = "";
            this.team = "none";
            this.kills = 0;
            this.deaths = 0;
            this.connected = false;
        }
        return PlayerTuple;
    })();
    csdash.PlayerTuple = PlayerTuple;
})(csdash || (csdash = {}));
