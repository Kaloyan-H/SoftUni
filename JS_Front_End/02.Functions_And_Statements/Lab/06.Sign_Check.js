function checkSign(firstNumber, secondNumber, thirdNumber) {
    let numbers = [firstNumber, secondNumber, thirdNumber];
    let negativeCounter = 0;

    for (let i = 0; i < numbers.length; i++) {
        if (numbers[i] < 0) {
            negativeCounter++;
        }
    }

    if (negativeCounter % 2 !== 0) {
        console.log("Negative");
    } else {
        console.log("Positive");
    }
}