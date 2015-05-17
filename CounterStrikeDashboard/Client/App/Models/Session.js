var csdash;
(function (csdash) {
    var Session = (function () {
        function Session() {
            this.__name__ = "Session";
            this.maps = [];
            this.started = new Date();
            this.ended = new Date();
        }
        return Session;
    })();
    csdash.Session = Session;
})(csdash || (csdash = {}));
