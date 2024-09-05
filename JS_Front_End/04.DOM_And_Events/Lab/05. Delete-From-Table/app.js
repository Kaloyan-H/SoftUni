function deleteByEmail() {
    const emailToRemove = document.querySelector("input").value;

    const elementsToRemove = Array.from(document.querySelectorAll("td:nth-child(2)")).filter((element) => {
        return element.textContent === emailToRemove;
    });

    if (elementsToRemove.length) {
        elementsToRemove.forEach((element) => {
            element.parentNode.remove();
        });
        document.querySelector("#result").textContent = "Deleted.";
    } else {
        document.querySelector("#result").textContent = "Not found.";
    }
}