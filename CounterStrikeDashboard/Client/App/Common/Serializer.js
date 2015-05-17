var csdash;
(function (csdash) {
    var Serializer = (function () {
        function Serializer() {
        }
        Serializer.deserializeJson = function (clazz, json) {
            var jsonObj = JSON.parse(json);
            return Serializer.deserializeObj(jsonObj);
        };

        Serializer.deserializeObj = function (json) {
            var instance;
            if (json instanceof Array) {
                instance = [];
            } else {
                instance = new csdash[json.__name__]();
            }
            for (var prop in json) {
                if (!json.hasOwnProperty(prop)) {
                    continue;
                }

                if (typeof json[prop] === 'object') {
                    instance[prop] = Serializer.deserializeObj(json[prop]);
                } else {
                    instance[prop] = json[prop];
                }
            }

            return instance;
        };
        return Serializer;
    })();
    csdash.Serializer = Serializer;
})(csdash || (csdash = {}));
