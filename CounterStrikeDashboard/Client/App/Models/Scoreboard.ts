module csdash {
    export class Scoreboard {
        currentMapScoreboard: MapScoreboard;
        mapScoreboards: Array<MapScoreboard> = [];

        startNewMap = (map) => {
            this.currentMapScoreboard = new MapScoreboard();
            this.currentMapScoreboard.map = map;
            this.mapScoreboards.splice(0, 0, this.currentMapScoreboard);
        }

        roundWon = (winner) => {
            if (winner === 'T')
                this.currentMapScoreboard.tScore++;
            else if (winner === 'CT')
                this.currentMapScoreboard.ctScore++;
            else
                console.log('Got round won, but could not parse winner: ' + winner);
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
} 