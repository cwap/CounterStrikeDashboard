module csdash {
    export class AppController {
        public static $inject = [
            '$scope',
            '$route',
            'hubService'
        ];

        constructor(private $scope: any, private $route: any, private hubService: HubService) {
            hubService.addStateListener(state => {
                $scope.$apply(() => $scope.hub.state = state);
            });
            this.fixScope($scope);

            $scope.$route = $route;
            hubService.start();
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