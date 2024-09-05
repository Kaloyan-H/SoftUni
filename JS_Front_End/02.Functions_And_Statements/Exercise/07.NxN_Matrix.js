function printNxNMatrix(number) {
    let lineToPrint = `${number} `.repeat(number).trim();

    for (let i = 0; i < number; i++) {
        console.log(lineToPrint);
    }
}