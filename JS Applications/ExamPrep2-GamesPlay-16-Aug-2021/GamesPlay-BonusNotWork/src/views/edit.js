import { html } from '../../node_modules/lit-html/lit-html.js';
import * as requestService from '../services/requestService.js';

const editTemplate = (game, onSubmit) => html`
<section id="edit-page" class="auth">
    <form @submit=${onSubmit} id="edit">
        <div class="container">

            <h1>Edit Game</h1>
            <label for="leg-title">Legendary title:</label>
            <input type="text" id="title" name="title" .value=${game.title}>

            <label for="category">Category:</label>
            <input type="text" id="category" name="category" .value=${game.category}>

            <label for="levels">MaxLevel:</label>
            <input type="number" id="maxLevel" name="maxLevel" min="1" .value=${game.maxLevel}>

            <label for="game-img">Image:</label>
            <input type="text" id="imageUrl" name="imageUrl" .value=${game.imageUrl}>

            <label for="summary">Summary:</label>
            <textarea name="summary" id="summary" .value=${game.summary}></textarea>
            <input class="btn submit" type="submit" value="Edit Game">

        </div>
    </form>
</section>`;

export async function editView(ctx) {
    const gameId = ctx.params.id;
    const game = await requestService.getById(gameId);

    async function onSubmit(ev) {
        ev.preventDefault();

        const data = Object.fromEntries(new FormData(ev.currentTarget));

        if (Object.values(data).some(x => x.trim() === '')) {
            return alert('All fields are required!');
        }

        await requestService.update(gameId, {
            title: data.title,
            category: data.category,
            maxLevel: data.maxLevel,
            imageUrl: data.imageUrl,
            summary: data.summary
        });
        ev.target.reset();
        ctx.page.redirect('/details/' + gameId);
    }

    ctx.render(editTemplate(game, onSubmit));
};