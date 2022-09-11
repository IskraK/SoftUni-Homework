function solve() {
    const recipientField = document.getElementById('recipientName');
    const titleField = document.getElementById('title');
    const messageField = document.getElementById('message');
    const addBtn = document.getElementById('add');
    const resetBtn = document.getElementById('reset');
    const listMails = document.getElementById('list');
    const sentList = document.querySelector('.sent-list');
    const deletedList = document.querySelector('.delete-list');

    addBtn.addEventListener('click', (ev) => {
        ev.preventDefault();

        const recipient = recipientField.value;
        const title = titleField.value;
        const message = messageField.value;

        if (!recipient || !title || !message) {
            return;
        }

        const liElement = el('li', '', listMails);
        const titleElement = el('h4', `Title: ${title}`, liElement);
        const recipientElement = el('h4', `Recipient Name: ${recipient}`, liElement);
        const messageElement = el('span', `${message}`, liElement);
        const actionsElement = el('div', '', liElement);
        actionsElement.id = 'list-action';
        const sendBtn = el('button', 'Send', actionsElement);
        sendBtn.type = 'submit';
        sendBtn.id = 'send';
        const deleteBtn = el('button', 'Delete', actionsElement);
        deleteBtn.type = 'submit';
        deleteBtn.id = 'delete';

        deleteBtn.addEventListener('click', deleteMail);

        clearInput();

        sendBtn.addEventListener('click', () => {
            liElement.remove();

            const liSendEl = el('li', '', sentList);
            const spanRecipient = el('span', `To: ${recipient}`, liSendEl);
            const spanTitle = el('span', `Title: ${title}`, liSendEl);
            const divEl = el('div', '', liSendEl);
            divEl.classList.add('btn');
            const deleteSendBtn = el('button', 'Delete', divEl);
            deleteSendBtn.type = 'submit';
            deleteSendBtn.classList.add('delete');

            deleteSendBtn.addEventListener('click', deleteMail);
        });

        function deleteMail(ev) {
            ev.currentTarget.parentNode.parentNode.remove();
            const liDellEl = el('li', '', deletedList);
            const spanRecipient = el('span', `To: ${recipient}`, liDellEl);
            const spanTitle = el('span', `Title: ${title}`, liDellEl);
        }
    });

    resetBtn.addEventListener('click', clearInput);

    function clearInput() {
        recipientField.value = '';
        titleField.value = '';
        messageField.value = '';
    }

    function el(type, content, parent) {
        const element = document.createElement(type);
        element.textContent = content;

        if (parent) {
            parent.appendChild(element);
        }
        return element;
    }
}
solve()