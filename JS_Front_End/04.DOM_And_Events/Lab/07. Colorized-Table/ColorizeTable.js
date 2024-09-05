function colorize() {
    const elementsToColorize = Array.from(document.querySelectorAll("tr:nth-child(even)"));

    console.log(elementsToColorize);

    elementsToColorize.forEach((e) => {
        console.log(e);
        e.style.background = "teal";
    });
}