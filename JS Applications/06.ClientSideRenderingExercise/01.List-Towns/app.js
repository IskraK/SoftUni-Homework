import { html, render } from '../node_modules/lit-html/lit-html.js';

const loadBtn = document.getElementById('btnLoadTowns');
loadBtn.addEventListener('click', getTowns);

const townsTemplate = (data) => html`
<ul>
    ${data.map(town => html`<li>${town}</li>`)}
</ul>`;

function getTowns(ev) {
    ev.preventDefault();

    const towns = document.getElementById('towns');
    if (towns.value !== '') {
        const root = document.getElementById('root');
        const townsList = towns.value.split(', ');
        const result = townsTemplate(townsList);

        render(result, root);
        towns.value = '';
    }
}
