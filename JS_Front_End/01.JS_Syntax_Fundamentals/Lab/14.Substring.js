function printSubstring(text, startIndex, endIndex) {
    let result = text.substr(startIndex, endIndex);

    console.log(result);
}

printSubstring("ASentence", 1, 8);