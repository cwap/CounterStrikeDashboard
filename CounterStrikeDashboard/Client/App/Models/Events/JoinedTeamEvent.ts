module csdash {
    export class JoinedTeamEvent extends EventBase {
        private __name__ = "JoinedTeamEvent";

        player: Player;
        team: string;
    }
}   