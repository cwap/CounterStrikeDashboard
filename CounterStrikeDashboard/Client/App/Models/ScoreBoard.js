var csdash;
(function (csdash) {
    var Scoreboard = (function () {
        function Scoreboard() {
            var _this = this;
            this.mapScoreboards = [];
            this.startNewMap = function (map, time) {
                _this.currentMapScoreboard = new csdash.MapScoreboard();
                _this.currentMapScoreboard.map = map;
                _this.currentMapScoreboard.started = time;
                _this.mapScoreboards.splice(0, 0, _this.currentMapScoreboard);

                _this.notifyObservers();
            };
            this.roundWon = function (winner) {
                if (winner === 'T') {
                    _this.currentMapScoreboard.tScore++;
                } else if (winner === 'CT') {
                    _this.currentMapScoreboard.ctScore++;
                } else {
                    console.log('Got round won, but could not parse winner: ' + winner);
                }

                _this.currentMapScoreboard.rows.forEach(function (row) {
                    if (row.team == winner) {
                        row.points += 2;
                    }
                });

                _this.notifyObservers();
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
                _this.notifyObservers();
            };
            this.playerKilled = function (kUid, kTeam, dUid, dTeam, wpn) {
                var kRow = _this.findMapScoreRow(kUid);
                var dRow = _this.findMapScoreRow(dUid);

                if (kRow.team != dRow.team) {
                    kRow.kills += 1;
                    kRow.points += 1;
                } else {
                    kRow.teamkills += 1;
                    kRow.points -= 1;
                }

                dRow.deaths += 1;
                _this.notifyObservers();
            };
            this.onUpdateListeners = [];
        }
        Scoreboard.prototype.registerObserver = function (listener) {
            this.onUpdateListeners.push(listener);
        };

        Scoreboard.prototype.removeObserver = function (listener) {
            this.onUpdateListeners.splice(this.onUpdateListeners.indexOf(listener), 1);
        };

        Scoreboard.prototype.notifyObservers = function () {
            this.onUpdateListeners.forEach(function (observer) {
                observer.onScoreboardUpdated();
            });
        };

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

    ;

    ;
})(csdash || (csdash = {}));
