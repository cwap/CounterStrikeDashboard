var __extends = this.__extends || function (d, b) {
    for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p];
    function __() { this.constructor = d; }
    __.prototype = b.prototype;
    d.prototype = new __();
};
var csdash;
(function (csdash) {
    var JoinedTeamEvent = (function (_super) {
        __extends(JoinedTeamEvent, _super);
        function JoinedTeamEvent() {
            _super.apply(this, arguments);
            this.__name__ = "JoinedTeamEvent";
        }
        return JoinedTeamEvent;
    })(csdash.EventBase);
    csdash.JoinedTeamEvent = JoinedTeamEvent;
})(csdash || (csdash = {}));
