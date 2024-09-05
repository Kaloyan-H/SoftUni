function findSpecialWords(text) {
    let textArray = text.split(" ");

    let validSpecialWords = [];

    for (let i = 0; i < textArray.length; i++) {
        if (textArray[i][0] === "#") {
            let specialWord = textArray[i].substring(1, textArray[i].length);

            if (/^[a-zA-Z]+$/.test(specialWord)) {
                validSpecialWords.push(specialWord);
            }
        }
    }

    validSpecialWords.forEach(word => {
        console.log(word);
    });
}

findSpecialWords('Nowadays everyone uses # to tag a #special word in #socialMedia');
findSpecialWords('The symbol # is known #variously in English-speaking #regions as the #number sign');