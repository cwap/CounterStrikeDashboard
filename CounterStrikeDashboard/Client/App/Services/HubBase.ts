module csdash {
    export class HubBase {
        public hub: any;

        constructor(hubName: string) {
            this.hub = $.connection[hubName];
        }
    }
}