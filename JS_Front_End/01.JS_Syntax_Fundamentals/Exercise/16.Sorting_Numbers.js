function sortNumbers(array) {
    array.sort(function(a, b) {
        if (a < b) {
            return -1;
          }
          if (a > b) {
            return 1;
          }
          return 0;
    });

    let outputArray = [];
    let arrayLength = array.length;

    for (i = 0; i < arrayLength; i++) {
        if (i % 2 === 0) {
            outputArray.push(array.shift());
        }
        else {
            outputArray.push(array.pop());
        }
    }

    return outputArray;
}

sortNumbers([1, 65, 3, 52, 48, 63, 31, 3, 18, 56]);