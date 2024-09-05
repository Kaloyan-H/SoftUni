function printOddOccurrences(input) {
    const words = input.split(" ").map((word) => word.toLowerCase());

    const wordTracker = {};

    words.forEach((word) => {
        if (!wordTracker[word]) {
            wordTracker[word] = 1;
        } else {
            wordTracker[word]++;
        }
    });

    console.log(Object
        .entries(wordTracker)
        .filter(([key, value]) => value % 2 !== 0)
        .map(([key, value]) => key)
        .join(" "));
}

printOddOccurrences('Java C# Php PHP Java PhP 3 C# 3 1 5 C#');