function solve() {
    const input = {
        name: document.getElementById('task'),
        description: document.getElementById('description'),
        date: document.getElementById('date')
    };

    const [_, openSection, progressSection, finishSection] = Array.from(document.querySelectorAll('section')).map(e => e.children[1]);
    document.getElementById('add').addEventListener('click', addTask);

    function addTask(ev) {
        ev.preventDefault();

        const article = document.createElement('article');
        article.appendChild(createElement('h3', input.name.value));
        article.appendChild(createElement('p', `Description: ${input.description.value}`));
        article.appendChild(createElement('p', `Due Date: ${input.date.value}`));
        const div = createElement('div', '', 'flex');

        const startButton = createElement('button', 'Start', 'green', onStart);
        const deleteButton = createElement('button', 'Delete', 'red', onDelete);
        const finishButton = createElement('button', 'Finish', 'orange', onFinish);

        div.appendChild(startButton);
        div.appendChild(deleteButton);

        article.appendChild(div);

        openSection.appendChild(article);

        Object.values(input).forEach(i => i.value = '');

        function onStart() {
            startButton.remove();
            div.appendChild(finishButton);
            progressSection.appendChild(article);
        }

        function onFinish() {
            div.remove();
            finishSection.appendChild(article);
        }

        function onDelete() {
            article.remove();
        }
    }

    function createElement(type, content, className, eventListener) {
        const element = document.createElement(type);
        element.textContent = content;

        if (className) {
            element.className = className;
        }

        if (eventListener) {
            element.addEventListener('click', eventListener)
        }

        return element;
    }
}