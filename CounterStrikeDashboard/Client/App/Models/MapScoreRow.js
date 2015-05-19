var __extends = this.__extends || function (d, b) {
    for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p];
    function __() { this.constructor = d; }
    __.prototype = b.prototype;
    d.prototype = new __();
};
var csdash;
(function (csdash) {
    var MapScoreRow = (function (_super) {
        __extends(MapScoreRow, _super);
        function MapScoreRow() {
            _super.apply(this, arguments);
        }
        return MapScoreRow;
    })(csdash.ScoreRowBase);
    csdash.MapScoreRow = MapScoreRow;
})(csdash || (csdash = {}));
