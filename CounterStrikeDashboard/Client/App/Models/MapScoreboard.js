var csdash;
(function (csdash) {
    var MapScoreboard = (function () {
        function MapScoreboard() {
            this.tScore = 0;
            this.ctScore = 0;
        }
        return MapScoreboard;
    })();
    csdash.MapScoreboard = MapScoreboard;
})(csdash || (csdash = {}));
