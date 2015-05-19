module csdash {
    export class RoundWinEvent extends EventBase {
        private __name__ = "RoundWinEvent";

        team: string;
        winType: string;
    }
}  