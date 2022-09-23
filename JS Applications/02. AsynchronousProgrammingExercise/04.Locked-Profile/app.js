function lockedProfile() {
    const main = document.getElementById('main');
    const url = 'http://localhost:3030/jsonstore/advanced/profiles';

    fetch(url)
        .then(response => response.json())
        .then(data => {
            main.innerHTML = '';
            Object.values(data).forEach((p, index) => {
                const profile = createProfile(p, index);
                main.appendChild(profile);
            })
        });

    main.addEventListener('click', (ev) => {
        if (ev.target.tagName !== 'BUTTON') {
            return;
        }

        const profile = ev.target.parentElement;
        const [lockedEl] = profile.querySelectorAll('input');

        if (lockedEl.checked) {
            return;
        }

        const hiddenDiv = profile.querySelector('#user1HiddenFields');

        if (hiddenDiv.style.display !== 'block') {
            hiddenDiv.style.display = 'block';
            ev.target.textContent = 'Hide it';
        } else {
            hiddenDiv.style.display = 'none';
            ev.target.textContent = 'Show more';
        }
    });

    function createProfile(info, index) {
        const div = document.createElement('div');
        div.classList.add('profile');
        div.innerHTML = `
                    <img src="./iconProfile2.png" class="userIcon" />
                    <label>Lock</label>
                    <input type="radio" name="user${index + 1}Locked" value="lock" checked>
                    <label>Unlock</label>
                    <input type="radio" name="user${index + 1}Locked" value="unlock"><br>
                    <hr>
                    <label>Username</label>
                    <input type="text" name="user1Username" value="${info.username}" disabled readonly />
                    <div id="user1HiddenFields">
                        <hr>
                        <label>Email:</label>
                        <input type="email" name="user${index + 1}Email" value="${info.email}" />
                        <label>Age:</label>
                        <input type="email" name="user${index + 1}Age" value="${info.age}"  />
                    </div>
                    <button>Show more</button>`;

        return div;
    }
}


// //another decision
// async function lockedProfile() {
//     let url = 'http://localhost:3030/jsonstore/advanced/profiles';
//     let response = await fetch(url);
//     let users = await response.json();

//     let main = document.getElementById('main');
//     main.innerHTML = '';

//     let userNumber = 1;
//     for (const key in users) {
//         let user = users[key];
//         let showMoreButton = e('button', {}, 'Show more');
//         showMoreButton.addEventListener('click', onShow);

//         let div = e('div', { className: 'profile' },
//             e('img', { src: './iconProfile2.png', className: 'userIcon' }),
//             e('label', {}, 'Lock'),
//             e('input', { type: 'radio', name: `user${userNumber}Locked`, value: 'lock', checked: true }),
//             e('label', {}, ' Unlock'),
//             e('input', { type: 'radio', name: `user${userNumber}Locked`, value: 'unlock' }),
//             e('br'),
//             e('hr'),
//             e('label', {}, 'Username'),
//             e('input', { type: 'text', name: `user${userNumber}Username`, value: user.username, disabled: true, readonly: true }),
//             e('div', { id: 'user1HiddenFields' },
//                 e('hr'),
//                 e('label', {}, 'Email'),
//                 e('input', { type: 'email', name: `user${userNumber}Email`, value: user.email, disabled: true, readonly: true }),
//                 e('label', {}, 'Age'),
//                 e('input', { type: 'email', name: `user${userNumber}Age`, value: user.age, disabled: true, readonly: true })),
//             showMoreButton
//         )
//         main.appendChild(div);
//         userNumber++;

//     }

//     function onShow(ev) {
//         let parent = ev.target.parentElement;
//         const hiddenElement = parent.querySelector('div');

//         if (parent.querySelectorAll('input')[1].checked == true && ev.target.textContent == 'Show more') {
//             hiddenElement.style.display = 'block';
//             ev.target.textContent = 'Hide it';
//         } else if (parent.querySelectorAll('input')[1].checked == true && ev.target.textContent == 'Hide it') {
//             hiddenElement.style.display = 'none';
//             ev.target.textContent = 'Show more';
//         }
//     }

//     function e(type, attributes, ...content) {
//         const result = document.createElement(type);

//         for (let [attr, value] of Object.entries(attributes || {})) {
//             if (attr.substring(0, 2) == 'on') {
//                 result.addEventListener(attr.substring(2).toLocaleLowerCase(), value);
//             } else {
//                 result[attr] = value;
//             }
//         }

//         content = content.reduce((a, c) => a.concat(Array.isArray(c) ? c : [c]), []);

//         content.forEach(e => {
//             if (typeof e == 'string' || typeof e == 'number') {
//                 const node = document.createTextNode(e);
//                 result.appendChild(node);
//             } else {
//                 result.appendChild(e);
//             }
//         });

//         return result;
//     }
// }