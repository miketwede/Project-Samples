// 'use strict';

// angular.module('myApp')



// .controller('View2Ctrl', [function() {

// }]);

(function () {
  'use strict';


  angular.module('myApp').controller('View2Ctrl', View2Ctrl);
  /* @ngInject */
  View2Ctrl.$inject = ['$route', '$routeParams', '$scope', '$location'];
  function View2Ctrl($route, $routeParams, $scope, $location) {
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