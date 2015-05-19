var __extends = this.__extends || function (d, b) {
    for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p];
    function __() { this.constructor = d; }
    __.prototype = b.prototype;
    d.prototype = new __();
};
var csdash;
(function (csdash) {
    var PlantedBombEvent = (function (_super) {
        __extends(PlantedBombEvent, _super);
        function PlantedBombEvent() {
            _super.apply(this, arguments);
            this.__name__ = "PlantedBombEvent";
        }
        return PlantedBombEvent;
    })(csdash.EventBase);
    csdash.PlantedBombEvent = PlantedBombEvent;
})(csdash || (csdash = {}));
