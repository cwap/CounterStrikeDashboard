var csdash;
(function (csdash) {
    var AppController = (function () {
        function AppController($scope, $route, hubService) {
            this.$scope = $scope;
            this.$route = $route;
            this.hubService = hubService;
            this.fixScope = function ($scope) {
                if (!$scope.hub) {
                    $scope.hub = [];
                }

                if (!$scope.hub.states) {
                    $scope.hub.statesEnum = csdash.HubStates;
                }
            };
            hubService.addStateListener(function (state) {
                $scope.$apply(function () {
                    return $scope.hub.state = state;
                });
            });
            this.fixScope($scope);

            $scope.$route = $route;
            hubService.start();
        }
        AppController.$inject = [
            '$scope',
            '$route',
            'hubService'
        ];
        return AppController;
    })();
    csdash.AppController = AppController;
})(csdash || (csdash = {}));
