'use strict';

// Declare app level module which depends on views, and components
var app = angular.module('myApp', ['ngRoute']);

// app.config(function($locationProvider, $routeProvider) {
app.config(function($routeProvider) {
    // $locationProvider.hashPrefix('!');

  $routeProvider
  .when("/", {
    templateUrl : "view1/view1.html",
    controller: 'View1Ctrl'
})
  .when('/view1', {
    templateUrl: 'view1/view1.html',
    controller: 'View1Ctrl'
  })
  .when('/view2', {
    templateUrl: 'view2/view2.html',
    controller: 'View2Ctrl'
  })
  .otherwise({redirectTo: '/'});
});
