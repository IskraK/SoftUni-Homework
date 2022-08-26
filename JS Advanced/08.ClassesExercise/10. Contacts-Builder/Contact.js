// class Contact {
//     constructor(firstName, lastName, phone, email) {
//         this.firstName = firstName;
//         this.lastName = lastName;
//         this.phone = phone;
//         this.email = email;
//         this.online = false;
//     }

//     get online() {
//         return this._online;
//     }

//     set online(value) {
//         let divs = document.querySelectorAll('div .title');

//         if (value) {
//             this._online = true;
//         } else {
//             this._online = false;
//         }

//         for (const item of divs) {
//             if (item.textContent.includes(`${this.firstName} ${this.lastName}`)) {
//                 if (value) {
//                     this._online = true;
//                     item.classList.add('online');
//                 } else {
//                     this._online = false;
//                     item.classList.remove('online');
//                 }
//             }
//         }
//     }

//     render(id) {
//         let article = this.createEl('article');
//         article.innerHTML = `    <div class="title">${this.firstName} ${this.lastName}<button>&#8505;</button></div>
//         <div class="info">
//             <span>&phone; ${this.phone}</span>
//             <span>&#9993; ${this.email}</span>
//         </div>`;

//         if (this._online == true) {
//             article.querySelector('.title').classList.add('online');
//         }

//         let infoDiv = article.querySelector('.info');
//         infoDiv.style.display = 'none';
//         document.getElementById(id).appendChild(article);

//         let infoBtn = article.querySelector('button');
//         infoBtn.addEventListener('click', onClick);

//         function onClick() {
//             if (infoDiv.style.display == 'none') {
//                 infoDiv.style.display = 'block';
//             } else {
//                 infoDiv.style.display = 'none';
//             }
//         }
//     }

//     createEl(type, content, className) {
//         let result = document.createElement(type);
//         if (content) {
//             result.textContent = content;
//         }
//         if (className) {
//             result.className = className;
//         }
//         return result;
//     }
// }


//second decision
class Contact {
    constructor(firstName, lastName, phone, email) {
        this.firstName = firstName;
        this.lastName = lastName;
        this.phone = phone;
        this.email = email;
        this.online = false;
    }

    get online() {
        return this._online;
    }

    set online(value) {
        this._online = value;

        if (this.online === true && this.titleDiv) {
            this.titleDiv.classList.add('online');
        } else if (this.titleDiv) {
            this.titleDiv.classList.remove('online');
        }
    }

    render(id) {
        const el = document.querySelector(`#${id}`);

        const article = document.createElement('article');
        const titleDiv = document.createElement('div');
        const button = document.createElement('button');
        const infoDiv = document.createElement('div');
        const phoneSpan = document.createElement('span');
        const emailSpan = document.createElement('span');

        this.titleDiv = titleDiv;
        this.online === true ? this.titleDiv.classList.add('online') : '';

        titleDiv.classList.add('title');
        infoDiv.classList.add('info');
        infoDiv.style.display = 'none';
        titleDiv.textContent = `${this.firstName} ${this.lastName}`;
        phoneSpan.innerHTML = `&phone; ${this.phone}`;
        emailSpan.innerHTML = `&#9993; ${this.email}`;
        button.innerHTML = '&#8505;';
        button.addEventListener('click', () => {
            infoDiv.style.display === 'block'
                ? infoDiv.style.display = 'none'
                : infoDiv.style.display = 'block';
        });

        titleDiv.appendChild(button);
        infoDiv.appendChild(phoneSpan);
        infoDiv.appendChild(emailSpan);
        article.appendChild(titleDiv);
        article.appendChild(infoDiv);

        el.appendChild(article);
    }
}



let contacts = [
    new Contact("Ivan", "Ivanov", "0888 123 456", "i.ivanov@gmail.com"),
    new Contact("Maria", "Petrova", "0899 987 654", "mar4eto@abv.bg"),
    new Contact("Jordan", "Kirov", "0988 456 789", "jordk@gmail.com")
];
contacts.forEach(c => c.render('main'));

// After 1 second, change the online status to true
setTimeout(() => contacts[1].online = true, 2000);
