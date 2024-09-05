function checkLeapYear(year) {
    let output;

    if ((year % 4 === 0 && year % 100 !== 0) || year % 400 === 0) {
        output = "yes";
    }
    else {
        output = "no";
    }

    console.log(output);
}

checkLeapYear(1984);
checkLeapYear(2003);
checkLeapYear(4);
checkLeapYear(100);
checkLeapYear(400);