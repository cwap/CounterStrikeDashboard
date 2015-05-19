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
                var row = _this.findMapScoreRow(uid);
                if (row == null) {
                    console.log('Could not find player that changed team. Uid: ' + uid);
                    return;
                }

                row.team = team;
            };
            this.playerAdded = function (uid, name, team) {
                var row = _this.findMapScoreRow(uid);
                if (row == null) {
                    row = new csdash.MapScoreRow();
                    row.placement = 0;
                    row.points = 0;
                    row.kills = 0;
                    row.deaths = 0;
                    row.teamkills = 0;
                    _this.currentMapScoreboard.rows.push(row);
                }
                ;

                row.playerName = name;
                row.team = team;
                row.playerUid = uid;
            };
        }
        Scoreboard.prototype.findMapScoreRow = function (uid) {
            for (var i = 0; i < this.currentMapScoreboard.rows.length; i++) {
                var row = this.currentMapScoreboard.rows[i];
                if (row.playerUid === uid) {
                    return row;
                }
            }

            return null;
        };
        return Scoreboard;
    })();
    csdash.Scoreboard = Scoreboard;
})(csdash || (csdash = {}));
