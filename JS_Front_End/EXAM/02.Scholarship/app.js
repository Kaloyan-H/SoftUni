window.addEventListener("load", solve);

function solve() {
    const nextButton = document.querySelector("#next-btn");

    nextButton.addEventListener("click", (e) => {
        const studentInput = document.querySelector("#student");
        const univesityInput = document.querySelector("#university");
        const scoreInput = document.querySelector("#score");

        const student = studentInput.value;
        const univesity = univesityInput.value;
        const score = scoreInput.value;

        if (student !== "" && univesity !== "" && score !== "") {
            const previewList = document.querySelector("#preview-list");

            const listItem = document.createElement("li");
            listItem.className = "application";

            const article = document.createElement("article");

            const h4 = document.createElement("h4");
            h4.textContent = student;
            const universityParagraph = document.createElement("p");
            universityParagraph.textContent = `University: ${univesity}`;
            const scoreParagraph = document.createElement("p");
            scoreParagraph.textContent = `Score: ${score}`;

            article.appendChild(h4);
            article.appendChild(universityParagraph);
            article.appendChild(scoreParagraph);

            const editButton = document.createElement("button");
            editButton.className = "action-btn edit";
            editButton.textContent = "edit";
            editButton.addEventListener("click", (e) => {
                const student =
                    document.querySelector("li.application h4").textContent;
                const univesity = document
                    .querySelector("li.application p:nth-of-type(1)")
                    .textContent.split(" ")[1];
                const score = document
                    .querySelector("li.application p:nth-of-type(2)")
                    .textContent.split(" ")[1];

                const studentInput = document.querySelector("#student");
                const univesityInput = document.querySelector("#university");
                const scoreInput = document.querySelector("#score");

                studentInput.value = student;
                univesityInput.value = univesity;
                scoreInput.value = score;

                document.querySelector("#preview-list").innerHTML = "";

                document.querySelector("#next-btn").disabled = false;
            });

            const applyButton = document.createElement("button");
            applyButton.className = "action-btn apply";
            applyButton.textContent = "apply;";
            applyButton.addEventListener("click", (e) => {
                const student =
                    document.querySelector("li.application h4").textContent;
                const univesity = document
                    .querySelector("li.application p:nth-of-type(1)")
                    .textContent.split(" ")[1];
                const score = document
                    .querySelector("li.application p:nth-of-type(2)")
                    .textContent.split(" ")[1];

                const candidatesList =
                    document.querySelector("#candidates-list");

                const listItem = document.createElement("li");
                listItem.className = "application";

                const article = document.createElement("article");

                const h4 = document.createElement("h4");
                h4.textContent = student;
                const universityParagraph = document.createElement("p");
                universityParagraph.textContent = `University: ${univesity}`;
                const scoreParagraph = document.createElement("p");
                scoreParagraph.textContent = `Score: ${score}`;

                article.appendChild(h4);
                article.appendChild(universityParagraph);
                article.appendChild(scoreParagraph);

                listItem.appendChild(article);

                candidatesList.appendChild(listItem);

                document.querySelector("#preview-list").innerHTML = "";

                document.querySelector("#next-btn").disabled = false;
            });

            listItem.appendChild(article);
            listItem.appendChild(editButton);
            listItem.appendChild(applyButton);

            previewList.appendChild(listItem);

            e.target.disabled = "true";

            studentInput.value = "";
            univesityInput.value = "";
            scoreInput.value = "";
        }
    });
}
