function solve(numberOne, numberTwo, operation) {

    let output;

    switch(operation) {
        case "+":
            output = numberOne + numberTwo;
            break;
        case "-":
            output = numberOne - numberTwo;
            break;
        case "*":
            output = numberOne * numberTwo;
            break;
        case "/":
            output = numberOne / numberTwo;
            break;
        case "%":
            output = numberOne % numberTwo;
            break;
        case "**":
            output = numberOne ** numberTwo;
            break;
    }

    console.log(output);
}

solve(5, 6, "+");
solve(3, 5.5, "*");