module csdash {
    'use strict';

    var csDashApp = angular.module('csDashApp', ['ngRoute'])
        .controller('dashboardController', DashboardController)
        .controller('configurationController', ConfigurationController);
   
    csDashApp.config(function ($routeProvider) {
        $routeProvider
            .when('/', {
                templateUrl: 'views/dashboard.html',
                controller: 'dashboardController'
            })
            .when('/dashboard', {
                templateUrl: 'views/dashboard.html',
                controller: 'dashboardController'
            })
            .when('/configuration', {
                templateUrl: 'views/configuration.html',
                controller: 'configurationController'
            })
    });
}