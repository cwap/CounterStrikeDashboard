var csdash;
(function (csdash) {
    var DashboardController = (function () {
        function DashboardController($scope, scoreService, controlService) {
            var _this = this;
            this.$scope = $scope;
            this.scoreService = scoreService;
            this.controlService = controlService;
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

                $scope.getSessions = _this.scoreService.getSessions;
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
            'scoreService',
            'controlService'
        ];
        return DashboardController;
    })();
    csdash.DashboardController = DashboardController;
})(csdash || (csdash = {}));
