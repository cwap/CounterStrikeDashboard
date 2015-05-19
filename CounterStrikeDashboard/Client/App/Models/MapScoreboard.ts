module csdash {
    export class MapScoreboard {
        map: string;
        rows: Array<MapScoreRow> = [];
        tScore: number = 0;
        ctScore: number = 0;
    }
} 