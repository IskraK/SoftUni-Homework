function getArticleGenerator(articles) {
    const output = document.getElementById('content');

    return function () {
        const article = articles.shift();

        if (article != undefined) {
            const element = document.createElement('article');
            element.textContent = article;
            output.appendChild(element);
        }
    }
}
