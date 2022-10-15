import { render } from '../node_modules/lit-html/lit-html.js';
import { getAllBooks, createBook, deleteBook, editBook } from './api.js';
import { bodyTemplate, tableTemplate } from './template.js';

const addBookTemplateString = 'add';
const editBookTemplateString = 'edit';

const body = document.querySelector('body');
render(bodyTemplate(addBookTemplateString), body);

const table = body.querySelector('table');
const loadBooksBtn = document.querySelector('#loadBooks');
loadBooksBtn.addEventListener('click', loadBooks);

async function loadBooks() {
    const books = Object.entries(await getAllBooks());
    render(tableTemplate(books), table);
}

const addBookForm = body.querySelector('#add-form');
addBookForm.addEventListener('submit', addBook);

async function addBook(ev) {
    ev.preventDefault();

    const formData = new FormData(addBookForm);
    const title = formData.get('title').trim();
    const author = formData.get('author').trim();

    const isVlid = validateFormData(title, author);
    if (!isVlid) {
        return;
    }

    const res = await createBook({ title, author });

    if (!res.ok) {
        alert(res.statusText);
        return;
    }

    addBookForm.reset();
    alert('Successfully added a book!');
    loadBooks();
}

function validateFormData(title, author) {
    if (!title || !author) {
        alert('All fields are required!');
        return false;
    }

    return true;
}

document.addEventListener('click', (ev) => {
    if (ev.target.tagName == 'BUTTON') {
        const element = ev.target.parentNode.parentNode;

        if (ev.target.className == 'editBook') {
            editBookData(element);
        } else if (ev.target.className == 'removeBook')
            removeBook(element);
    }
});

let editForm = body.querySelector('#edit-form');
editForm.addEventListener('submit', updateBook(element));

async function editBookData(element) {
    render(bodyTemplate(editBookTemplateString), body);

    const tdElements = Array.from(element.children);
    const titleField = editForm.querySelector('input[name="title"]');
    const authorField = editForm.querySelector('input[name="author"]');

    titleField.value = tdElements[0].textContent;
    authorField.value = tdElements[1].textContent;
}

async function updateBook(ev, id) {
    ev.preventDefault();

    const formData = new FormData(ev.target);

    const title = formData.get('title');
    const author = formData.get('author');

    if (title.trim() === '' || author.trim() === '') {
        return;
    }

    const response = await editBook(id, { title, author });
    const data = await response.json();

    if (!response.ok) {
        return;
    }

    ev.target.reset();
    loadBooks();
}

async function removeBook(element) {
    const id = element.id;

    const res = await deleteBook(id);
    if (!res.ok) {
        alert(res.statusText);
        return;
    }

    alert('Successfully removed book!');
    loadBooks();
}