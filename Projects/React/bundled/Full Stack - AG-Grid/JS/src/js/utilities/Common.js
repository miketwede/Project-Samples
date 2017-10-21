 var dateFormat = require('dateformat');
 //import "./accounting.js";
 import accounting from "./accounting.js";
 
 export function formatDate(dateToFormat, format) {
    return dateFormat(dateToFormat, format);
   }

   export function formatCurrency(currencyToFormat, format) {
       if (format) {
        return accounting.formatMoney(currencyToFormat, format);
        }
        else {
            return accounting.formatMoney(currencyToFormat); 
        }
    
   }

   export function formatName(person)
     {
         var fullName = "";
         if (person.title){
            fullName += person.title + " ";
         }
         fullName += person.firstName + " ";
         if (person.middleInitial){
            fullName += person.middleInitial + " ";
         }
         fullName += person.lastName + " ";
         if (person.suffix){
            fullName += person.suffix;
         }
         
        return fullName.trim();
     };

     export function formatAddress(person)
     {
         var fullAddress = "";

         fullAddress += person.address1 + " ";
         if (person.Address2){
            fullAddress += person.address2 + " ";
         }

         fullAddress += person.city + " ";
         fullAddress += person.state + " ";
         fullAddress += person.zip + " ";
         if (person.country){
            fullAddress += person.country;
         }
         
        return fullAddress.trim();
     };
