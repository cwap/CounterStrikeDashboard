module csdash {
    export class Scoreboard {
        currentMapScoreboard: MapScoreboard;
        mapScoreboards: Array<MapScoreboard> = [];
        onUpdateListeners: ScoreboardUpdatedListener[];

        constructor() {
            this.onUpdateListeners = [];
        }

        registerObserver(listener: ScoreboardUpdatedListener): void {
            this.onUpdateListeners.push(listener);
        }

        removeObserver(listener: ScoreboardUpdatedListener): void {
            this.onUpdateListeners.splice(this.onUpdateListeners.indexOf(listener), 1);
        }

        notifyObservers(): void {
            this.onUpdateListeners.forEach((observer: ScoreboardUpdatedListener) => {
                observer.onScoreboardUpdated();
            });
        }

        startNewMap = (map, time) => {
            this.currentMapScoreboard = new MapScoreboard();
            this.currentMapScoreboard.map = map;
            this.currentMapScoreboard.started = time;
            this.mapScoreboards.splice(0, 0, this.currentMapScoreboard);

            this.notifyObservers();
        }

        roundWon = (winner) => {
            if (winner === 'T') {
                this.currentMapScoreboard.tScore++;
            }
            else if (winner === 'CT') {
                this.currentMapScoreboard.ctScore++;
            }
            else {
                console.log('Got round won, but could not parse winner: ' + winner);
            }

            this.currentMapScoreboard.rows.forEach((row) => {
                if (row.team == winner) {
                    row.points += 2;
                }
            });

            this.notifyObservers();
        }

        changePlayerTeam = (uid, team) => {
            var row = this.findMapScoreRow(uid);
            if (row == null) {
                console.log('Could not find player that changed team. Uid: ' + uid);
                return;
            }

            row.team = team;
        }

        playerAdded = (uid, name, team) => {
            var row = this.findMapScoreRow(uid);
            if (row == null) {
                row = new MapScoreRow();
                row.placement = 0;
                row.points = 0;
                row.kills = 0;
                row.deaths = 0;
                row.teamkills = 0;
                this.currentMapScoreboard.rows.push(row);
            };

            row.playerName = name;
            row.team = team;
            row.playerUid = uid;
            this.notifyObservers();
        }

        playerKilled = (kUid, kTeam, dUid, dTeam, wpn) => {
            var kRow = this.findMapScoreRow(kUid);
            var dRow = this.findMapScoreRow(dUid);

            if (kRow.team != dRow.team) {
                kRow.kills += 1;
                kRow.points += 1;
            } else {
                kRow.teamkills += 1;
                kRow.points -= 1;
            }

            dRow.deaths += 1;
            this.notifyObservers();
        }

        private findMapScoreRow(uid) : MapScoreRow {
            for (var i = 0; i < this.currentMapScoreboard.rows.length; i++) {
                var row = this.currentMapScoreboard.rows[i];
                if (row.playerUid === uid) {
                    return row;
                }
            }

            return null;
        }
    }

    export interface ScoreboardUpdatedListener {
        onScoreboardUpdated();
    };

    export interface OnNewMapOrRoundListener {
        onNewMapOrRoundUpdated();
    };
} 