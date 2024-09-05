function loadRepos() {
  const resDiv = document.querySelector("#res");

  fetch("https://api.github.com/users/testnakov/repos")
    .then((res) => {
      return res.text();
    })
    .then((res) => {
      resDiv.textContent = res;
    });
}
