module csdash {
    export class StartedDefuseBombEvent extends EventBase {
        private __name__ = "StartedDefuseBombEvent";

        team: string;
        winType: string;
    }
}