const url = 'http://localhost:3030/users/register';

const form = document.querySelector('#register-view #register');
form.addEventListener('submit', onRegister);

async function onRegister(ev) {
    ev.preventDefault();

    const notification = document.querySelector('.notification');
    notification.textContent = '';

    const formData = new FormData(ev.target);
    const email = formData.get('email');
    const password = formData.get('password');
    const repass = formData.get('rePass');

    if (email.trim() === '' || password.trim() === '' || repass.trim() === '') {
        notification.textContent = 'The fields are required!';
        return;
    }

    if (password.trim() !== repass.trim()) {
        notification.textContent = 'The passwords don\'t match!';
        return;
    }

    const response = await fetch(url, {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify({ email, password })
    });

    if (!response.ok) {
        const error = await response.json();
        return alert(error.message);
    }

    const data = await response.json();
    sessionStorage.setItem('userToken', data.accessToken);
    sessionStorage.setItem('userId', data._id);
    sessionStorage.setItem('userEmail', data.email);
    
    window.location.pathname = '05.Fisher-Game/src/index.html';
}