(function () {
  'use strict';


  angular.module('myApp').controller('locationController', locationController);
  /* @ngInject */
  locationController.$inject = ['$route', '$routeParams', '$scope', '$location'];
  function locationController($route, $routeParams, $scope, $location) {
      var vm = this;

     // vm.isCurrent = isCurrent;
    //   $scope.who = 'World!';

    vm.name = 'View2Ctrl';
    vm.params = $routeParams;

      function init() {
          // if (appUserFactory) {
          //     vm.isManager = appUserFactory.isXDManager();
          // }
      }

      init();
  };

})();