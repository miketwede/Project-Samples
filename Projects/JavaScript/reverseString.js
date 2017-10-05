
var returnValue = ReverseString(null);
console.log("Input : ", "null");
console.log("returnValue : ", returnValue);

var returnValue = ReverseString(undefined);
console.log("Input : ", "undefined");
console.log("returnValue : ", returnValue);

var returnValue = ReverseString("");
console.log("Input : ", "empty string");
console.log("returnValue : ", returnValue);

var returnValue = ReverseString("abcd");
console.log("Input : ", "abcd");
console.log("returnValue : ", returnValue);

var returnValue = ReverseString("1234567890");
console.log("Input : ", "1234567890");
console.log("returnValue : ", returnValue);

var returnValue = ReverseString("gfdgs!@#%#$#%&)*");
console.log("Input : ", "gfdgs!@#%#$#%&)*");
console.log("returnValue : ", returnValue);


function ReverseString(inputString) {
    let output = "";

    // input validations
    if (!inputString)
        return inputString;

   // for (var i = 0; i<= string.length-1; i++) {
    //    if (string.charCodeAt(i) < 48 || string.charCodeAt(i) > 57)
     //       return NaN;	
    //    }

    // Happy path
			for (var i = inputString.length-1; i >= 0; i--)
			{
				output += inputString[i];
			}

    return output;
    }
