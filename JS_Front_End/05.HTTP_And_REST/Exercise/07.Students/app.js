function attachEvents() {
    window.addEventListener("load", loadStudents);
    const submitButton = document.querySelector("#submit");

    submitButton.addEventListener("click", submitStudent);
}

async function submitStudent(e) {
    const firstName = document.querySelector(`input[name="firstName"]`).value;
    const lastName = document.querySelector(`input[name="lastName"]`).value;
    const facultyNumber = document.querySelector(
        `input[name="facultyNumber"]`
    ).value;
    const grade = document.querySelector(`input[name="grade"]`).value;

    if (
        firstName === "" ||
        lastName === "" ||
        facultyNumber === "" ||
        grade === ""
    ) {
        throw new Error("All fields must be filled in.");
    }

    const student = {
        firstName,
        lastName,
        facultyNumber,
        grade,
    };

    await fetch("http://localhost:3030/jsonstore/collections/students", {
        method: "POST",
        body: JSON.stringify(student),
    });

    await loadStudents();
}

async function loadStudents(e) {
    const students = await (
        await fetch("http://localhost:3030/jsonstore/collections/students")
    ).json();

    console.log(students);

    const resultsTableBody = document.querySelector("#results tbody");
    resultsTableBody.innerHTML = "";

    Object.values(students).forEach((student) => {
        const row = document.createElement("tr");
        row.id = student["_id"];

        const firstNameCell = document.createElement("td");
        firstNameCell.textContent = student["firstName"];
        row.appendChild(firstNameCell);

        const lastNameCell = document.createElement("td");
        lastNameCell.textContent = student["lastName"];
        row.appendChild(lastNameCell);

        const facultyNumberCell = document.createElement("td");
        facultyNumberCell.textContent = student["facultyNumber"];
        row.appendChild(facultyNumberCell);

        const gradeCell = document.createElement("td");
        gradeCell.textContent = student["grade"];
        row.appendChild(gradeCell);

        resultsTableBody.appendChild(row);
    });
}

attachEvents();
