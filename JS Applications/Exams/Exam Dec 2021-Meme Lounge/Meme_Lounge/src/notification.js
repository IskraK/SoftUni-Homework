const divElement = document.getElementById('errorBox');
const span = divElement.querySelector('span');

export function notify(message){
    span.textContent = message;
    divElement.style.display = 'block';

    setTimeout(() => divElement.style.display = 'none', 3000)
}