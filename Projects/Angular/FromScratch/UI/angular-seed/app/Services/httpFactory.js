
        

//     }
(function () {
    
        'use strict';
    
        angular
          .module('myApp')
          .factory('httpFactory', httpFactory);
    
          httpFactory
          .$inject = ['$http', '$log', '$q'];
    
        /**
         * Application User factory -- access and store information about this user.
         * - access data objects externally using userFactory.{object}.data
         * @param intcWebRequest
         * @param intcConfigurator
         * 
         */
        function httpFactory($http, $log, $q) {
            
            var vm = this;
            vm.observerCallbacks = [];
            vm.loaded = false;
    
         //   vm.customerList = [];

            // data objects
            vm.currentUser = {};
            vm.currentUserManager = {};
            vm.currentUserOrg = {};
            vm.userHasError = false;
              vm.errorMessage = "";
            vm.userRoles = "";
            // public API
            var factory = {
            //    getCustomers: getCustomers,
                // getCustomers2: getCustomers2,
             //   getCustomers3: getCustomers3,
                getCustomers4: getCustomers4
                // customerList: customerList
            };
            return factory;

            function reqListener () {
                console.log(this.responseText);
                return this.responseText;
              }

// function getCustomers()
//     {
//         var xhr = new XMLHttpRequest();
//         xhr.onreadystatechange = function() {
//             if (this.readyState == 4 && this.status == 200) {
//                // Typical action to be performed when the document is ready:
//               // document.getElementById("customers").innerHTML = xhr.responseText;

//               vm.customerList = xhr.responseText;

//                return xhr.responseText;
//             }
//         };
//         xhr.addEventListener("load", reqListener);
//      //   xhr.open('GET', "http://localhost:52819/api/customers/GetCustomers", true);
//         xhr.open('GET', "http://localhost:52819/api/customers/GetCustomers", false);
//         //  var customers =  xhr.send();
//         xhr.send();
//         // var customers =  xhr.responseText;
//       //  var customers =  reqListener();
//        // return customers;
//     }
    
    // function getCustomers2()
    // {
    //     var config = {
    //         headers: {'X-My-Custom-Header': 'Header-Value'},
    //         responseType: 'json'
    //       };
          
    //     //   axios.get('https://api.github.com/users/codeheaven-io', config);
    //     //   axios.post('/save', { firstName: 'Marlon' }, config);

    //    var mike = axios.get('http://localhost:52819/api/customers/GetCustomers', config)
    //    .then(function (response) {
    //     console.log("response", response);
    //     console.log("response.data", response.data);
    //     console.log(response.status);
    //     console.log(response.statusText);
    //     console.log(response.headers);
    //     console.log(response.config);
    //     return response.data;
    //    })
    //    .catch(function (error) {
    //     console.log("error", error);
    //   //  return error;
    //  // throw new Error(error);
    //   throw error;
    // });
   
    //    return mike;
    // }



    // function getCustomers3() {
    //     // perform some asynchronous operation, resolve or reject the promise when appropriate.
    //     return $q(function(resolve, reject) {

    //         var xhr = new XMLHttpRequest();
    //         xhr.onreadystatechange = function() {
    //             // if (this.readyState == 4 && this.status == 200) {
    //             //    // Typical action to be performed when the document is ready:
    //             //    return xhr.responseText;
    //             // }

    //             console.log("this", this);
                

    //             if (this.status == 200) {
    //                 // Typical action to be performed when the document is ready:

                    
    //                 if (xhr.responseText) {
    //                     resolve(xhr.responseText);
    //                     document.getElementById("customers").innerHTML = xhr.responseText;
    //                   } 
    //                   else{
    //                     resolve("no records");
                        
    //                   }
    //             //    return xhr.responseText;
    //              }
    //              else{
    //                 reject('failed');
    //              }
    //             //  if (xhr.responseText) {
    //             //     resolve(xhr.responseText);
    //             //   } else {
    //             //     reject('failed');
    //             //   }
    //         };
    //      ////////////////////////  xhr.addEventListener("load", reqListener);
    //     //  xhr.open('GET', "http://localhost:52819/api/customers/GetCustomers", true);
    //      xhr.open('GET', "http://localhost:52819/api/customers/GetCustomers", false);
    //      //  var customers =  xhr.send();
    //         xhr.send();
    //         // var customers =  xhr.responseText;
    //       //  var customers =  reqListener();
    //        // return customers;



    //         if (xhr.responseText) {
    //           resolve(xhr.responseText);
    //         } else {
    //           reject('failed');
    //         }
    //     });
    //   }


function getCustomers4()
    {



        return $http.get('http://localhost:52819/api/customers/GetCustomers')
        
                   .then(
                      function (response) {
                        return response.data;
                        // return {
                        //    title: response.data.title,
                        //    cost:  response.data.price
                        // };
                      },

                      function (httpError) {
                         // translate the error
                         throw httpError.status + " : " + 
                               httpError.data;
                        // return httpError.status + " : " + 
                        // httpError.data;
                      });
            }


        }
    })();
    