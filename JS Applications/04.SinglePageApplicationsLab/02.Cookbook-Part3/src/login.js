import { updateAuth } from './auth.js';

const loginSection = document.querySelector('.login');
const loginForm = loginSection.querySelector('form');

loginForm.addEventListener('submit', (ev) => {
    ev.preventDefault();

    let formData = new FormData(ev.currentTarget);
    let email = formData.get('email');
    let password = formData.get('password');

    fetch('http://localhost:3030/users/login', {
        method: 'post',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify({ email, password })
    })
        .then(res => res.json())
        .then(user => {
            localStorage.setItem('user', JSON.stringify(user));
            updateAuth();
            alert('Successfully logged in.');
        });
});

export function renderLogin() {
    loginSection.getElementsByClassName.display = 'block';
}