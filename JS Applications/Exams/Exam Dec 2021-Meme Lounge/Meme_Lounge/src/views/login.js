import { html } from '../../node_modules/lit-html/lit-html.js';
import * as requestService from '../services/requestService.js';
import {notify} from '../notification.js';


const loginTemplate = (onSubmit) => html`
<section id="login">
    <form @submit=${onSubmit} id="login-form">
        <div class="container">
            <h1>Login</h1>
            <label for="email">Email</label>
            <input id="email" placeholder="Enter Email" name="email" type="text">
            <label for="password">Password</label>
            <input id="password" type="password" placeholder="Enter Password" name="password">
            <input type="submit" class="registerbtn button" value="Login">
            <div class="container signin">
                <p>Dont have an account?<a href="/register">Sign up</a>.</p>
            </div>
        </div>
    </form>
</section>`;

export async function loginView(ctx) {
    async function onSubmit(ev) {
        ev.preventDefault();

        const data = Object.fromEntries(new FormData(ev.currentTarget));

        if (Object.values(data).some(x => x.trim() === '')) {
            notify('All fields are required!')
            return;
        }

        await requestService.login(data.email, data.password);
        ev.target.reset();
        ctx.page.redirect('/all');
    }

    ctx.render(loginTemplate(onSubmit));
};