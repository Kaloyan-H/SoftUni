function addAndSubtract(firstNumber, secondNumber, thirdNumber) {
    function sum(firstNumber, secondNumber) {
        return firstNumber + secondNumber;
    }

    function subtract(firstNumber, secondNumber) {
        return firstNumber - secondNumber;
    }
    
    console.log(subtract(sum(firstNumber, secondNumber), thirdNumber));
}

