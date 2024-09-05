function splitPascalCaseText(text) {
    let textCharacters = text.split("");
    let word = "";
    let words = [];

    for (let i = 0; i < textCharacters.length; i++) {
        if (i !== 0 && /^[A-Z]$/.test(textCharacters[i])) {
            words.push(word);
            word = "";
        } else if (i === textCharacters.length - 1) {
            word += textCharacters[i];
            words.push(word);
            break;
        }

        word += textCharacters[i];
    }

    console.log(words.join(", "));
}

function splitPascalCaseTextTwo(text) {
    let textCharacters = text.split("");
    let word = "";
    let words = [];

    for (let i = 0; i < textCharacters.length; i++) {
        if (i === textCharacters.length - 1) {
            if (/^[A-Z]$/.test(textCharacters[i])) {
                words.push(word);
                word = "";
                word += textCharacters[i];
                words.push(word);
            } else {
                word += textCharacters[i];
                words.push(word);
            }
            break;
        } else if (i !== 0 && /^[A-Z]$/.test(textCharacters[i])) {
            words.push(word);
            word = "";
        }

        word += textCharacters[i];
    }

    console.log(words.join(", "));
}

splitPascalCaseText('ThisIsSoAnnoyingToDo');
splitPascalCaseText('iAmRightAmI')
splitPascalCaseTextTwo('ThisIsSoAnnoyingToDo');
splitPascalCaseTextTwo('iAmRightAmI')