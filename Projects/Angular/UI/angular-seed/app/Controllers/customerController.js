app.controller('customerController', ['$scope', 'httpFactory', 'globalUtilities', function ($scope, httpFactory, globalUtilities) {
        
    var vm = this;

    // ui grid
    vm.customers = [];
    vm.responseData = [];

    vm.errorMessage = "";
    vm.success = true;
    vm.name = 'customerController';

    function init() {
        if (httpFactory) {
         httpFactory.getCustomers()
            .then(success, error);
            
            function success(response) {
                vm.customers = [];
                let rows =  response;
                if (rows.length > 0){
                    for (var i=0; i<rows.length; i++){
                        let Name = globalUtilities.formatName(rows[i].person); 
                        let Phone = rows[i].person.phoneNumber;
                        let Email = rows[i].person.emailAddress;
                        let AccountNumber = rows[i].accountNumber;
                        let Address = globalUtilities.formatAddress(rows[i].person);
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