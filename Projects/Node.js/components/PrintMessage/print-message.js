var dateFormat = require('./lib/dateFormat');
var stringFormat = require('./lib/stringFormat');

var now = new Date().format("mm/dd/yyyy h:MM:sstt");
module.exports = printDefaultMessage = function() {
  console.log(String.format('[{0}] This is the default message from the print-message module...', now));
}
module.exports = printMessage = function(msg) {
  console.log(String.format('[{0}] {1}', now, msg));
}
