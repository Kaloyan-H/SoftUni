function printSmallestNumber(firstNumber, secondNumber, thirdNumber) {
    let numbers = [firstNumber, secondNumber, thirdNumber];
    let smallestNumber = numbers[0];

    for (let i = 1; i < numbers.length; i++) {
        if (numbers[i] < smallestNumber) {
            smallestNumber = numbers[i];
        }
    }

    console.log(smallestNumber);
}