module csdash {
    'use strict';

    export class ConfigurationController {
        public static $inject = [
            '$scope',
        ];

        constructor(private $scope: any) {
            $scope.text = "Hej text";
        }
    }
}