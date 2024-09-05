function attachEvents() {
    const loadButton = document.querySelector("#btnLoad");
    const createButton = document.querySelector("#btnCreate");

    loadButton.addEventListener("click", loadPhoneBook);

    createButton.addEventListener("click", async (e) => {
        const personNameInput = document.querySelector("#person");
        const phoneNumberInput = document.querySelector("#phone");
        const personName = personNameInput.value;
        const phoneNumber = phoneNumberInput.value;
        personNameInput.value = "";
        phoneNumberInput.value = "";

        if (personName !== "" && phoneNumber !== "") {
            try {
                await (
                    await fetch("http://localhost:3030/jsonstore/phonebook", {
                        method: "POST",
                        body: JSON.stringify({
                            person: personName,
                            phone: phoneNumber,
                        }),
                    })
                ).json();
            } catch (error) {
                console.log("Error");
                return;
            }

            await loadPhoneBook(e);
        }
    });

    async function loadPhoneBook(e) {
        const phonebookEntries = await (
            await fetch("http://localhost:3030/jsonstore/phonebook")
        ).json();

        const phonebookEntryList = document.querySelector("#phonebook");
        phonebookEntryList.innerHTML = "";

        Object.entries(phonebookEntries).forEach(([key, phonebookEntry]) => {
            const listItem = document.createElement("li");
            listItem.textContent = `${phonebookEntry.person}: ${phonebookEntry.phone}`;
            listItem.id = key;
            const deleteButton = document.createElement("button");
            deleteButton.textContent = "Delete";
            deleteButton.addEventListener("click", async (e) => {
                await fetch(
                    `http://localhost:3030/jsonstore/phonebook/${key}`,
                    {
                        method: "DELETE",
                    }
                );

                // document.querySelector(`li[id="${key}"]`).remove();
                document.querySelector(`#${key}`).remove(); // -----> I don't know why this doesn't work
            });
            listItem.appendChild(deleteButton);

            phonebookEntryList.appendChild(listItem);
        });
    }
}

attachEvents();

// ^ MY CODE ^

// function attachEvents() {
//     const loadBtn = document.getElementById("btnLoad");
//     const phonebookUl = document.getElementById("phonebook");
//     const createBtn = document.getElementById("btnCreate");
//     const personInput = document.getElementById("person");
//     const phoneInput = document.getElementById("phone");
//     const BASE_URL = "http://localhost:3030/jsonstore/phonebook";

//     loadBtn.addEventListener("click", loadPhonebook);
//     createBtn.addEventListener("click", addPhoneNumber);
//     let phonebookData = {};

//     async function loadPhonebook() {
//         try {
//             const response = await fetch(BASE_URL);
//             const data = await response.json();
//             phonebookData = data;
//             phonebookUl.innerHTML = "";
//             for (const key in data) {
//                 const person = data[key]["person"];
//                 const phoneNumber = data[key]["phone"];
//                 const li = document.createElement("li");
//                 const button = document.createElement("button");
//                 button.textContent = "Delete";
//                 button.id = data[key]["_id"];
//                 button.addEventListener("click", deleteNumber);
//                 li.textContent = `${person}: ${phoneNumber}`;
//                 li.appendChild(button);
//                 phonebookUl.appendChild(li);
//             }
//         } catch (e) {
//             console.log(e.status);
//         }
//     }

//     async function deleteNumber() {
//         const id = this.id;
//         const httpHeaders = {
//             method: "DELETE",
//         };

//         await fetch(`${BASE_URL}/${id}`, httpHeaders);
//         await loadPhonebook();
//     }

//     async function addPhoneNumber() {
//         const person = personInput.value;
//         const phone = phoneInput.value;

//         const httpHeaders = {
//             method: "POST",
//             body: JSON.stringify({
//                 person,
//                 phone,
//             }),
//         };

//         await fetch(BASE_URL, httpHeaders);
//         await loadPhonebook();

//         personInput.value = "";
//         phoneInput.value = "";
//     }
// }

// attachEvents();
