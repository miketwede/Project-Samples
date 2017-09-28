(function () {
  'use strict';

  angular.module('myApp').controller('customerController', customerController);
  /* @ngInject */
  customerController.$inject = ['$route', '$routeParams', '$scope', '$location', 'httpFactory'];
  function customerController(   $route,   $routeParams,   $scope,   $location,   httpFactory) {
      var vm = this;

      vm.customers = [];
      vm.errorMessage = "";
      vm.success = true;
      vm.name = 'View1Ctrl';
      vm.params = $routeParams;

     vm.formatName = function(customer)
     {
         var fullName = "";
         if (customer.Title){
            fullName += customer.Title + " ";
         }
         fullName += customer.FirstName + " ";
         if (customer.MiddleInitial){
            fullName += customer.MiddleInitial + " ";
         }
         fullName += customer.LastName + " ";
         if (customer.Suffix){
            fullName += customer.Suffix;
         }
         
        return fullName.trim();
     }

     vm.formatAddress = function(customer)
     {
         var fullAddress = "";

         fullAddress += customer.Address1 + " ";
         if (customer.Address2){
            fullAddress += customer.Address2 + " ";
         }

         fullAddress += customer.City + " ";
         fullAddress += customer.State + " ";
         fullAddress += customer.Zip + " ";
         if (customer.Country){
            fullAddress += customer.Country;
         }
         
        return fullAddress.trim();
     }

      function init() {
          if (httpFactory) {
           httpFactory.getCustomers()
              .then(success, error);
              
              function success(response) {
                vm.customers =  response;
              };
  
              function error(error) {
                vm.customers = [];                
                vm.success = false;
                vm.errorMessage = error;
              };
          }
      }

      init();
  };

})();