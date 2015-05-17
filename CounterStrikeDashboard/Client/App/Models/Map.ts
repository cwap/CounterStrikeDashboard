module csdash {
    export class Map {
        private __name__ = "Map";

        start: Date = new Date();
        mapName: string = "";
        players: Array<PlayerTuple> = [];
        teams: Array<TeamTuple> = [];
        active: boolean = false;
    }
} 