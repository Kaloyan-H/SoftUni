function attachEvents() {
    const refreshButton = document.querySelector("#refresh");
    const sendButton = document.querySelector("#submit");

    refreshButton.addEventListener("click", async (e) => {
        const messages = await (
            await fetch("http://localhost:3030/jsonstore/messenger")
        ).json();

        const messageBox = document.querySelector("#messages");

        const formattedMessages = Object.values(messages).map(
            (message) => `${message.author}: ${message.content}`
        );

        messageBox.textContent = formattedMessages.join("\n");
    });

    sendButton.addEventListener("click", async (e) => {
        const author = document.querySelector('input[name="author"').value;
        const content = document.querySelector('input[name="content"').value;

        fetch("http://localhost:3030/jsonstore/messenger", {
            method: "POST",
            body: JSON.stringify({ author, content }),
        });
    });
}

attachEvents();
