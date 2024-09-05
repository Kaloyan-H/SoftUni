function determineAgeRange(age) {
    let output;

    if (age >= 66) {
        output = "elder";
    } else if (age >= 20) {
        output = "adult";
    } else if (age >= 14) {
        output = "teenager";
    } else if (age >= 3) {
        output = "child";
    } else if (age >= 0) {
        output = "baby";
    } else {
        output = "out of bounds";
    }

    console.log(output);
}

determineAgeRange(20);
determineAgeRange(1);
determineAgeRange(100);
determineAgeRange(-1);