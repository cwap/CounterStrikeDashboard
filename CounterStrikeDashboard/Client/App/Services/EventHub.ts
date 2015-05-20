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

            this.hub.client.roundEnded = (evt) => {
                var obj = Serializer.deserializeObj(evt);
                this.scoreboard.roundWon(obj.team);
            }

            this.hub.client.newMapStarted = (evt) => {
                var obj = Serializer.deserializeObj(evt);
                this.scoreboard.startNewMap(obj.map, obj.eventTime);
            }

            this.hub.client.joinedTeam = (evt) => {
                var obj = Serializer.deserializeObj(evt);
                this.scoreboard.changePlayerTeam(obj.player.uid, obj.team);
            }

            this.hub.client.playerAdded = (evt) => {
                var obj = Serializer.deserializeObj(evt);
                this.scoreboard.playerAdded(obj.player.uid, obj.player.playerName, obj.player.team);
            }

            this.hub.client.playerKilled = (evt) => {
                var obj = Serializer.deserializeObj(evt);
                this.scoreboard.playerKilled(obj.killer.uid, obj.killer.team, obj.dead.uid, obj.dead.team, obj.weapon);
            }
        }
    }
}