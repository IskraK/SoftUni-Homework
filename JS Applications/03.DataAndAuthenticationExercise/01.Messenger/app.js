// function attachEvents() {
//     document.getElementById('submit').addEventListener('click', async () => {
//         const authorField = document.querySelector('input[name="author"]');
//         const contentField = document.querySelector('input[name="content"]');
//         const author = authorField.value;
//         const content = contentField.value;

//         sendMessage({ author, content });

//         authorField.value = '';
//         contentField.value = '';

//         getMessages();
//     });

//     document.getElementById('refresh').addEventListener('click', getMessages);

//     getMessages();
// }

// attachEvents();

// async function getMessages() {
//     const response = await fetch('http://localhost:3030/jsonstore/messenger');
//     const data = await response.json();

//     const messages = Object.values(data).map(m => `${m.author}: ${m.content}`).join('\n');
//     document.getElementById('messages').value = messages;
// }

// async function sendMessage(message) {
//     if (message.author == '' || message.content == '') {
//         return alert('The field is required!');
//     }

//     const response = await fetch('http://localhost:3030/jsonstore/messenger', {
//         method: 'post',
//         headers: { 'Content-Type': 'application/json' },
//         body: JSON.stringify(message)
//     });

//     const data = await response.json();
// }


//second decision
const textArea = document.getElementById('messages');
const authorField = document.querySelector('input[name="author"]');
const contentField = document.getElementsByName('content')[0];
const url = 'http://localhost:3030/jsonstore/messenger';

function attachEvents() {
    document.getElementById('submit').addEventListener('click', sendMessage);
    document.getElementById('refresh').addEventListener('click', getAllMessages);
}

function sendMessage() {
    if (authorField.value == '' || contentField.value == '') {
        return alert('The field is required!');
    }

    fetch(url, {
        method: 'POST',
        'Content-Type': 'application/json',
        body: JSON.stringify({
            author: authorField.value,
            content: contentField.value
        })
    })
        .catch(error => console.log(error));

    authorField.value = '';
    contentField.value = '';
}

function getAllMessages() {
    fetch(url)
        .then(res => res.json())
        .then(data => {
            textArea.value = Object.values(data)
                .map(m => `${m.author}: ${m.content}`)
                .join('\n');
        })
        .catch(error => console.log(error));
}

attachEvents();