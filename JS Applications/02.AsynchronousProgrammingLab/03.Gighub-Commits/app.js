function loadCommits() {
    const username = document.getElementById('username');
    const repo = document.getElementById('repo');
    const ulList = document.getElementById('commits');
    ulList.innerHTML = '';

    const url = `https://api.github.com/repos/${username.value}/${repo.value}/commits`;

    fetch(url)
        .then((response) => {
            if (!response.ok) {
                throw response;
            }

            return response.json()
        })
        .then((data) => data.forEach(commit => {
            const li = document.createElement('li');
            li.textContent = `${commit.commit.author.name}: ${commit.commit.message}`;
            ulList.appendChild(li);
        }))
        .catch((err) => {
            const li = document.createElement('li');
            err.json().then(x => li.textContent = `Error: ${err.status} (${x.message})`);
            ulList.appendChild(li);
        });
}