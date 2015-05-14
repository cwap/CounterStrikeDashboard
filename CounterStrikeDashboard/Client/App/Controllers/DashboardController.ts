module csdash {
    export class DashboardController {
        private _chat;

        public static $inject = [
            '$scope',
            'hubBase',
        ];

        constructor(private $scope: any, private hubBase: HubBase) {
            hubBase.addStateListener(function (state) {
                $scope.state = state;
            });

            var players: Array<Player> = [];

            var p1 = new Player();
            p1.name = "Allan";
            p1.ip = "127.0.0.1";
            p1.ping = 13;
            p1.kills = 37;
            players.push(p1);

            var p2 = new Player();
            p2.name = "Chr7";
            p2.ip = "127.0.0.2";
            p2.ping = 14;
            p2.kills = 5;
            players.push(p2);

            var p3 = new Player();
            p3.name = "Jeppe";
            p3.ip = "22.0.0.22";
            p3.ping = 1000;
            p3.kills = -5;
            players.push(p3);

            $scope.currentScoreTable = players;
            $scope.totalScoreTable = players;
        }
    }
}

/*$(function () {
    // Declare a proxy to reference the hub. 
    var chat = $.connection.chatHub;
    // Create a function that the hub can call to broadcast messages.
    chat.client.broadcastMessage = function (name, message) {
        // Html encode display name and message. 
        var encodedName = $('<div />').text(name).html();
        var encodedMsg = $('<div />').text(message).html();
        // Add the message to the page. 
        $('#discussion').append('<li><strong>' + encodedName
            + '</strong>:&nbsp;&nbsp;' + encodedMsg + '</li>');
    };
    // Get the user name and store it to prepend to messages.
    $('#displayname').val("asd");
    // Set initial focus to message input box.  
    $('#message').focus();
    // Start the connection.
    $.connection.hub.start().done(function () {
        $('#sendmessage').click(function () {
            // Call the Send method on the hub. 
            chat.server.send($('#displayname').val(), $('#message').val());
            // Clear text box and reset focus for next comment. 
            $('#message').val('').focus();
        });
    });
});*/