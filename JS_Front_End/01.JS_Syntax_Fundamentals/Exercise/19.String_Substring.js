function findWordInText(word, text) {
    lowerCaseWord = word.toLowerCase();
    lowerCaseText = text.toLowerCase();
    let textArray = lowerCaseText.split(" ");

    if (textArray.includes(lowerCaseWord)) {
        console.log(word);
    } else {
        console.log(`${word} not found!`);
    }
}

findWordInText('jAVAscRIpt', 'JavaScript is the best programming language');
findWordInText('python', 'JavaScript is the best programming language');