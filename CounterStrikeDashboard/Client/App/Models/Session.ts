module csdash {
    export class Session {
        private __name__ = "Session";

        maps: Array<Map> = [];
        started: Date = new Date();
        ended: Date = new Date();
    }
}