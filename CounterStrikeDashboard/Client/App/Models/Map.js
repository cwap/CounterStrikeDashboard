var csdash;
(function (csdash) {
    var Map = (function () {
        function Map() {
            this.__name__ = "Map";
            this.start = new Date();
            this.mapName = "";
            this.players = [];
            this.teams = [];
            this.active = false;
        }
        return Map;
    })();
    csdash.Map = Map;
})(csdash || (csdash = {}));
