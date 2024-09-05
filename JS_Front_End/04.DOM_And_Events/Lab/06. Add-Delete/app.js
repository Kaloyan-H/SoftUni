function addItem() {
    const value = document.getElementById("newItemText").value;

    const element = document.createElement("li");
    element.textContent = value;

    const deleteButton = document.createElement("a");
    deleteButton.href = "#";
    deleteButton.textContent = "[Delete]";
    deleteButton.addEventListener("click", (e) => {
        e.target.parentElement.remove();
    });

    element.appendChild(deleteButton);
    document.getElementById("items").appendChild(element);
}