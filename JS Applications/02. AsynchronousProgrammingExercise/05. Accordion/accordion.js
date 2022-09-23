async function solution() {
    const main = document.getElementById('main');
    const url = 'http://localhost:3030/jsonstore/advanced/articles/list';

    const response = await fetch(url);
    const data = await response.json();

    data.forEach(a => {
        const article = createArticle(a);
        main.appendChild(article);
    });
}

function createArticle({ _id, title }) {
    const mainDiv = el('div', '', 'accordion');
    const headDiv = el('div', '', 'head');
    const titleSpan = el('span', title);
    const moreBtn = el('button', 'More', 'button');
    const extraDiv = el('div', '', 'extra');
    const contentElement = el('p');

    extraDiv.appendChild(contentElement);
    extraDiv.style.display = 'none';
    moreBtn.id = _id;

    headDiv.appendChild(titleSpan);
    headDiv.appendChild(moreBtn);
    mainDiv.appendChild(headDiv);
    mainDiv.appendChild(extraDiv);

    moreBtn.addEventListener('click', async (ev) => {
        if (extraDiv.style.display == 'none') {
            const response = await fetch(`http://localhost:3030/jsonstore/advanced/articles/details/${_id}`);
            const data = await response.json();

            moreBtn.textContent = 'Less';
            extraDiv.style.display = 'block';
            contentElement.textContent = data.content;
        } else {
            moreBtn.textContent = 'More';
            extraDiv.style.display = 'none';
        }
    });

    return mainDiv;
}

function el(type, content, className) {
    const element = document.createElement(type);
    element.textContent = content;
    element.className = className;

    return element;
}

solution();