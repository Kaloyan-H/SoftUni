function addItem() {
    const newItemText = document.querySelector("#newItemText");
    const newItemValue = document.querySelector("#newItemValue");

    const option = document.createElement("option");
    option.textContent = newItemText.value;
    option.value = newItemValue.value;

    const select = document.querySelector("#menu");
    select.appendChild(option);

    newItemText.value = "";
    newItemValue.value = "";
}