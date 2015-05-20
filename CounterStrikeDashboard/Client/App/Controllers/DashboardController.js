var csdash;
(function (csdash) {
    var DashboardController = (function () {
        function DashboardController($scope, controlService, eventHub) {
            var _this = this;
            this.$scope = $scope;
            this.controlService = controlService;
            this.eventHub = eventHub;
            this.onScoreboardUpdated = function () {
                $scope.$apply();
            };
            this.fixScope = function ($scope) {
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
                $scope.replayFile = _this.controlService.replayFile;
            };
            this.fixScope($scope);
            this.eventHub.scoreboard.registerObserver(this);
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
