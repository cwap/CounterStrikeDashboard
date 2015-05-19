module csdash {
    'use strict';

    export class EventHub extends HubBase {

        public static $inject = ['scoreService'];

        private _scoreService;

        constructor(private scoreService: ScoreService) {
            super("eventHub");

            this._scoreService = scoreService;

            this.hub.client.controlReset = () => {
                this._scoreService.reset();
            }

            this.hub.client.roundEnded = (dt, winner) => {

            }

            this.hub.client.newMapStarted = (dt, map) => {

            }

            this.hub.client.joinedTeam = (dt, playerUid, playerName, team) => {

            }

            this.hub.client.playerAdded = (dt, playerUid, playerName) => {

            }

            this.hub.client.playerKilled = (evt) => {
                console.log("someone died");
                var obj = Serializer.deserializeObj(evt);
            };
        }
    }
}