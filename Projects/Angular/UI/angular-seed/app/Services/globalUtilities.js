
(function () {
    
        'use strict';
    
        angular
          .module('myApp')
          .factory('globalUtilities', globalUtilities);
    
          globalUtilities
          .$inject = ['$http', '$log', '$q'];
    
        function globalUtilities($http, $log, $q) {
            var vm = this;
            vm.observerCallbacks = [];
            vm.loaded = false;
    
            // data objects
            vm.customerList = [];
            vm.errorMessage = "";

            // public API
            var factory = {
                formatName: formatName,
                formatAddress: formatAddress,
                formatMoney: formatMoney
                // customerList: customerList
            };
            return factory;

            function formatName(customer)
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
         
            function formatAddress(customer)
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


            function formatMoney(amount)
            {
                var formattedAmount = "";
                var decimals = 2;
                var sign = amount < 0 ? "-" : "";
                var dollarSign = "$";
                var decimalPoint = ".";
                var comma = ",";
                var stringAmount = String(parseInt(amount = Math.abs(Number(amount) || 0).toFixed(decimals)));
                var commas = (commas = stringAmount.length) > 3 ? commas % 3 : 0;


                formattedAmount = dollarSign + 
                sign + 
                (commas ? stringAmount.substr(0, commas) + comma : "") + 
                stringAmount.substr(commas).replace(/(\d{3})(?=\d)/g, "$1" + comma) + 
                (decimals ? decimalPoint + Math.abs(amount - stringAmount).toFixed(decimals).slice(2) : "");

                // Number.prototype.formatMoney = function(c, d, t){
                //     var n = this, 
                //         c = isNaN(c = Math.abs(c)) ? 2 : c, 
                //         d = d == undefined ? "." : d, 
                //         t = t == undefined ? "," : t, 
                //         s = n < 0 ? "-" : "", 

                // i = String(parseInt(n = Math.abs(Number(n) || 0).toFixed(c))), 
                //  j = (j = i.length) > 3 ? j % 3 : 0;
                //    return s + (j ? i.substr(0, j) + t : "") + i.substr(j).replace(/(\d{3})(?=\d)/g, "$1" + t) + (c ? d + Math.abs(n - i).toFixed(c).slice(2) : "");
                //  };

                return formattedAmount.trim();
            }


        }
    })();
    