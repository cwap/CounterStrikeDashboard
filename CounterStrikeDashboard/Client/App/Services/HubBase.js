var csdash;
(function (csdash) {
    var HubBase = (function () {
        function HubBase(hubName) {
            this.hub = $.connection[hubName];
        }
        return HubBase;
    })();
    csdash.HubBase = HubBase;
})(csdash || (csdash = {}));
