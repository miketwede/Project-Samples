app.controller('salesTerritoryController', ['$scope', 'httpFactory', 'globalUtilities', function ($scope, httpFactory, globalUtilities) {
    
    var vm = this;

    // ui grid
    vm.salesTerritories = [];
    vm.responseData = [];

    vm.errorMessage = "";
    vm.success = true;
    vm.name = 'salesTerritoryController';


    function init() {
        if (httpFactory) {
         httpFactory.getSalesTerritories()
            .then(success, error);
            
            function success(response) {
                vm.salesTerritories = [];
                let rows =  response;
                if (rows.length > 0){
                    for (var i=0; i<rows.length; i++){
                        let Group = rows[i].group;
                        let Country = rows[i].country;
                        let Region = rows[i].region;
                        let SalesLastYear = globalUtilities.formatMoney(rows[i].salesLastYear);
                        let SalesYTD = globalUtilities.formatMoney(rows[i].salesYTD);
                        let CostLastYear = globalUtilities.formatMoney(rows[i].costLastYear);
                        let CostYTD = globalUtilities.formatMoney(rows[i].costYTD);
                        // let Address = vm.formatAddress(rows[i].person);

                        let masterRecord = {
                            Group: Group,
                            Country: Country,
                            GrRegionup: Region,
                            SalesLastYear: SalesLastYear,
                            SalesYTD: SalesYTD,
                            CostLastYear: CostLastYear,
                            CostYTD: CostYTD
                        };

                        vm.salesTerritories.push(masterRecord);
                        }

                }
            };

            function error(error) {
              vm.salesTerritories = [];                
              vm.success = false;
              vm.errorMessage = error;
            };
        }
    }

    init();


   }]);