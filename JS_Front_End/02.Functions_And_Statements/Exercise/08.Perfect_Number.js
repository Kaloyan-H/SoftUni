function isNumberPerfect(number) {
    let divisorsSum = 0;

    for (let i = 1; i <= number / 2; ++i) {
        if (number % i === 0) {
            divisorsSum += i;
        }
    }

    divisorsSum === number ? console.log("We have a perfect number!") : console.log("It's not so perfect.");
}