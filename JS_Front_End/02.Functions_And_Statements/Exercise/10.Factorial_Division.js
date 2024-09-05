function calculateFactorial(num1, num2) {
    let num1Factorial = 1;
    let num2Factorial = 1;

    for (let i = 2; i <= num1; i++) {
        num1Factorial *= i;
    }
    for (let i = 2; i <= num2; i++) {
        num2Factorial *= i;
    }

    console.log((num1Factorial / num2Factorial).toFixed(2));
}

calculateFactorial(5, 2);