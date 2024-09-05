function toggle() {
    const button = document.querySelector(".head .button");
    const extraDiv = document.querySelector("#extra");

    if (button.textContent === "More") {
        extraDiv.style.display = "block";
        button.textContent = "Less";
    } else if (button.textContent === "Less") {
        extraDiv.style.display = "none";
        button.textContent = "More";
    }
}