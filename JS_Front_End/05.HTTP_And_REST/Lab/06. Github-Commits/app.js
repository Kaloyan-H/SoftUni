function loadCommits() {
  const usernameInput = document.querySelector("#username");
  const username = usernameInput.value;

  const repoInput = document.querySelector("#repo");
  const repo = repoInput.value;

  const githubAccessToken = "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";

  const headers = new Headers();
  headers.append("Authorization", `token ${githubAccessToken}`);

  const githubUrl = `https://api.github.com/repos/${username}/${repo}/commits`;

  const htmlList = document.querySelector("#commits");

  fetch(githubUrl, { headers })
    .then((res) => {
      if (res.status !== 200) {
        throw new Error(`${res.status} (Not Found)`);
      }
      return res.json();
    })
    .then((res) => {
      htmlList.textContent = "";
      res.forEach((element) => {
        console.log(element);
        const listItem = document.createElement("li");
        listItem.textContent = `${element.commit.author.name}: ${element.commit.message}`;

        htmlList.appendChild(listItem);
      });
    })
    .catch((err) => {
      const listItem = document.createElement("li");
      listItem.textContent = err;

      htmlList.appendChild(listItem);
    });
}
