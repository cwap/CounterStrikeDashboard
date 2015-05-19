var __extends = this.__extends || function (d, b) {
    for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p];
    function __() { this.constructor = d; }
    __.prototype = b.prototype;
    d.prototype = new __();
};
var csdash;
(function (csdash) {
    var MapStartedEvent = (function (_super) {
        __extends(MapStartedEvent, _super);
        function MapStartedEvent() {
            _super.apply(this, arguments);
            this.__name__ = "MapStartedEvent";
        }
        return MapStartedEvent;
    })(csdash.EventBase);
    csdash.MapStartedEvent = MapStartedEvent;
})(csdash || (csdash = {}));
