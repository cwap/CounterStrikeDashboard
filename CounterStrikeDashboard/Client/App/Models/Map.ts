module csdash {
    export class Map {
        private __name__ = "Map";

        constructor() {
            this.teams = new Array<TeamTuple>();
            var ct = new TeamTuple();
            ct.team = "CT";
            this.teams.push(ct);
            var t = new TeamTuple();
            t.team = "T";
            this.teams.push(t);
        }

        start: Date = new Date();
        mapName: string = "";
        players: Array<PlayerTuple> = [];
        teams: Array<TeamTuple> = [];
        active: boolean = false;
    }
} 