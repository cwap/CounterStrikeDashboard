﻿module csdash {
    export class ControlService {
        public static $inject = [
            '$http',
        ];

        constructor(private $http: any) {
            
        }

        reset = () => {
            this.$http.post('/sessions/reset').
                success(function (data, status, headers, config) {
                    console.log("Reset event sent");
                }).
                error(function (data, status, headers, config) {
                    console.log("Unable to reset sessions");
                });
        }
    }
} 