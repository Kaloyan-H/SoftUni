function rotateArray(array, numberOfRotations) {
    for (i = 1; i <= numberOfRotations; i ++) {
        let arrayElement = array.shift();
        array.push(arrayElement);
    }

    console.log(array.join(" "));
}

rotateArray([51, 47, 32, 61, 21], 2);