module csdash {
    export class PlayerAddedEvent extends EventBase {
        private __name__ = "PlayerAddedEvent";

        player: Player;
    }
}  