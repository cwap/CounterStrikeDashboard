var csdash;
(function (csdash) {
    var Serializer = (function () {
        function Serializer() {
        }
        Serializer.deserializeJson = function (clazz, json) {
            var jsonObj = JSON.parse(json);
            return Serializer.deserializeObj(clazz, jsonObj);
        };

        Serializer.deserializeObj = function (json, environment) {
            var instance = new environment[json.__name__]();
            for (var prop in json) {
                if (!json.hasOwnProperty(prop)) {
                    continue;
                }

                if (typeof json[prop] === 'object') {
                    instance[prop] = Serializer.deserializeObj(json[prop], environment);
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
