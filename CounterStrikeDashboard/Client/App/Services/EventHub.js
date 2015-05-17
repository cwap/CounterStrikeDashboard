var __extends = this.__extends || function (d, b) {
    for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p];
    function __() { this.constructor = d; }
    __.prototype = b.prototype;
    d.prototype = new __();
};
var csdash;
(function (csdash) {
    'use strict';

    var EventHub = (function (_super) {
        __extends(EventHub, _super);
        function EventHub() {
            var _this = this;
            _super.call(this, "eventHub");

            this._newEventListeners = [];

            this.hub.client.lol = function (msg) {
                for (var i = 0; i < _this._newEventListeners.length; i++) {
                    _this._newEventListeners[i](msg);
                }
            };
        }
        EventHub.prototype.addNewEventListener = function (listener) {
            this._newEventListeners.push(listener);
        };
        return EventHub;
    })(csdash.HubBase);
    csdash.EventHub = EventHub;
})(csdash || (csdash = {}));
