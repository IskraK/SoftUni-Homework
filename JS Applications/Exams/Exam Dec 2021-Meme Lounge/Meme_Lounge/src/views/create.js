import { html } from '../../node_modules/lit-html/lit-html.js';
import * as requestService from '../services/requestService.js';
import {notify} from '../notification.js';


const createTemplate = (onSubmit) => html`
<section id="create-meme">
    <form @submit=${onSubmit} id="create-form">
        <div class="container">
            <h1>Create Meme</h1>
            <label for="title">Title</label>
            <input id="title" type="text" placeholder="Enter Title" name="title">
            <label for="description">Description</label>
            <textarea id="description" placeholder="Enter Description" name="description"></textarea>
            <label for="imageUrl">Meme Image</label>
            <input id="imageUrl" type="text" placeholder="Enter meme ImageUrl" name="imageUrl">
            <input type="submit" class="registerbtn button" value="Create Meme">
        </div>
    </form>
</section>`;

export async function createView(ctx) {
    async function onSubmit(ev) {
        ev.preventDefault();

        const data = Object.fromEntries(new FormData(ev.currentTarget));

        if (Object.values(data).some(x => x.trim() === '')) {
            return notify('All fields are required!');
        }

        await requestService.create({
            title: data.title,
            description: data.description,
            imageUrl: data.imageUrl
        });
        ev.target.reset();
        ctx.page.redirect('/all');
    }

    ctx.render(createTemplate(onSubmit));
};