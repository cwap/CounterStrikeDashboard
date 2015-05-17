var csdash;
(function (csdash) {
    var DashboardController = (function () {
        function DashboardController($scope, $http, eventHub) {
            this.$scope = $scope;
            this.$http = $http;
            this.eventHub = eventHub;
            this.fixScope($scope);

            eventHub.addNewEventListener(function (event) {
                console.log("Got new event: " + event);
                $scope.dashboard.events.push(event);
                $scope.$apply();
            });

            $http.get('/sessions').success(function (data, status, headers, config) {
                var sessions = csdash.Serializer.deserializeObj(data);
                $scope.sessions = sessions;
            }).error(function (data, status, headers, config) {
                console.log("Unable to get session data");
            });
        }
        DashboardController.prototype.fixScope = function ($scope) {
            if (!$scope.scores) {
                $scope.scores = {};
            }

            if (!$scope.dashboard) {
                $scope.dashboard = {};
            }

            if (!$scope.dashboard.events) {
                $scope.dashboard.events = [];
            }
        };
        DashboardController.$inject = [
            '$scope',
            '$http',
            'eventHub'
        ];
        return DashboardController;
    })();
    csdash.DashboardController = DashboardController;
})(csdash || (csdash = {}));
