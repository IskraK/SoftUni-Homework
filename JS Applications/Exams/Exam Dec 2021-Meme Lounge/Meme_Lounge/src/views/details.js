import { html, nothing } from '../../node_modules/lit-html/lit-html.js';
import * as requestService from '../services/requestService.js';
import * as userService from '../services/userService.js';

const detailsTemplate = (meme, isOwner, onDelete) => html`
<section id="meme-details">
    <h1>Meme Title: ${meme.title}

    </h1>
    <div class="meme-details">
        <div class="meme-img">
            <img alt="meme-alt" src=${meme.imageUrl}>
        </div>
        <div class="meme-description">
            <h2>Meme Description</h2>
            <p>
                ${meme.description}
            </p>
            ${isOwner
            ? html`
            <a class="button warning" href="/edit/${meme._id}">Edit</a>
            <button @click=${onDelete} href="javascript:void(0)" class="button danger">Delete</button>`
            : nothing
            }
        </div>
    </div>
</section>`;

export async function detailsView(ctx) {
    const memeId = ctx.params.id;
    const meme = await requestService.getById(memeId);
    const user = userService.getUser();
    const isOwner = user && user._id === meme._ownerId;

    ctx.render(detailsTemplate(meme, isOwner, onDelete));

    async function onDelete() {
        const confirmed = confirm('Are you sure you want to delete this meme?');
        if (confirmed) {
            await requestService.deleteById(memeId);
            ctx.page.redirect('/all');
        }
    }
};