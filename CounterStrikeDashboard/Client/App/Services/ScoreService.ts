module csdash {
    export class ScoreService {
        sessions: Array<Session>;

        public static $inject = [
            '$http',
        ];

        constructor(private $http: any) {
            this.sessions = new Array<Session>();

            $http.get('/sessions').
                success((data, status, headers, config) => {                    
                    this.sessions = Serializer.deserializeObj(data);
                }).
                error((data, status, headers, config) => {
                    console.log("Unable to get session data");
                });
        }

        getSessions = () => { return this.sessions };

        reset = () => {
            this.sessions = new Array<Session>();
        }

        roundEnded = () => {
            
        }
    }
}