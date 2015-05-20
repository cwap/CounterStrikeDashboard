module csdash {
    export class MapScoreboard {
        map: string;
        started: Date;
        rows: Array<MapScoreRow> = [];
        tScore: number = 0;
        ctScore: number = 0;
    }
} 