var csdash;
(function (csdash) {
    var DashboardController = (function () {
        function DashboardController($scope, controlService, eventHub) {
            var _this = this;
            this.$scope = $scope;
            this.controlService = controlService;
            this.eventHub = eventHub;
            this.fixScope = function ($scope) {
                if (!$scope.scores) {
                    $scope.scores = {};
                }

                if (!$scope.dashboard) {
                    $scope.dashboard = {};
                }

                if (!$scope.dashboard.events) {
                    $scope.dashboard.events = [];
                }

                $scope.getScoreboard = function () {
                    return _this.eventHub.scoreboard;
                };
                $scope.reset = _this.controlService.reset;
                $scope.doStuff = _this.doStuff;
            };
            this.doStuff = function () {
                console.log("Doing stuff");
            };
            this.fixScope($scope);
        }
        DashboardController.$inject = [
            '$scope',
            'controlService',
            'eventHub'
        ];
        return DashboardController;
    })();
    csdash.DashboardController = DashboardController;
})(csdash || (csdash = {}));
