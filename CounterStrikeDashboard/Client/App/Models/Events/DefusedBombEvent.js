var __extends = this.__extends || function (d, b) {
    for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p];
    function __() { this.constructor = d; }
    __.prototype = b.prototype;
    d.prototype = new __();
};
var csdash;
(function (csdash) {
    var DefusedBombEvent = (function (_super) {
        __extends(DefusedBombEvent, _super);
        function DefusedBombEvent() {
            _super.apply(this, arguments);
            this.__name__ = "DefusedBombEvent";
        }
        return DefusedBombEvent;
    })(csdash.EventBase);
    csdash.DefusedBombEvent = DefusedBombEvent;
})(csdash || (csdash = {}));
