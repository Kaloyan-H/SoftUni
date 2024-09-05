function sumFirstAndLastElements(array) {
    let firstElement = array[0];
    let lastElement = array[array.length - 1];

    console.log(firstElement + lastElement);
}

sumFirstAndLastElements([20, 30, 40]);
sumFirstAndLastElements([10, 17, 22, 33]);
sumFirstAndLastElements([11, 58, 69]);