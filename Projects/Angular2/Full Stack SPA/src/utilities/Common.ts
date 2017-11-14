//var dateFormat = require('dateformat');
//import "./accounting.js";
import * as accounting from "accounting";
import * as dateFormat from "dateformat";
export class Common {
    formatDate(dateToFormat, format) {
        return dateFormat(dateToFormat, format);
       }
     
    formatCurrency(currencyToFormat, format = null) {
        if (format) {
         return accounting.formatMoney(currencyToFormat, format);
         }
         else {
             return accounting.formatMoney(currencyToFormat); 
         }
     
     }
     
     unFormatCurrency(stringCurrency) {
        if (stringCurrency) {
            var tempCurrency = stringCurrency.substring(1);
            var tempNumber = parseFloat(tempCurrency.replace(/,/g, ''));
         return tempNumber;
         }
         else {
             return 0.0; 
         }
     
     }
     
     formatName(person)
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
     
         formatAddress(person)
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
     
}










