app.controller('customerController', ['$scope', 'httpFactory', function ($scope, httpFactory) {
    
    var vm = this;

    // ui grid
    vm.customers = [];
    vm.responseData = [];

    vm.errorMessage = "";
    vm.success = true;
    vm.name = 'customerController';


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
                vm.customers = [];
                let rows =  response;
                if (rows.length > 0){
                    for (var i=0; i<rows.length; i++){
                        let Name = vm.formatName(rows[i]); 
                        let Phone = rows[i].PhoneNumber;
                        let Email = rows[i].EmailAddress;
                        let AccountNumber = rows[i].AccountNumber;
                        let Address = vm.formatAddress(rows[i]);
                        let Photo = rows[i].Photo;
                        let IndividualSurvey = rows[i].Demographics;

                        let masterRecord = {
                            Name: Name,
                            Phone: Phone,
                            Email: Email,
                            AccountNumber: AccountNumber,
                            Address: Address
                            // Photo: Photo,
                            // detailRecords: IndividualSurvey
                            };

                        vm.customers.push(masterRecord);
                        }

                }
            };

            function error(error) {
              vm.customers = [];                
              vm.success = false;
              vm.errorMessage = error;
            };
        }
    }

    init();


   }]);