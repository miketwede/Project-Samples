// 'use strict';

// angular.module('myApp')



// .controller('View2Ctrl', [function() {

// }]);

(function () {
  'use strict';


  angular.module('myApp').controller('View2Ctrl', View2Ctrl);
  /* @ngInject */
  View2Ctrl.$inject = ['$route', '$scope', '$location'];
  function View2Ctrl($route, $scope, $location) {
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