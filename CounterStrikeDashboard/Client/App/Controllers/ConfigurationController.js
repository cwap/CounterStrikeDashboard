var csdash;
(function (csdash) {
    'use strict';

    var ConfigurationController = (function () {
        function ConfigurationController($scope) {
            this.$scope = $scope;
            $scope.text = "Hej text";
        }
        ConfigurationController.$inject = [
            '$scope'
        ];
        return ConfigurationController;
    })();
    csdash.ConfigurationController = ConfigurationController;
})(csdash || (csdash = {}));
