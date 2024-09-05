function revealWords(templateWords, text) {
    let templateWordsArray = templateWords.split(", ");
    let textArray = text.split(" ");


    for (let i = 0; i < textArray.length; i++) {
        if (textArray[i][0] === "*") {
            for (let j = 0; j < templateWordsArray.length; j++) {
                if (templateWordsArray[j].length === textArray[i].length) {
                    textArray[i] = templateWordsArray[j];
                    break;
                }
            }
        }
    }

    console.log(textArray.join(" "));
}

revealWords('great, learning', 'softuni is ***** place for ******** new programming languages');