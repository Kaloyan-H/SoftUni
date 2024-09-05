function countStringOccurences(text, wordToCount) {
    let words = text.split(" ");
    let wordOccurences = 0;

    for (let word of words) {
        if (word === wordToCount) {
            wordOccurences++;
        }
    }

    console.log(wordOccurences);
}

countStringOccurences('This is a word and it also is a sentence', 'is');