module csdash {
    'use strict'

    export class Player {
        private _name: string;
        private _kills: number;
        private _deaths: number;
        private _ping: number;
        private _ip: string;

        constructor() {
        }

        get name(): string {
            return this._name;
        }

        set name(name: string) {
            this._name = name;
        }

        get kills(): number {
            return this._kills;
        }

        set kills(kills: number) {
            this._kills = kills;
        }

        get deaths(): number {
            return this._deaths;
        }

        set deaths(deaths: number) {
            this._deaths = deaths;
        }

        get ping(): number {
            return this._ping;
        }

        set ping(ping: number) {
            this._ping = ping;
        }

        get ip(): string {
            return this._ip;
        }

        set ip(ip: string) {
            this._ip = ip;
        }
    }
}