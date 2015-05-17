module csdash {
    export class Serializer {
        static deserializeJson(clazz, json: string) {
            var jsonObj = JSON.parse(json);
            return Serializer.deserializeObj(jsonObj);
        }

        static deserializeObj(json) {
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
        }
    }
} 