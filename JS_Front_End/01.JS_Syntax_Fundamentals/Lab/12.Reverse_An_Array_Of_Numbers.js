function reverseArray(n, inputArray) {
    let array = [];

    for(let i = n - 1; i >= 0; i--) {
        array.push(inputArray[i]);
    }

    let output = array.join(" ");

    console.log(output);
}

reverseArray(3, [10, 20, 30, 40, 50]);
reverseArray(4, [-1, 20, 99, 5]);
reverseArray(2, [66, 43, 75, 89, 47]);