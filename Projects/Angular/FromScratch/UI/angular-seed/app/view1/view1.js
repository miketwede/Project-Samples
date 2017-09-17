// 'use strict';

// angular.module('myApp')



// .controller('View1Ctrl', [function() {

// }]);

(function () {
  'use strict';


  angular.module('myApp').controller('View1Ctrl', View1Ctrl);
  /* @ngInject */
  View1Ctrl.$inject = ['$route', '$scope', '$location'];
  function View1Ctrl($route, $scope, $location) {
      var vm = this;

     // vm.isCurrent = isCurrent;
      $scope.who = 'World!';

      function init() {
          // if (appUserFactory) {
          //     vm.isManager = appUserFactory.isXDManager();
          // }
      }

      init();
  };

})();