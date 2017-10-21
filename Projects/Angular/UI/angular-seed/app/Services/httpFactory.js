
(function () {
    
        'use strict';
    
        angular
          .module('myApp')
          .factory('httpFactory', httpFactory);
    
          httpFactory
          .$inject = ['$http', '$log', '$q'];
    
        function httpFactory($http, $log, $q) {
            // Logging methods:
            // log()   - Write a log message
            // info()  - Write an information message
            // warn()  - Write a warning message
            // error() - Write an error message
            // debug() - Write a debug message



            var vm = this;
            vm.observerCallbacks = [];
            vm.loaded = false;
    
            // data objects
            vm.customerList = [];
            vm.errorMessage = "";

            // public API
            var factory = {
                getCustomers: getCustomers,
                getSalesTerritories: getSalesTerritories
                // customerList: customerList
            };
            return factory;

            function reqListener () {
                console.log(this.responseText);
                return this.responseText;
              }

function getCustomers()
    {
                var api = 'http://localhost:52819/api/customers/GetCustomers';
              // var api = 'http://localhost:63131/api/customers/GetCustomers';
               
        return $http.get(api)
        
                   .then(
                      function (response) {
                        return response.data;
                      },

                      function (httpError) {
                         // translate the error
                         if (httpError.status == -1){
                            var errorMessage = "Network error : Unable to connect to the server.";
                            $log.error(errorMessage);
                            throw errorMessage;
                         }
                        else{
                            var errorMessage = formatErrorMessage(httpError);
                            $log.error(errorMessage);
                            throw errorMessage;
                        }

                        // return httpError.status + " : " + 
                        // httpError.data;
                      });
            }

            function getSalesTerritories()
            {
                var api = 'http://localhost:52819/api/sales/GetSalesTerritories';
              //  var api = 'http://localhost:63131/api/sales/GetSalesTerritories';
                       
                return $http.get(api)
                
                           .then(
                              function (response) {
                                return response.data;
                              },
        
                              function (httpError) {
                                 // translate the error
                                 if (httpError.status == -1){
                                    var errorMessage = "Network error : Unable to connect to the server.";
                                    $log.error(errorMessage);
                                    throw errorMessage;
                                 }
                                else{
                                    var errorMessage = formatErrorMessage(httpError);
                                    $log.error(errorMessage);
                                    throw errorMessage;
                                }
        
                                // return httpError.status + " : " + 
                                // httpError.data;
                              });
                    }

function formatErrorMessage(error){
    var formattedMessage = error.data.Message;
    formattedMessage += " : ( ";
    formattedMessage += "status = " + error.status;
    formattedMessage += ", statusText = " + error.statusText;
    formattedMessage += ", ExceptionMessage = " + error.data.ExceptionMessage;
    formattedMessage += ", ExceptionType = " + error.data.ExceptionType;
    if (error.data.InnerException){
        formattedMessage += ", InnerException =";
        formattedMessage += " ExceptionMessage - " + error.data.InnerException.ExceptionMessage;
        formattedMessage += ", ExceptionType - " + error.data.InnerException.ExceptionType;
    }
    formattedMessage += " )";
    
    return formattedMessage;
    }

        }
    })();
    