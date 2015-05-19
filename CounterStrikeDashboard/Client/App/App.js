var csdash;
(function (csdash) {
    'use strict';

    var csDashApp = angular.module('csDashApp', ['ngRoute']).controller('appController', csdash.AppController).controller('dashboardController', csdash.DashboardController).controller('configurationController', csdash.ConfigurationController).service('hubService', csdash.HubService).service('controlService', csdash.ControlService).service('eventHub', csdash.EventHub);

    csDashApp.config(function ($routeProvider) {
        $routeProvider.when('/', {
            templateUrl: 'views/dashboard.html',
            controller: 'dashboardController',
            activetab: 'dashboard'
        }).when('/dashboard', {
            templateUrl: 'views/dashboard.html',
            controller: 'dashboardController',
            activetab: 'dashboard'
        }).when('/configuration', {
            templateUrl: 'views/configuration.html',
            controller: 'configurationController',
            activetab: 'configuration'
        });
    });
})(csdash || (csdash = {}));
