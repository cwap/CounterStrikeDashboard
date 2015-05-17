var csdash;
(function (csdash) {
    var ConfigurationController = (function () {
        function ConfigurationController($scope, $http) {
            this.$scope = $scope;
        }
        ConfigurationController.$inject = [
            '$scope',
            '$http'
        ];
        return ConfigurationController;
    })();
    csdash.ConfigurationController = ConfigurationController;
})(csdash || (csdash = {}));
