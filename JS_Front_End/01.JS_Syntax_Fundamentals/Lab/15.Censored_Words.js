function censorText(text, wordToCensor) {
    let censoredText = text.replace(wordToCensor, "*".repeat(wordToCensor.length));
    while(censoredText.includes(wordToCensor)) {
        censoredText = censoredText.replace(wordToCensor, "*".repeat(wordToCensor.length));
    }
    console.log(censoredText);
}

censorText('Find the hidden word', 'hidden');