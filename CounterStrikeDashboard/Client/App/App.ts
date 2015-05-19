module csdash {
    'use strict';

    var csDashApp = angular.module('csDashApp', ['ngRoute'])
        .controller('appController', AppController)
        .controller('dashboardController', DashboardController)
        .controller('configurationController', ConfigurationController)
        .service('hubService', HubService)
        .service('controlService', ControlService)
        .service('eventHub', EventHub);
   
    csDashApp.config(function ($routeProvider) {
        $routeProvider
            .when('/', {
                templateUrl: 'views/dashboard.html',
                controller: 'dashboardController',
                activetab: 'dashboard'
            })
            .when('/dashboard', {
                templateUrl: 'views/dashboard.html',
                controller: 'dashboardController',
                activetab: 'dashboard'
            })
            .when('/configuration', {
                templateUrl: 'views/configuration.html',
                controller: 'configurationController',
                activetab: 'configuration'
            })
    });
}