function calculate(firstNumber, secondNumber, operation) {
    let result;
    
    switch (operation) {
        case "multiply":
            result = firstNumber * secondNumber;
            break;
        case "divide":
            result = firstNumber / secondNumber;
            break;
        case "add":
            result = firstNumber + secondNumber;
            break;
        case "subtract":
            result = firstNumber - secondNumber;
            break;
    }

    console.log(result);
}