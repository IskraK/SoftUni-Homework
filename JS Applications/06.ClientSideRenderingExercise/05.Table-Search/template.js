import { html } from '../node_modules/lit-html/lit-html.js';

export const tableTemplate = (data) => html`${data.map(template)}`;

const template = ({ firstName, lastName, email, course }) => html`
    <tr>
        <td>${firstName} ${lastName}</td>
        <td>${email}</td>
        <td>${course}</td>
    </tr>`;