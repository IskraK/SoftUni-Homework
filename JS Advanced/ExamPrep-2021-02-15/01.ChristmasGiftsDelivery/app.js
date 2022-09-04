// function solution() {
//     const input = document.querySelector('input');
//     const [gifts, sent, discarded] = document.querySelectorAll('section ul');
//     document.querySelector('button').addEventListener('click', addGift);

//     function addGift() {
//         const name = input.value;
//         input.value = '';

//         const element = el('li', name);
//         element.className = 'gift';

//         const sendBtn = el('button', 'Send');
//         sendBtn.id = 'sendButton';

//         const discardBtn = el('button', 'Discard');
//         discardBtn.id = 'discardButton';

//         element.appendChild(sendBtn);
//         element.appendChild(discardBtn);

//         sendBtn.addEventListener('click', () => sendGift(name, element));
//         discardBtn.addEventListener('click', () => discardGift(name, element));

//         gifts.appendChild(element);

//         sortGifts();
//     }

//     function sendGift(name, gift) {
//         gift.remove();
//         const element = el('li', name);
//         element.className = 'gift';
//         sent.appendChild(element);
//     }

//     function discardGift(name, gift) {
//         gift.remove();
//         const element = el('li', name);
//         element.className = 'gift';
//         discarded.appendChild(element);
//     }

//     function sortGifts() {
//         Array
//             .from(gifts.children)
//             //.sort((a, b) => a.textContent.localeCompare(b.textContent))
//             .sort((a, b) => a.childNodes[0].textContent.localeCompare(b.childNodes[0].textContent))
//             .forEach(g => gifts.appendChild(g));
//     }

//     function el(type, content) {
//         const result = document.createElement(type);
//         result.textContent = content;

//         return result;
//     }
// }


//refactor sorting
function solution() {
    const input = document.querySelector('input');
    const [gifts, sent, discarded] = document.querySelectorAll('section ul');
    document.querySelector('button').addEventListener('click', addGift);

    function addGift() {
        const name = input.value;
        input.value = '';

        const element = el('li', name);
        element.className = 'gift';

        const sendBtn = el('button', 'Send');
        sendBtn.id = 'sendButton';

        const discardBtn = el('button', 'Discard');
        discardBtn.id = 'discardButton';

        element.appendChild(sendBtn);
        element.appendChild(discardBtn);

        sendBtn.addEventListener('click', () => dispatchGift(sent, name, element));
        discardBtn.addEventListener('click', () => dispatchGift(discarded, name, element));

        //sorting li elements
        let inserted = false;
        for (const child of Array.from(gifts.children)) {
            if (child.textContent.localeCompare(element.textContent) == 1) {
                gifts.insertBefore(element, child);
                inserted = true;
                break;
            }
        }

        if (!inserted) {
            gifts.appendChild(element);
        }
    }

    function dispatchGift(target, name, gift) {
        gift.remove();
        const element = el('li', name);
        element.className = 'gift';
        target.appendChild(element);
    }

    function el(type, content) {
        const result = document.createElement(type);
        result.textContent = content;

        return result;
    }
}


// //second decision
// function solution() {
//     const input = document.querySelector('.card div input');
//     const addGiftBtn = document.querySelector('.card div button');
//     addGiftBtn.addEventListener('click', addGift);

//     const uls = document.querySelectorAll('section.card ul');
//     const listGifts = uls[0];
//     const sentGifts = uls[1];
//     const discardedGifts = uls[2];

//     function addGift() {
//         const name = input.value;
//         input.value = '';

//         const li = document.createElement('li');
//         li.classList.add('gift');
//         li.textContent = name;

//         const sendBtn = document.createElement('button');
//         sendBtn.id = 'sendButton';
//         sendBtn.textContent = 'Send';
//         sendBtn.addEventListener('click', () => {
//             li.removeChild(sendBtn);
//             li.removeChild(discardBtn);
//             sentGifts.appendChild(li);
//         });

//         const discardBtn = document.createElement('button');
//         discardBtn.id = 'discardButton';
//         discardBtn.textContent = 'Discard';
//         discardBtn.addEventListener('click', () => {
//             li.removeChild(sendBtn);
//             li.removeChild(discardBtn);
//             discardedGifts.appendChild(li);
//         });

//         li.appendChild(sendBtn);
//         li.appendChild(discardBtn);

//         const gifts = Array.from(listGifts.children);
//         gifts.push(li);
//         gifts
//             .sort((a, b) => a.textContent.localeCompare(b.textContent))
//             .forEach(gift => listGifts.appendChild(gift));
//     }
// }