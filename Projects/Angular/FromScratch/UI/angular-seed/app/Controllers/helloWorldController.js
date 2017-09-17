(function () {
    'use strict';


    angular.module('myApp').controller('helloWorldController', helloWorldController);
    /* @ngInject */
    helloWorldController.$inject = ['$route', '$scope', '$location'];
    function helloWorldController($route, $scope, $location) {
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
