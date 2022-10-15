import { html } from '../node_modules/lit-html/lit-html.js';

const templateBtn = (id, text) => html`<button id="${id}">${text}</button>`;

const table = () => html`<table></table>`;

export const tableTemplate = (data) => html`
    <thead>
        <tr>
            <th>Title</th>
            <th>Author</th>
            <th>Action</th>
        </tr>
    </thead>
    <tbody>
        ${data.map(rowTemplate)}
    </tbody>
`;

const rowTemplate = ([id, { author, title }]) => html`
    <tr id="${id}">
        <td>${title}</td>
        <td>${author}</td>
        <td>
            <button class="editBook">Edit</button>
            <button class="removeBook">Delete</button>
        </td>
    </tr>
`;

const addBookTemplate = () => html`
    <form id="add-form">
        <h3>Add book</h3>
        <label>TITLE</label>
        <input type="text" name="title" placeholder="Title...">
        <label>AUTHOR</label>
        <input type="text" name="author" placeholder="Author...">
        <input type="submit" value="Submit">
    </form>
`;

const editBookTemplate = () => html`
    <form id="edit-form">
        <input type="hidden" name="id">
        <h3>Edit book</h3>
        <label>TITLE</label>
        <input type="text" name="title" placeholder="Title...">
        <label>AUTHOR</label>
        <input type="text" name="author" placeholder="Author...">
        <input type="submit" value="Save">
    </form>
`;

export const bodyTemplate = (template) => html`
${templateBtn('loadBooks', 'LOAD ALL BOOKS')}
${table()}
${template == 'add' ? addBookTemplate() : editBookTemplate()}`;