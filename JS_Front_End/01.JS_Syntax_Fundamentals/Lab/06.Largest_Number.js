function findLargestNumber(numberOne, numberTwo, numberThree) {
    let numbers = [numberOne, numberTwo, numberThree];

    let largestNumber = numbers[0];

    for (let i = 1; i < numbers.length; i++) {
        if (numbers[i] > largestNumber) {
            largestNumber = numbers[i];
        }
    }

    console.log(`The largest number is ${largestNumber}.`);
}

findLargestNumber(5, -3, 16);
findLargestNumber(-3, -5, -22.5);