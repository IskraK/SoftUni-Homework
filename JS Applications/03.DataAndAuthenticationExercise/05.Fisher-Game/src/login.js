const url = 'http://localhost:3030/users/login';

const form = document.querySelector('#login-view #login');
form.addEventListener('submit', onRegister);

async function onRegister(ev) {
    ev.preventDefault();

    const notification = document.querySelector('.notification');
    notification.textContent = '';

    const formData = new FormData(ev.target);
    const email = formData.get('email');
    const password = formData.get('password');

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