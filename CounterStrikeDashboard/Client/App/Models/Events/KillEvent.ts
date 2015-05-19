module csdash {
    export class KillEvent extends EventBase {
        private __name__ = "KillEvent";

        killer: Player;
        dead: Player;
        weapon: string;
    }
} 