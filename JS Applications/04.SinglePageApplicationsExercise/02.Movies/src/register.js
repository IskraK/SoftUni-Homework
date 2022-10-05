import { showView, updateNav } from './util.js';
import { homePage } from './home.js';

const registerSection = document.querySelector('#form-sign-up');
const form = registerSection.querySelector('form');
form.addEventListener('submit', onSubmit);

export function registerPage() {
    showView(registerSection);
}

async function onSubmit(ev) {
    ev.preventDefault();

    const formData = new FormData(form);
    const email = formData.get('email');
    const password = formData.get('password');
    const rePass = formData.get('repeatPassword');

    if (email.trim() == '' || password.trim() == '' || rePass.trim() == '') {
        alert('All fields are required!');
        return;
    }

    if (password !== rePass) {
        alert('Passwords don\'t match!');
        return;
    }

    if (password.length < 6) {
        alert('Passwords must be at least 6 symbols!');
        return;
    }

    await register(email, password);
    form.reset();
    updateNav();
    homePage();
}

async function register(email, password) {
    try {
        const response = await fetch('http://localhost:3030/users/register', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({ email, password })
        });

        if (!response.ok) {
            const error = await response.json();
            throw new Error(error.message);
        }

        const user = await response.json();
        localStorage.setItem('user', JSON.stringify(user));
    } catch (err) {
        alert(err.message);
        throw err;
    }
}