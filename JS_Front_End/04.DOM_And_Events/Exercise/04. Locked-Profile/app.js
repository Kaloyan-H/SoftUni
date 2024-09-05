function lockedProfile() {
    const buttons = Array.from(document.querySelectorAll("div.profile>button"));

    buttons.forEach((button) => {
        button.addEventListener("click", (e) => {
            const radioButtons = Array.from(e.target.parentElement.querySelectorAll("input"))
            .filter((element) => {
                if (element.type === "radio") {
                    return true;
                }
            });

            if (radioButtons[1].checked) {
                const hiddenDiv = e.target.parentElement.querySelector("div");

                if (e.target.textContent === "Show more") {
                    hiddenDiv.style.display = "block";
                    e.target.textContent = "Hide it";
                } else if (e.target.textContent === "Hide it") {
                    hiddenDiv.style.display = "none";
                    e.target.textContent = "Show more";
                }
            }
        });
    });
}