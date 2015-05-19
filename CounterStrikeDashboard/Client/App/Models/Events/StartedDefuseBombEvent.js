var __extends = this.__extends || function (d, b) {
    for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p];
    function __() { this.constructor = d; }
    __.prototype = b.prototype;
    d.prototype = new __();
};
var csdash;
(function (csdash) {
    var StartedDefuseBombEvent = (function (_super) {
        __extends(StartedDefuseBombEvent, _super);
        function StartedDefuseBombEvent() {
            _super.apply(this, arguments);
            this.__name__ = "StartedDefuseBombEvent";
        }
        return StartedDefuseBombEvent;
    })(csdash.EventBase);
    csdash.StartedDefuseBombEvent = StartedDefuseBombEvent;
})(csdash || (csdash = {}));
