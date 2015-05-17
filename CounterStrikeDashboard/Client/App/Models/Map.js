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
            this.teams = new Array();
            var ct = new csdash.TeamTuple();
            ct.team = "CT";
            this.teams.push(ct);
            var t = new csdash.TeamTuple();
            t.team = "T";
            this.teams.push(t);
        }
        return Map;
    })();
    csdash.Map = Map;
})(csdash || (csdash = {}));
