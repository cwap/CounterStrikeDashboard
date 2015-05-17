var csdash;
(function (csdash) {
    var ScoreService = (function () {
        function ScoreService($http) {
            var _this = this;
            this.$http = $http;
            this.getSessions = function () {
                return _this.sessions;
            };
            this.reset = function () {
                _this.sessions = new Array();
            };
            this.roundEnded = function () {
            };
            this.sessions = new Array();

            $http.get('/sessions').success(function (data, status, headers, config) {
                _this.sessions = csdash.Serializer.deserializeObj(data);
            }).error(function (data, status, headers, config) {
                console.log("Unable to get session data");
            });
        }
        ScoreService.$inject = [
            '$http'
        ];
        return ScoreService;
    })();
    csdash.ScoreService = ScoreService;
})(csdash || (csdash = {}));
