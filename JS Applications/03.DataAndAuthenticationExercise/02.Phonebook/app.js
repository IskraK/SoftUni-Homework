const phonebook = document.getElementById('phonebook');
const loadBtn = document.getElementById('btnLoad');
const createBtn = document.getElementById('btnCreate');
const personField = document.getElementById('person');
const phoneField = document.getElementById('phone');

const url = 'http://localhost:3030/jsonstore/phonebook';

function attachEvents() {
    loadBtn.addEventListener('click', onLoad);
    createBtn.addEventListener('click', onCreate);
}

attachEvents();

async function onLoad() {
    const response = await fetch(url);
    const data = await response.json();

    phonebook.replaceChildren();

    Object.values(data).forEach(v => {
        const li = document.createElement('li');
        li.textContent = `${v.person}: ${v.phone}`;
        li.id = v._id;

        const deleteBtn = document.createElement('button');
        deleteBtn.textContent = 'Delete';
        deleteBtn.addEventListener('click', onDelete);

        li.appendChild(deleteBtn);
        phonebook.appendChild(li);
    });
}

async function onCreate() {
    if (personField.value === '' || phoneField.value === '') {
        return alert('The fields are required!');
    }

    if (isNaN(Number(phoneField.value))) {
        alert('Enter valid phonenumber');
        phoneField.value = '';
        return;
    }

    await fetch(url, {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify({
            person: personField.value,
            phone: phoneField.value
        })
    });

    personField.value = '';
    phoneField.value = '';

    loadBtn.click();
}

async function onDelete(ev) {
    const id = ev.target.parentNode.id;
    await fetch(`${url}/${id}`, {
        method: 'DELETE'
    });

    ev.target.parentNode.remove();

    loadBtn.click();
}