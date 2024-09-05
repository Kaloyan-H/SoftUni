function printMultiplicationTable(number) {
    for (i = 1; i <= 10; i++) {
        let product = number * i;
        console.log(`${number} X ${i} = ${product}`);
    }
}

printMultiplicationTable(5);
printMultiplicationTable(2);