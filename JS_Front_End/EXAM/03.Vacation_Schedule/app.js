window.addEventListener("load", solve);

async function solve() {
    document
        .querySelector("#load-vacations")
        .addEventListener("click", loadVacations);

    document
        .querySelector("#add-vacation")
        .addEventListener("click", async (e) => {
            const nameInput = document.querySelector("#name");
            const daysInput = document.querySelector("#num-days");
            const dateInput = document.querySelector("#from-date");

            const name = nameInput.value;
            const days = String(daysInput.value);
            const date = String(dateInput.value);

            console.log(
                JSON.stringify({
                    date: date,
                    days: days,
                    name: name,
                })
            );

            await fetch("http://localhost:3030/jsonstore/tasks/", {
                method: "POST",
                body: JSON.stringify({
                    date: date,
                    days: days,
                    name: name,
                }),
            });

            nameInput.value = "";
            daysInput.value = "";
            dateInput.value = "";

            await loadVacations();
        });
}

async function loadVacations() {
    const vacations = await (
        await fetch("http://localhost:3030/jsonstore/tasks/")
    ).json();

    const list = document.querySelector("#list");
    list.innerHTML = "";

    Object.values(vacations).forEach((vacationObject) => {
        const name = vacationObject["name"];
        const date = vacationObject["date"];
        const days = vacationObject["days"];
        const id = vacationObject["_id"];

        const containerDiv = document.createElement("div");
        containerDiv.className = "container";
        containerDiv.id = id;

        const h2 = document.createElement("h2");
        h2.textContent = name;
        const dateH3 = document.createElement("h3");
        dateH3.textContent = date;
        const daysH3 = document.createElement("h3");
        daysH3.textContent = days;
        const changeButton = document.createElement("button");
        changeButton.className = "change-btn";
        changeButton.textContent = "Change";
        changeButton.addEventListener("click", async (e) => {
            const name = e.target.parentNode.querySelector("h2").textContent;
            const date =
                e.target.parentNode.querySelector(
                    "h3:nth-of-type(1)"
                ).textContent;
            const days =
                e.target.parentNode.querySelector(
                    "h3:nth-of-type(2)"
                ).textContent;
            const id = e.target.parentNode.id;

            const nameInput = document.querySelector("#name");
            const daysInput = document.querySelector("#num-days");
            const dateInput = document.querySelector("#from-date");

            nameInput.value = name;
            daysInput.value = days;
            dateInput.value = date;

            e.target.parentNode.remove();

            document.querySelector("#add-vacation").disabled = true;
            const editButton = document.querySelector("#edit-vacation");
            editButton.disabled = false;
            editButton.addEventListener("click", async (e) => {
                const nameInput = document.querySelector("#name");
                const daysInput = document.querySelector("#num-days");
                const dateInput = document.querySelector("#from-date");

                const name = nameInput.value;
                const days = String(daysInput.value);
                const date = String(dateInput.value);

                nameInput.value = "";
                daysInput.value = "";
                dateInput.value = "";

                await fetch(`http://localhost:3030/jsonstore/tasks/${id}`, {
                    method: "PUT",
                    body: JSON.stringify({
                        date: date,
                        days: days,
                        name: name,
                    }),
                });

                await loadVacations();

                e.target.disabled = true;
                document.querySelector("#add-vacation").disabled = false;
            });
        });
        const doneButton = document.createElement("button");
        doneButton.className = "done-btn";
        doneButton.textContent = "Done";
        doneButton.addEventListener("click", async (e) => {
            await fetch(`http://localhost:3030/jsonstore/tasks/${id}`, {
                method: "DELETE",
            });
        });

        containerDiv.appendChild(h2);
        containerDiv.appendChild(dateH3);
        containerDiv.appendChild(daysH3);
        containerDiv.appendChild(changeButton);
        containerDiv.appendChild(doneButton);

        list.appendChild(containerDiv);
        // NE moga sega
    });
}
