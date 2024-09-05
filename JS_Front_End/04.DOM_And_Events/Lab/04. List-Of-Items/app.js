function addItem() {
    const textToAdd = document.getElementById("newItemText").value;

    document.getElementById("items").innerHTML += `<li>${textToAdd}</li>`;
}