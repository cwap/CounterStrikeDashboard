var csdash;
(function (csdash) {
    var Scoreboard = (function () {
        function Scoreboard() {
            var _this = this;
            this.mapScoreboards = [];
            this.startNewMap = function (map) {
                _this.currentMapScoreboard = new csdash.MapScoreboard();
                _this.currentMapScoreboard.map = map;
                _this.mapScoreboards.splice(0, 0, _this.currentMapScoreboard);
            };
            this.roundWon = function (winner) {
                if (winner === 'T')
                    _this.currentMapScoreboard.tScore++;
                else if (winner === 'CT')
                    _this.currentMapScoreboard.ctScore++;
                else
                    console.log('Got round won, but could not parse winner: ' + winner);
            };
            this.changePlayerTeam = function (uid, team) {
            };
        }
        Scoreboard.prototype.findMapScoreRow = function (uid) {
            //for (number i = 0; i <
        };
        return Scoreboard;
    })();
    csdash.Scoreboard = Scoreboard;
})(csdash || (csdash = {}));
