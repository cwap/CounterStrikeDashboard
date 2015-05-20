var csdash;
(function (csdash) {
    'use strict';

    var csDashApp = angular.module('csDashApp', ['ngRoute']).controller('appController', csdash.AppController).controller('dashboardController', csdash.DashboardController).controller('configurationController', csdash.ConfigurationController).service('hubService', csdash.HubService).service('controlService', csdash.ControlService).service('eventHub', csdash.EventHub).filter('where', function () {
        return function (input, matches) {
            input = input || '';
            var out = "";
            for (var i = 0; i < input.length; i++) {
                out = input.charAt(i) + out;
            }

            return out;
        };
    }).directive('dynamiccollapsible', function () {
        return {
            link: function ($scope, element, attrs) {
                // Trigger when number of children changes,
                // including by directives like ng-repeat
                var watch = $scope.$watch(function () {
                    return element.children().length;
                }, function () {
                    // Wait for templates to render
                    $scope.$evalAsync(function () {
                        $(".collapsible > li").removeClass('active');
                        $(".collapsible > li .collapsible-header").removeClass('active');
                        $(".collapsible > li:first-child").addClass('active');
                        $(".collapsible > li:first-child .collapsible-header").addClass('active');

                        $('.collapsible').collapsible({
                            accordion: false
                        });
                    });
                });
            }
        };
    });

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
