function cookNumbers(number, operationOne, operationTwo, operationThree, operationFour, operationFive) {
    let operationArray = [operationOne, operationTwo, operationThree, operationFour, operationFive];

    number = parseFloat(number);

    for (let i = 0; i < 5; i++) {
        switch (operationArray[i]) {
            case "chop":
                number /= 2;
                break;
            case "dice":
                number = Math.sqrt(number);
                break;
            case "spice":
                number++;
                break;
            case "bake":
                number *= 3;
                break;
            case "fillet":
                number *= 0.8;
                break;
        }

        console.log(number);
    }
}

cookNumbers('32', 'chop', 'chop', 'chop', 'chop', 'chop');
cookNumbers('9', 'dice', 'spice', 'chop', 'bake', 'fillet');