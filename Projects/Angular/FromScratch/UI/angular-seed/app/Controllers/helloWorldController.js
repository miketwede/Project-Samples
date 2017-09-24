(function () {
    'use strict';


    angular.module('myApp').controller('helloWorldController', helloWorldController);
    /* @ngInject */
    // helloWorldController.$inject = ['$route', '$rootScope', '$routeParams', '$scope', '$location', 'ngAnimate'];
    // function helloWorldController($route, $rootScope, $routeParams, $scope, $location, ngAnimate) {
        helloWorldController.$inject = ['$route', '$rootScope', '$routeParams', '$scope', '$location'];
        function helloWorldController($route, $rootScope, $routeParams, $scope, $location) {
    
        var vm = this;

       // vm.isCurrent = isCurrent;
        $scope.who = 'World!';
        vm.$route = $route;
        vm.$location = $location;
        vm.$routeParams = $routeParams;
        this.name = 'helloWorldController';

        function init() {
            $rootScope.$on('$viewContentLoaded', function(event) {
                console.log(event);
            });

            // if (appUserFactory) {
            //     vm.isManager = appUserFactory.isXDManager();
            // }
        }

        init();
    };

})();
