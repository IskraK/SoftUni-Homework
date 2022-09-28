const url = 'http://localhost:3030/data/catches/';
const token = sessionStorage.getItem('userToken');

const main = document.getElementById('main');
const catchDiv = document.getElementById('catches');

const loadButton = document.querySelector('button.load');
loadButton.addEventListener('click', onLoad);

const form = document.getElementById('addForm');
form.addEventListener('submit', onSubmit);

window.addEventListener('load', async () => {
    const userDiv = document.getElementById('user');
    const guestDiv = document.getElementById('guest');
    const spanGuest = document.querySelector('p.email span');
    const addBtn = document.querySelector('button.add');

    if (token !== null) {
        userDiv.style.display = 'inline';
        guestDiv.style.display = 'none';
        spanGuest.textContent = `${sessionStorage.getItem('userEmail')}`;
        addBtn.disabled = false;
        document.getElementById('logout').addEventListener('click', onLogout);
    } else {
        guestDiv.style.display = 'inline';
        userDiv.style.display = 'none';
        spanGuest.textContent = 'guest';
        addBtn.disabled = true;
    }

    onLoad();
});

async function onLoad() {
    const catches = await fetch(url).then(response => response.json());
    Array.from(catchDiv.children).map(x => x.remove());

    catches.forEach(c => {
        loadCatch(c.angler, c.weight, c.species, c.location, c.bait, c.captureTime, c._ownerId, c._id);
    });
}

function loadCatch(angler, weight, species, location, bait, captureTime, ownerId, catchId) {
    const isDisabled = sessionStorage.getItem('userId') === ownerId ? false : true;

    const updateBtn = e('button', { class: 'update', 'data-id': catchId }, 'Update');
    updateBtn.addEventListener('click', onUpdate);

    const deleteBtn = e('button', { class: 'delete', 'data-id': catchId }, 'Delete');
    deleteBtn.addEventListener('click', onDelete);

    updateBtn.disabled = isDisabled;
    deleteBtn.disabled = isDisabled;

    const div = e('div', { class: 'catch' },
        e('label', {}, 'Angler'),
        e('input', { type: "text", class: "angler", value: angler, disabled: isDisabled }, 'Angler'),
        e('label', {}, 'Weight'),
        e('input', { type: "text", class: "weight", value: weight, disabled: isDisabled }, 'Weight'),
        e('label', {}, 'Species'),
        e('input', { type: "text", class: "species", value: species, disabled: isDisabled }, 'Species'),
        e('label', {}, 'Location'),
        e('input', { type: "text", class: "location", value: location, disabled: isDisabled }, 'Location'),
        e('label', {}, 'Bait'),
        e('input', { type: "text", class: "bait", value: bait, disabled: isDisabled }, 'Bait'),
        e('label', {}, 'Capture Time'),
        e('input', { type: "number", class: "captureTime", value: captureTime, disabled: isDisabled }, 'Capture Time'),
        updateBtn,
        deleteBtn,
    )

    catchDiv.appendChild(div);
}

async function onSubmit(ev) {
    ev.preventDefault();
    const formData = new FormData(form);

    const angler = formData.get('angler');
    const weight = formData.get('weight');
    const species = formData.get('species');
    const location = formData.get('location');
    const bait = formData.get('bait');
    const captureTime = formData.get('captureTime');


    if (angler.trim() === ''
        || weight.trim() === ''
        || isNaN(weight)
        || species.trim() === ''
        || location.trim() === ''
        || bait.trim() === ''
        || captureTime.trim() === ''
        || !Number.isInteger(Number(captureTime))) {
        return alert('Invalid input data.');
    }

    const body = JSON.stringify({
        _ownerId: sessionStorage.getItem('userId'),
        angler,
        weight,
        species,
        location,
        bait,
        captureTime
    });

    await fetch(url, {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
            'X-Authorization': token
        },
        body
    });

    form.reset();
    onLoad();
}

async function onUpdate(ev) {
    const dataId = ev.target.getAttribute('data-id');
    const fields = ev.target.parentElement.querySelectorAll('input');

    const angler = fields[0].value;
    const weight = fields[1].value;
    const species = fields[2].value;
    const location = fields[3].value;
    const bait = fields[4].value;
    const captureTime = fields[5].value;

    if (angler.trim() === ''
        || weight.trim() === ''
        || isNaN(weight)
        || species.trim() === ''
        || location.trim() === ''
        || bait.trim() === ''
        || captureTime.trim() === ''
        || !Number.isInteger(Number(captureTime))) {
        return alert('Invalid input data.');
    }

    const body = JSON.stringify({
        angler,
        weight,
        species,
        location,
        bait,
        captureTime
    })

    await fetch(url + dataId, {
        method: 'PUT',
        headers: { 'X-Authorization': token },
        body
    });
    
    onLoad();
}

async function onDelete(ev) {
    const dataId = ev.target.getAttribute('data-id');

    await fetch(url + dataId, {
        method: 'DELETE',
        headers: { 'X-Authorization': token }
    });

    ev.target.parentElement.remove();
}

async function onLogout() {
    const response = await fetch('http://localhost:3030/users/logout', {
        method: 'GET',
        headers: { 'X-Authorization': token }
    });

    if (response.ok == false) {
        const error = await response.json();
        return alert(error.message);
    }

    sessionStorage.removeItem('userToken');
    window.location.pathname = '05.Fisher-Game/src/index.html';
}

function e(type, attr, ...content) {
    const element = document.createElement(type);

    for (const prop in attr) {
        if (prop === 'class') {
            element.classList.add(attr[prop])
        } else if (prop === 'disabled') {
            element.disabled = attr[prop];
        } else {
            element.setAttribute(prop, attr[prop]);
        }
    }

    for (let item of content) {
        if (typeof item == 'string' || typeof item == 'number') {
            item = document.createTextNode(item);
        }

        element.appendChild(item);
    }

    return element;
}