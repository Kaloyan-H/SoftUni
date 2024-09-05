function repeatString(string, number) {
    let output = "";

    for (let i = 0; i < number; i++) {
        output += string;
    }

    console.log(output);
}

repeatString("abc", 3);