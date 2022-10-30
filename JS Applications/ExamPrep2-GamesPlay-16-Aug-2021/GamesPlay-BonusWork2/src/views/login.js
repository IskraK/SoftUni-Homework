import { html } from '../../node_modules/lit-html/lit-html.js';
import * as requestService from '../services/requestService.js';

const loginTemplate = (onSubmit) => html`
<section id="login-page" class="auth">
    <form @submit=${onSubmit} id="login">

        <div class="container">
            <div class="brand-logo"></div>
            <h1>Login</h1>
            <label for="email">Email:</label>
            <input type="email" id="email" name="email" placeholder="Sokka@gmail.com">

            <label for="login-pass">Password:</label>
            <input type="password" id="login-password" name="password">
            <input type="submit" class="btn submit" value="Login">
            <p class="field">
                <span>If you don't have profile click <a href="/register">here</a></span>
            </p>
        </div>
    </form>
</section>`;


export async function loginView(ctx) {
    async function onSubmit(ev) {
        ev.preventDefault();

        const data = Object.fromEntries(new FormData(ev.currentTarget));

        if (Object.values(data).some(x => x.trim() === '')) {
            alert('All fields are required!')
            return;
        }

        await requestService.login(data.email, data.password);
        ev.target.reset();
        ctx.page.redirect('/');
    }

    ctx.render(loginTemplate(onSubmit));
};

// export const loginView = (ctx) => {
//     const onSubmit = (ev) => {
//         ev.preventDefault();

//         const data = Object.fromEntries(new FormData(ev.currentTarget));

//         if (Object.values(data).some(x => x.trim() === '')) {
//             alert('All fields are required!')
//             return;
//         }

//         requestService.login(data.email, data.password)
//             .then(() => ctx.page.redirect('/'));
//     }

//     ctx.render(loginTemplate(onSubmit));
// };
