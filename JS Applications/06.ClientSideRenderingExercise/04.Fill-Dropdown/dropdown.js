import { html, render } from '../node_modules/lit-html/lit-html.js';

const url = 'http://localhost:3030/jsonstore/advanced/dropdown';
const select = document.getElementById('menu');
const form = document.querySelector('form');
form.addEventListener('submit', addItem);

getOptions();

async function getOptions() {
    const response = await fetch(url);
    const data = Object.values(await response.json());

    const optionTemplate = html`${data.map(e => html`<option value=${e._id}>${e.text}</option>`)}`;
    render(optionTemplate, select);
}

async function addItem(ev) {
    ev.preventDefault();
    const text = form.querySelector('#itemText').value;

    try {
        let res = await fetch(url, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({ text })
        });

        if (res.ok == false) {
            const error = await res.json();
            throw new Error(error.message);
        }

        form.reset();
        getOptions();
    } catch (err) {
        alert(err.message);
    }
}