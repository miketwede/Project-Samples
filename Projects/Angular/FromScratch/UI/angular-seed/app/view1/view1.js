(function () {
  'use strict';

  angular.module('myApp').controller('View1Ctrl', View1Ctrl);
  /* @ngInject */
  View1Ctrl.$inject = ['$route', '$routeParams', '$scope', '$location', 'httpFactory'];
  function View1Ctrl(   $route,   $routeParams,   $scope,   $location,   httpFactory) {
      var vm = this;

      vm.customers = [];
    //   vm.customerList = httpFactory.customerList;
     // vm.isCurrent = isCurrent;

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
        //  vm.customers = httpFactory.getCustomers4();
           httpFactory.getCustomers4()
              .then(success, error);
              
                          function success(response) {
                            vm.customers =  response;
                            console.log("vm.customers 1.", vm.customers );
                        };
              
                          function error(error) {
                            console.log("error", error);
                            
                          };


              console.log("vm.customers 2.", vm.customers);
              var mike = "";
          }
      }

      init();
  };

})();