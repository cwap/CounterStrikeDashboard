var csdash;
(function (csdash) {
    var ConfigurationController = (function () {
        function ConfigurationController($scope, $http, controlService) {
            var _this = this;
            this.$scope = $scope;
            this.controlService = controlService;
            this.fixScope = function ($scope) {
                if (!$scope.configuration) {
                    $scope.configuration = {};
                }

                $scope.configuration.fileName = 'lol3.txt';

                $scope.replayFile = function () {
                    _this.controlService.replayFile($scope.configuration.fileName);
                };
            };
            this.fixScope($scope);
        }
        ConfigurationController.$inject = [
            '$scope',
            '$http',
            'controlService'
        ];
        return ConfigurationController;
    })();
    csdash.ConfigurationController = ConfigurationController;
})(csdash || (csdash = {}));
