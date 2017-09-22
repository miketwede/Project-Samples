// 'use strict';

// angular.module('myApp')



// .controller('View1Ctrl', [function() {

// }]);

(function () {
  'use strict';


  angular.module('myApp').controller('View1Ctrl', View1Ctrl);
  /* @ngInject */
  View1Ctrl.$inject = ['$route', '$routeParams', '$scope', '$location'];
  function View1Ctrl($route, $routeParams, $scope, $location) {
      var vm = this;

     // vm.isCurrent = isCurrent;

     vm.name = 'View1Ctrl';
     vm.params = $routeParams;

      function init() {
          // if (appUserFactory) {
          //     vm.isManager = appUserFactory.isXDManager();
          // }
      }

      init();
  };

})();