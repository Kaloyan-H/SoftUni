function trackWordOccurences(input) {
    const wordsToLookFor = input.shift().split(" ");

    const wordsCounter = wordsToLookFor.reduce((acc, curr) => {
        acc[curr] = 0;
        return acc;
    }, {});

    for (let i = 0; i < input.length; i++) {
        for (let j = 0; j < wordsToLookFor.length; j++) {
            if (input[i] === wordsToLookFor[j]) {
                wordsCounter[wordsToLookFor[j]]++;
            }
        }
    }

    Object.entries(wordsCounter).sort((a, b) => {
        return b[1] - a[1];
    }).forEach(([key, value]) => {
        console.log(`${key} - ${value}`);
    });
}

trackWordOccurences([
    'this sentence',
    'In', 'this', 'sentence', 'you', 'have', 'to', 'count', 'the', 'occurrences', 'of', 'the', 'words', 'this', 'and', 'sentence', 'because', 'this', 'is', 'your', 'task'
    ]);