﻿var __extends = this.__extends || function (d, b) {
    for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p];
    function __() { this.constructor = d; }
    __.prototype = b.prototype;
    d.prototype = new __();
};
var csdash;
(function (csdash) {
    var RoundWinEvent = (function (_super) {
        __extends(RoundWinEvent, _super);
        function RoundWinEvent() {
            _super.apply(this, arguments);
            this.__name__ = "RoundWinEvent";
        }
        return RoundWinEvent;
    })(csdash.EventBase);
    csdash.RoundWinEvent = RoundWinEvent;
})(csdash || (csdash = {}));
