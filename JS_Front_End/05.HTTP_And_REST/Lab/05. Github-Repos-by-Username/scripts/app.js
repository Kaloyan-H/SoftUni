function loadRepos() {
  const usernameInput = document.querySelector("#username");
  const username = usernameInput.value;

  const githubAccessToken = "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";

  const headers = new Headers();
  headers.append("Authorization", `token ${githubAccessToken}`);

  const githubUrl = `https://api.github.com/users/${username}/repos`;

  fetch(githubUrl, { headers })
    .then((res) => {
      if (!res.ok) {
        throw new Error("Network response was not ok");
      }
      return res.json();
    })
    .then((res) => {
      const list = document.querySelector("#repos");
      list.innerHTML = "";

      res.forEach((element) => {
        const listItem = document.createElement("li");
        const anchor = document.createElement("a");
        anchor.href = element.html_url;
        anchor.textContent = element.full_name;
        listItem.appendChild(anchor);

        list.appendChild(listItem);
      });
    })
    .catch((err) => console.error("Error fetching repositories:", err));
}
