module csdash {
    export class DashboardController {

        public static $inject = [
            '$scope',
            'controlService',
            'eventHub',
        ];

        constructor(private $scope: any, private controlService: ControlService, private eventHub: EventHub) {
            this.fixScope($scope);                      
        }

        private fixScope = ($scope: any) => {
            if (!$scope.dashboard) {
                $scope.dashboard = {};
            }

            if (!$scope.dashboard.events) {
                $scope.dashboard.events = [];
            }

            $scope.getScoreboard = () => {
                return this.eventHub.scoreboard;
            };
            $scope.reset = this.controlService.reset;
            $scope.replayFile = this.controlService.replayFile;
        }
    }
}