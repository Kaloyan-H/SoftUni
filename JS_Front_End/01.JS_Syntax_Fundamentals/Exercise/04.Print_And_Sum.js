function printAndSum(firstNumber, secondNumber) {
    let sum = 0;
    let array = [];

    for (let i = firstNumber; i <= secondNumber; i++) {
        sum += i;
        array.push(i);
    }

    console.log(array.join(" "));
    console.log(`Sum: ${sum}`);
}

printAndSum(5, 10);
printAndSum(0, 26);