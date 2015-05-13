module csdash {
    export class DashboardController {
        private _chat;

        public static $inject = [
            '$scope',
        ];

        constructor(private $scope: any) {
            $scope.text = "Hej text";
            /*this._chat = $.connection.chatHub;
            this._chat.client.broadcastMessage = function (message: string) {
                alert(message);
            };*/
        }

        sendMessage(message:string) {            
            //this._chat.server.sendMessage("Hej");
        }
    }
}