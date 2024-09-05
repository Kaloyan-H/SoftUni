function printEveryNthElement(array, n) {
    let outputArray = [];

    for (i = 0; i < array.length; i += n) {
        outputArray.push(array[i]);
    }

    return outputArray;
}