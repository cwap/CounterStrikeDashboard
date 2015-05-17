module csdash {
    export class PlayerTuple {
        private __name__ = "PlayerTuple";

        name: string = "Unknown";
        uniqueIdentifier: string = "";
        team: string = "none";
        kills: number = 0;
        deaths: number = 0;
        connected: boolean = false;
    }
}