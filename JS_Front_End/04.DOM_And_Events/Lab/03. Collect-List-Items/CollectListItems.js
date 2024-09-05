function extractText() {
    const liValues = Array.from(document.querySelectorAll("li")).map((element) => element.innerHTML);

    console.log(liValues);

    document.getElementById("result").value = liValues.join("\n");
}