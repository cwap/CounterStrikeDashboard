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

        }

        private findMapScoreRow(uid) {
            //for (number i = 0; i < 
        }
    }
} 