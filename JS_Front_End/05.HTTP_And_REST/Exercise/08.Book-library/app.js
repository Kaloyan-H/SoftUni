function attachEvents() {
    const loadBtn = document.getElementById("loadBooks");
    const bookTable = document.querySelector("table > tbody");
    const [titleInput, authorInput] = Array.from(
        document.querySelectorAll("#form input")
    );
    const submitBtn = document.querySelector("#form button");
    const formHeading = document.querySelector("#form h3");

    const BASE_URL = "http://localhost:3030/jsonstore/collections/books/";
    let editBookId = null;

    loadBtn.addEventListener("click", loadBooksHandler);
    submitBtn.addEventListener("click", createBookHandler);

    async function loadBooksHandler() {
        bookTable.innerHTML = "";
        const response = await fetch(BASE_URL);
        const data = await response.json();
        for (const key in data) {
            const { author, title } = data[key];
            const tr = createElement("tr", "", bookTable);
            const titleTd = createElement("td", title, tr);
            const authorTd = createElement("td", author, tr);
            const btnTr = createElement("td", "", tr);
            const editBtn = createElement("button", "Edit", btnTr, key);
            editBtn.addEventListener("click", () => {
                editBookId = key;
                formHeading.textContent = "Edit FORM";
                submitBtn.textContent = "Save";
                titleInput.value = title;
                authorInput.value = author;
            });
            const deleteBtn = createElement("button", "Delete", btnTr, key);
            deleteBtn.addEventListener("click", deleteBookHandler);
        }
    }

    async function createBookHandler() {
        const title = titleInput.value;
        const author = authorInput.value;

        const httpHeaders = {
            method: "POST",
            body: JSON.stringify({
                title,
                author,
            }),
        };
        let url = BASE_URL;

        if (formHeading.textContent === "Edit FORM") {
            httpHeaders.method = "PUT";
            url += editBookId;
        }

        const response = await fetch(url, httpHeaders);
        await loadBooksHandler();
        if (formHeading.textContent === "Edit FORM") {
            submitBtn.textContent = "Submit";
            formHeading.textContent = "FORM";
        }
        titleInput.value = "";
        authorInput.value = "";
    }

    async function deleteBookHandler() {
        const id = this.id;
        const httpHeaders = {
            method: "DELETE",
        };

        await fetch(BASE_URL + id, httpHeaders);
        await loadBooksHandler();
    }

    function createElement(type, content, parentNode, id, classes, attrs) {
        const htmlElement = document.createElement(type);

        if (content && type !== "input") {
            htmlElement.textContent = content;
        }

        if (content && type === "input") {
            htmlElement.value = content;
        }

        if (id) {
            htmlElement.id = id;
        }

        if (classes) {
            htmlElement.classList.add(...classes);
        }

        if (parentNode) {
            parentNode.appendChild(htmlElement);
        }

        if (attrs) {
            for (const key in attrs) {
                htmlElement.setAttribute(key, attrs[key]);
            }
        }

        return htmlElement;
    }
}

attachEvents();
