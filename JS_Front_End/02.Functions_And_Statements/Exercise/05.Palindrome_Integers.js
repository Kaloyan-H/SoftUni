function checkPalindromeIntegers(numbersArray) {
    for (let i = 0; i < numbersArray.length; i++) {
        let numberString = numbersArray[i].toString();
        let flag = true;

        for (let j = 0; j < Math.floor((numberString.length) / 2); j++) {
            if (numberString[j] !== numberString[numberString.length - 1 - j]) {
                flag = false;
                break;
            }
        }
        
        flag ? console.log("true") : console.log("false");
    }
}

checkPalindromeIntegers([32,2,232,1010]);