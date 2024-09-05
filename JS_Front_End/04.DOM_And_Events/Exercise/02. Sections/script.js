function create(words) {
    const divs = words.map((word) => {
        const div = document.createElement("div");

        const paragraph = document.createElement("p");
        paragraph.textContent = word;
        paragraph.style.display = "none";

        div.addEventListener("click", (e) => {
            e.target.querySelector("p").style.display = "block";
        });

        div.appendChild(paragraph);

        return div;
    });

    const contentDiv = document.querySelector("#content");

    divs.forEach((div) => {
        contentDiv.appendChild(div);
    });
}
