function addItem() {
    const input = document.getElementById('newItemText');
    const liElement = createElement('li', input.value);

    const deleteBtn = createElement('a', '[Delete]');
    deleteBtn.href = '#';
    deleteBtn.addEventListener('click', (ev) => {
        ev.target.parentNode.remove();
    });
    liElement.appendChild(deleteBtn);

    document.getElementById('items').appendChild(liElement);
    input.value = '';

    function createElement(type, content) {
        const element = document.createElement(type);
        element.textContent = content;
        return element;
    }
}


////second decision
// function addItem() {
//     const inputField = document.getElementById('newItemText');

//     if (inputField.value.trim() == '') {
//         return;
//     }

//     const li = document.createElement('li');
//     li.textContent = inputField.value;

//     const button = document.createElement('a');
//     button.textContent = '[Delete]';
//     button.href = '#';
//     button.addEventListener('click', onClick);

//     li.appendChild(button);
//     document.getElementById('items').appendChild(li);

//     inputField.value = '';

//     function onClick(ev) {
//         const parent = ev.target.parentNode;
//         parent.remove();
//     }
// }