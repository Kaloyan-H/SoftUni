function printEvenAndOddSum(number) {
    let oddSum = 0;
    let evenSum = 0;

    while (number > 0) {
        let tempDigit = number % 10;

        if (tempDigit % 2 === 0) {
            evenSum += tempDigit;
        } else {
            oddSum += tempDigit;
        }

        number = Math.floor(number / 10);
    }

    console.log(`Odd sum = ${oddSum}, Even sum = ${evenSum}`);
}

printEvenAndOddSum(1000435);