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
          fullName += customer.title + " ";
       }
       fullName += customer.firstName + " ";
       if (customer.middleInitial){
          fullName += customer.middleInitial + " ";
       }
       fullName += customer.lastName + " ";
       if (customer.suffix){
          fullName += customer.suffix;
       }
       
      return fullName.trim();
   }

   vm.formatAddress = function(customer)
   {
       var fullAddress = "";

       fullAddress += customer.address1 + " ";
       if (customer.address2){
          fullAddress += customer.address2 + " ";
       }

       fullAddress += customer.city + " ";
       fullAddress += customer.state + " ";
       fullAddress += customer.zip + " ";
       if (customer.country){
          fullAddress += customer.country;
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
                        let Name = vm.formatName(rows[i].person); 
                        let Phone = rows[i].person.phoneNumber;
                        let Email = rows[i].person.emailAddress;
                        let AccountNumber = rows[i].accountNumber;
                        let Address = vm.formatAddress(rows[i].person);
                        let Photo = rows[i].person.photo;
                        let IndividualSurvey = rows[i].demographics;

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