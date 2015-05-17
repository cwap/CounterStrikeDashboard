var csdash;
(function (csdash) {
    var AppController = (function () {
        function AppController($scope, $route, hubService, eventHub) {
            this.$scope = $scope;
            this.$route = $route;
            this.hubService = hubService;
            this.eventHub = eventHub;
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

            $scope.hub.state = 1 /* Connecting */;

            // Weird race condition when starting signalr hubs
            // http://stackoverflow.com/a/16973824/2372835
            setTimeout(function () {
                hubService.start();
            }, 700);
        }
        AppController.$inject = [
            '$scope',
            '$route',
            'hubService',
            'eventHub'
        ];
        return AppController;
    })();
    csdash.AppController = AppController;
})(csdash || (csdash = {}));
