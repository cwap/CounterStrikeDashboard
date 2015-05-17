module csdash {
    export class AppController {
        public static $inject = [
            '$scope',
            '$route',
            'hubService',
            'eventHub',
        ];

        constructor(
            private $scope: any,
            private $route: any,
            private hubService: HubService,
            private eventHub: EventHub) {
                hubService.addStateListener(state => {
                    $scope.$apply(() => $scope.hub.state = state);
                });
                this.fixScope($scope);

                $scope.$route = $route;

                $scope.hub.state = HubStates.Connecting;
                // Weird race condition when starting signalr hubs
                // http://stackoverflow.com/a/16973824/2372835
                setTimeout(function () {
                    hubService.start();
                }, 700);
        }

        private fixScope = ($scope: any) => {
            if (!$scope.hub) {
                $scope.hub = [];
            }

            if (!$scope.hub.states) {
                $scope.hub.statesEnum = HubStates;
            }
        }
    }
}