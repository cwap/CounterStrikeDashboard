module csdash {
    export class ConfigurationController {
        public static $inject = [
            '$scope',
            '$http',
            'controlService'
        ];
        
        constructor(private $scope: any, $http: any, private controlService: ControlService) {
            this.fixScope($scope);
        }

        private fixScope = ($scope: any) => {
            if (!$scope.configuration) {
                $scope.configuration = {};
            }

            $scope.configuration.fileName = 'lol3.txt';

            $scope.replayFile = () => {
                this.controlService.replayFile($scope.configuration.fileName);
            }
        }
    }
}