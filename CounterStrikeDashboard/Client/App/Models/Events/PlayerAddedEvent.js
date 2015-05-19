var __extends = this.__extends || function (d, b) {
    for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p];
    function __() { this.constructor = d; }
    __.prototype = b.prototype;
    d.prototype = new __();
};
var csdash;
(function (csdash) {
    var PlayerAddedEvent = (function (_super) {
        __extends(PlayerAddedEvent, _super);
        function PlayerAddedEvent() {
            _super.apply(this, arguments);
            this.__name__ = "PlayerAddedEvent";
        }
        return PlayerAddedEvent;
    })(csdash.EventBase);
    csdash.PlayerAddedEvent = PlayerAddedEvent;
})(csdash || (csdash = {}));
