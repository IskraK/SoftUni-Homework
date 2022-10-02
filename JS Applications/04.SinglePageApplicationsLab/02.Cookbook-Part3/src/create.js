import { getToken } from './auth.js';

const createSection = document.querySelector('.create');
const createForm = createSection.querySelector('form');

createForm.addEventListener('submit', (ev) => {
    ev.preventDefault();
    let formData = new FormData(ev.currentTarget);

    let name = formData.get('name');
    let img = formData.get('img');
    let ingredients = formData.get('ingredients').split('\n');
    let steps = formData.get('steps').split('\n');

    let data = {
        name,
        img,
        ingredients,
        steps
    };

    fetch('http://localhost:3030/data/recipes', {
        method: 'post',
        headers: {
            'Content-Type': 'application/json',
            'X-Authorization': getToken()
        },
        body: JSON.stringify(data)
    })
        .then(res => res.json())
        .then(data => {
            alert('Successful recipe create');
        });
});

export function renderCreate() {
    createSection.getElementsByClassName.display = 'block';
}