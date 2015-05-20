var csdash;
(function (csdash) {
    var ControlService = (function () {
        function ControlService($http) {
            var _this = this;
            this.$http = $http;
            this.reset = function () {
                _this.$http.post('/sessions/reset').success(function (data, status, headers, config) {
                    console.log("Reset event sent");
                }).error(function (data, status, headers, config) {
                    console.log("Unable to reset sessions");
                });
            };
            this.replayFile = function (fileName) {
                _this.$http.post('/sessions/replayFile/' + fileName).success(function (data, status, headers, config) {
                    console.log("Replay file event sent");
                }).error(function (data, status, headers, config) {
                    console.log("Unable to replay file sessions");
                });
            };
        }
        ControlService.$inject = [
            '$http'
        ];
        return ControlService;
    })();
    csdash.ControlService = ControlService;
})(csdash || (csdash = {}));
