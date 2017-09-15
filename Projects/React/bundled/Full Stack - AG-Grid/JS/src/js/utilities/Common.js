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


