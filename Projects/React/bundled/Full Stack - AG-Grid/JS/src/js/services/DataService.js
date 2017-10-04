import axios from "axios";

// export default class DataService  {

    export function getCustomers() {
        console.log("in  getCustomers()");
        


        // axios({
        //     method:'get',
        //     url:'http://bit.ly/2mTM3nY',
        //     responseType:'stream'
        //   })
        //     .then(function(response) {
        //     response.data.pipe(fs.createWriteStream('ada_lovelace.jpg'))
        //   });

        // Use jQuery to set header Content-Type': 'application/x-www-form-urlencoded; charset=UTF-8', but it doesn't work with my WCF service

// <add name="Access-Control-Allow-Headers" value="Content-Type, X-Your-Extra-Header-Key" />



var config = {
    responseType: 'json'
  };

//   var config = {
//       headers: {'X-My-Custom-Header': 'Header-Value'},
//       responseType: 'json'
//     };
          
        //   axios.get('https://api.github.com/users/codeheaven-io', config);
        //   axios.post('/save', { firstName: 'Marlon' }, config);

       // var api = 'http://localhost:52819/api/customers/GetCustomers';
         var api = 'http://localhost:63131/api/customers/GetCustomers';


        //var api = 'http://localhost:63131/CustomerController/GetCustomers';
       // var api = 'http://localhost:63131/Customer/GetCustomers';
        

       var mike = axios.get(api, config)
       .then(function (response) {
        console.log("response", response);
        console.log("response.data", response.data);
        console.log(response.status);
        console.log(response.statusText);
        console.log(response.headers);
        console.log(response.config);
        return response.data;
       })
       .catch(function (error) {
        console.log("error", error);
      //  return error;
     // throw new Error(error);
      throw error;
    });
   
       return mike;
   }

   export function  getCustomer() {
    
   axios.get('/customer', {
       params: {
           ID: 12345
       }
       })
       .then(function (response) {
        console.log(response);
        return response.data.data;
    })
    .catch(function (error) {
        console.log(error);
        return error;
    });

    return null;
}
  
// }

