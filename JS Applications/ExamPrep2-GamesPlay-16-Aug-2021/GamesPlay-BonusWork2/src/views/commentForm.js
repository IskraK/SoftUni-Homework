import { html, nothing } from '../../node_modules/lit-html/lit-html.js';
import * as requestService from '../services/requestService.js';


const formTemplate = (onSubmit) => html`
<article class="create-comment">
    <label>Add new comment:</label>
    <form @submit=${onSubmit} class="form">
        <textarea name="comment" placeholder="Comment......"></textarea>
        <input class="btn submit" type="submit" value="Add Comment">
    </form>
</article>`;

export function commentFormView(ctx, isOwner) {
    if (ctx.user && !isOwner) {
        return formTemplate(onSubmit);
    } else {
        return nothing;
    }

    async function onSubmit(ev) {
        ev.preventDefault();

        const gameId = ctx.params.id;
        const data = Object.fromEntries(new FormData(ev.currentTarget));

        await requestService.addComment({
            gameId,
            comment: data.comment
        });
        console.log(data);
        ev.target.reset();
        ctx.page.redirect(`/details/${gameId}`);
    }
}