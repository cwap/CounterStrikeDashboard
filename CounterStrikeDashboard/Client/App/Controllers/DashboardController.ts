module csdash {
    export class DashboardController {
        private _chat;

        public static $inject = [
            '$scope',
            '$http',
            'eventHub',
        ];

        constructor(private $scope: any, private $http: any, private eventHub: EventHub) {
            this.fixScope($scope);

            eventHub.addNewEventListener(function (event) {
                console.log("Got new event: " + event);
                $scope.dashboard.events.push(event);
                $scope.$apply();
            });

            $http.get('/sessions').
                success(function (data, status, headers, config) {
                    var sessions = Serializer.deserializeObj(data);
                    $scope.sessions = sessions;
                }).
                error(function (data, status, headers, config) {
                    console.log("Unable to get session data");
                });
        }

        private fixScope($scope: any) {
            if (!$scope.scores) {
                $scope.scores = {};
            }

            if (!$scope.dashboard) {
                $scope.dashboard = {};
            }

            if (!$scope.dashboard.events) {
                $scope.dashboard.events = [];
            }
        }
    }
}