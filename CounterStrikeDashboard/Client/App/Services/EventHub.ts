module csdash {

    export class EventHub extends HubBase {

        public static $inject = [];

        scoreboard: Scoreboard;

        getScoreboard = () => { return this.scoreboard };

        constructor() {
            super("eventHub");

            this.scoreboard = new Scoreboard();

            this.hub.client.controlReset = () => {
                console.log("control reset");
            }

            this.hub.client.roundEnded = (dt, winner) => {
                this.scoreboard.roundWon(winner);
            }

            this.hub.client.newMapStarted = (dt, map) => {
                this.scoreboard.startNewMap(map);
            }

            this.hub.client.joinedTeam = (dt, playerUid, playerName, team) => {
                this.scoreboard.changePlayerTeam(playerUid, team);
            }

            this.hub.client.playerAdded = (dt, playerUid, playerName) => {
                console.log("player added. name: " + playerName);
            }

            this.hub.client.playerKilled = (evt) => {
                console.log("someone died");
                var obj = Serializer.deserializeObj(evt);
            }
        }
    }
}