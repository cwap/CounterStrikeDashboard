module csdash {
    export class DashboardController {

        public static $inject = [
            '$scope',
            'scoreService',
            'controlService',
        ];

        constructor(private $scope: any, private scoreService: ScoreService, private controlService: ControlService) {
            this.fixScope($scope);                      
        }

        private fixScope = ($scope: any) => {
            if (!$scope.scores) {
                $scope.scores = {};
            }

            if (!$scope.dashboard) {
                $scope.dashboard = {};
            }

            if (!$scope.dashboard.events) {
                $scope.dashboard.events = [];
            }

            $scope.getSessions = this.scoreService.getSessions;  
            $scope.reset = this.controlService.reset;
            $scope.doStuff = this.doStuff;
        }

        doStuff = () => {
            console.log("Doing stuff");
        }
    }
}