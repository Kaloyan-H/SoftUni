function checkIfAllDigitsAreTheSame(number) {
    let numberString = String(number);
    let flag = true
    let firstDigit = numberString[0];
    let digitSum = 0;

    for (let digit of numberString) {
        if (flag && digit !== firstDigit) {
            flag = false;
        }
        digitSum += parseFloat(digit);
    };

    console.log(flag);
    console.log(digitSum);
}

checkIfAllDigitsAreTheSame(2222222);
checkIfAllDigitsAreTheSame(1234);