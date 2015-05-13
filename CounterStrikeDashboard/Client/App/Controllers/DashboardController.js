var csdash;
(function (csdash) {
    var DashboardController = (function () {
        function DashboardController($scope) {
            this.$scope = $scope;
            $scope.text = "Hej text";
            /*this._chat = $.connection.chatHub;
            this._chat.client.broadcastMessage = function (message: string) {
            alert(message);
            };*/
        }
        DashboardController.prototype.sendMessage = function (message) {
            //this._chat.server.sendMessage("Hej");
        };
        DashboardController.$inject = [
            '$scope'
        ];
        return DashboardController;
    })();
    csdash.DashboardController = DashboardController;
})(csdash || (csdash = {}));
