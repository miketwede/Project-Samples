(function () {
    'use strict';
  
  
    angular.module('myApp').controller('Footer', Footer);
    /* @ngInject */
    Footer.$inject = ['$route', '$routeParams', '$scope', '$location'];
    function Footer($route, $routeParams, $scope, $location) {
        var vm = this;
  
       // vm.isCurrent = isCurrent;
      //   $scope.who = 'World!';
  
      vm.name = 'Footer';
      vm.params = $routeParams;
  
        function init() {
            console.log("$route", $route)
            // if (appUserFactory) {
            //     vm.isManager = appUserFactory.isXDManager();
            // }
        }
  
        init();
    };
  
  })();