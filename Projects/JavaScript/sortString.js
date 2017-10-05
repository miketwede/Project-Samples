
// var returnValue = SortString(null);
// console.log("Input : ", "null");
// console.log("returnValue : ", returnValue);

// var returnValue = SortString(undefined);
// console.log("Input : ", "undefined");
// console.log("returnValue : ", returnValue);

// var returnValue = SortString("");
// console.log("Input : ", "empty string");
// console.log("returnValue : ", returnValue);

// var returnValue = SortString("abcd");
// console.log("Input : ", "abcd");
// console.log("returnValue : ", returnValue);

// var returnValue = SortString("1234567890");
// console.log("Input : ", "1234567890");
// console.log("returnValue : ", returnValue);

// var returnValue = SortString("gfdgs!@#%#$#%&)*");
// console.log("Input : ", "gfdgs!@#%#$#%&)*");
// console.log("returnValue : ", returnValue);


function SortString(inputString) {
	
	// input validations
	if (!inputString)
		return inputString;

	let testString = inputString;
	let sortedString = "";

	console.log("-----------------------------------------------------------------------------");
	console.log("originalTestString : " + inputString);
	console.log("testString : " + testString);
	console.log("sortedString : " + sortedString);
	console.log("-----------------------------------------------------------------------------");

	// initialize variables
	let smallestCharacter = testString[0];
	let smallestCharacterIndex = 0;


    // Happy path
	do
	{
		// initialize variables for the test string.
		smallestCharacter = testString[0];
		smallestCharacterIndex = 0;

		// Find the smallest character in the string
		for (var i = 0; i < testString.length; i++)
		{
			if (testString[i] < smallestCharacter)
			{
				smallestCharacter = testString[i];
				smallestCharacterIndex = i;
			}
		}

		// build up the sorted string.
		sortedString += smallestCharacter;

		// truncate the test string
		if (smallestCharacterIndex == 0){
			testString = testString.slice(1);
			
		}
		else
		if(smallestCharacterIndex == testString.length-1){
			testString = testString.slice(0, testString.length-1);
			
		}
		else{
			// testString = testString.slice(0, smallestCharacterIndex-1) + testString.slice(smallestCharacterIndex+1);
			testString = testString.slice(0, smallestCharacterIndex) + testString.slice(smallestCharacterIndex+1);
			
		}
	} while (testString.length > 0);


    return sortedString;
    }

	


			
			