
var returnValue = GetInt(null, 10);
console.log(returnValue);

var returnValue = GetInt(undefined, 10);
console.log(returnValue);

var returnValue = GetInt("", 10);
console.log(returnValue);

var returnValue = GetInt("10a", 10);
console.log(returnValue);

var returnValue = GetInt("103", 10);
console.log(returnValue);

var returnValue = GetInt("1234567890", 10);
console.log(returnValue);


function GetInt(string, radix=10) {
    let returnVal = 0;
    let weight = 0;
    let charValue = 0;

    // input validations
    if (!string)
        return NaN;

    for (var i = 0; i<= string.length-1; i++) {
        if (string.charCodeAt(i) < 48 || string.charCodeAt(i) > 57)
            return NaN;	
        }

    // Happy path
    for (var i = 0; i <= string.length-1; i++) {
        weight = Math.pow(radix, string.length-1 - i);
        charValue = (string.charCodeAt(i) - 48) * weight;
        returnVal += charValue;
    }

    return returnVal;
    }
