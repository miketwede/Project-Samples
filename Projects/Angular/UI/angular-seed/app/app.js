"use strict";

// Declare app level module which depends on views, and components
var app = angular.module("myApp", [
  "ngRoute", 
  "ui.router",
  "ui.grid",
  "ngGrid"
  // "agGrid"
]);

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
//   .when("/", {
//     templateUrl : "index.html",
//     controller: "helloWorldController",
//     controllerAs: 'helloWorld'
// })
  .when("/customers", {
    templateUrl: "Views/customers.html",
    controller: "customerController",
     controllerAs: 'vm'    
  })
  .when("/locations", {
    templateUrl: "Views/locations.html",
    controller: "locationController",
    controllerAs: 'vm'
    
  })
  // .otherwise({redirectTo: "/"});
  // .otherwise({redirectTo: "/view1"});
    // "axios"
  // "httpFactory"

});

