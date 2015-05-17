module csdash {
    export class ConfigurationController {
        public static $inject = [
            '$scope',
            '$http'
        ];
        
        constructor(private $scope: any, $http: any) {
            
        }
    }
}