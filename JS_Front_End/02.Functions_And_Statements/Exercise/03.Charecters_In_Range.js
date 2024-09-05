function printCharactersInRange(char1, char2) {
    let firstCharCode;
    let secondCharCode;

    let charactersInRange = [];

    if (char1.charCodeAt(0) <= char2.charCodeAt(0)) {
        firstCharCode = char1.charCodeAt(0);
        secondCharCode = char2.charCodeAt(0);
    } else {
        firstCharCode = char2.charCodeAt(0);
        secondCharCode = char1.charCodeAt(0);
    }

    for (let i = firstCharCode + 1; i < secondCharCode; i++) {
        charactersInRange.push(String.fromCharCode(i));
    }

    console.log(charactersInRange.join(" "));
}

printCharactersInRange("a", "d");
printCharactersInRange("d", "a");
printCharactersInRange("#", ":");