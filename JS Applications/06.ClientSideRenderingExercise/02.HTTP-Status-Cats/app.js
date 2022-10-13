import { html, render } from '../node_modules/lit-html/lit-html.js';
import { cats } from './catSeeder.js';

const catsSection = document.getElementById('allCats');

const template = (cats) => html`<ul>${cats.map(catTemplate)}</ul>`;
const catTemplate = (cat) => html`
    <li>
        <img src="./images/${cat.imageLocation}.jpg" width="250" height="250" alt="Card image cap">
        <div class="info">
            <button @click=${showDetails} class="showBtn">Show status code</button>
            <div class="status" style="display: none" id=${cat.id}>
                <h4>Status Code: ${cat.statusCode}</h4>
                <p>${cat.statusMessage}</p>
            </div>
        </div>
    </li>`;

function showDetails(ev) {
    const statusDiv = ev.target.parentNode.querySelector('.status');

    if (ev.target.textContent.includes('Show')) {
        statusDiv.style.display = 'block';
        ev.target.textContent = 'Hide status code';
    } else {
        statusDiv.style.display = 'none';
        ev.target.textContent = 'Show status code';
    }
}

render(template(cats), catsSection);