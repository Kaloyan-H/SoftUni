function sortNames(array) {
    array.sort(function (a, b) {
        if (a.toLowerCase() < b.toLowerCase()) {
          return -1;
        }
        if (a.toLowerCase() > b.toLowerCase()) {
          return 1;
        }
        return 0;
    });

    for (let i = 0; i < array.length; i++) {
        console.log(`${i + 1}.${array[i]}`);
    }
}

sortNames(["John", "Bob", "Christina", "Ema"]);