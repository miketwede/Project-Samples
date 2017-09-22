"use strict";

// Declare app level module which depends on views, and components
var app = angular.module("myApp", ["ngRoute", "ui.router"]);
// var app = angular.module("myApp", ["ngRoute", "ui.router", "ngAnimate"]);

// app.config(function($locationProvider, $routeProvider) {
  app.config(function($routeProvider, $locationProvider ) {
  //  app.config(function($routeProvider ) {
       $locationProvider.hashPrefix("!");

  //   $locationProvider.html5Mode({
  //     enabled: true,
  //     requireBase: false
  // });

  $routeProvider
  .when("/", {
    templateUrl : "index.html",
    controller: "helloWorldController",
    controllerAs: 'helloWorld'
})
  .when("/view1", {
    templateUrl: "view1/view1.html",
    controller: "View1Ctrl",
    controllerAs: 'view1'    
  })
  .when("/view2", {
    templateUrl: "view2/view2.html",
    controller: "View2Ctrl",
    controllerAs: 'view2'
    
  })
  .otherwise({redirectTo: "/"});
});

