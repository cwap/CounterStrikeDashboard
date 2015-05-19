var csdash;
(function (csdash) {
    var ScoreService = (function () {
        function ScoreService($http) {
            var _this = this;
            this.$http = $http;
            this.getScoreboard = function () {
                return _this.scoreboard;
            };
            this.reset = function () {
                _this.scoreboard = new csdash.Scoreboard();
            };
            this.roundEnded = function () {
            };
            this.scoreboard = new csdash.Scoreboard();
        }
        return ScoreService;
    })();
    csdash.ScoreService = ScoreService;
})(csdash || (csdash = {}));
