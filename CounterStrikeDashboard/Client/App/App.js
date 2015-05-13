var csdash;
(function (csdash) {
    'use strict';

    var csDashApp = angular.module('csDashApp', ['ngRoute']).controller('dashboardController', csdash.DashboardController).controller('configurationController', csdash.ConfigurationController);

    csDashApp.config(function ($routeProvider) {
        $routeProvider.when('/', {
            templateUrl: 'views/dashboard.html',
            controller: 'dashboardController'
        }).when('/dashboard', {
            templateUrl: 'views/dashboard.html',
            controller: 'dashboardController'
        }).when('/configuration', {
            templateUrl: 'views/configuration.html',
            controller: 'configurationController'
        });
    });
})(csdash || (csdash = {}));
