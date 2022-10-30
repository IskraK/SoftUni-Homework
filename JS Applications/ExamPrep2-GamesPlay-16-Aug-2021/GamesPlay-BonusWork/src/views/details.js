import { html, nothing } from '../../node_modules/lit-html/lit-html.js';
import * as requestService from '../services/requestService.js';
import * as userService from '../services/userService.js';


const detailsTemplate = (game, user, isOwner, comments, onComment, onDelete) => html`
<section id="game-details">
    <h1>Game Details</h1>
    <div class="info-section">

        <div class="game-header">
            <img class="game-img" src=${game.imageUrl} />
            <h1>${game.title}</h1>
            <span class="levels">MaxLevel: ${game.maxLevel}</span>
            <p class="type">${game.category}</p>
        </div>

        <p class="text">${game.summary}</p>

        <!-- Bonus ( for Guests and Users ) -->
        <div class="details-comments">
                <h2>Comments:</h2>
                ${comments.length > 0
                ? html`
                <ul>
                    ${comments.map(comment => commentTemplate(comment))}
                </ul>`
                : html`<p class="no-comment">No comments.</p>`
                }
        </div>
            
        <!-- Edit/Delete buttons ( Only for creator of this game )  -->
        ${isOwner
        ? html`
        <div class="buttons">
            <a href="/edit/${game._id}" class="button">Edit</a>
            <a @click=${onDelete} href="javascript:void(0)" class="button">Delete</a>
        </div>`
        : nothing
        }
    </div>

    <!-- Bonus -->
    <!-- Add Comment ( Only for logged-in users, which is not creators of the current game ) -->
    ${(user && !isOwner)
        ? html` 
        <article class="create-comment">
            <label>Add new comment:</label>
            <form @submit=${onComment} class="form">
                <textarea name="comment" placeholder="Comment......"></textarea>
                <input class="btn submit" type="submit" value="Add Comment">
            </form>
        </article>`
        : nothing
    }
</section>`;

const commentTemplate = (comment) => html`
    <li class="comment">
        <p>Content: ${comment.comment}</p>
    </li>`;

export async function detailsView(ctx) {
    const gameId = ctx.params.id;
    //const game = await requestService.getById(gameId);
    const user = userService.getUser();

    const onComment = (ev) => {
        ev.preventDefault();

        const { comment } = Object.fromEntries(new FormData(ev.currentTarget));
       
        requestService.addComment(gameId, comment)
            .then(() => ctx.page.redirect(`/details/${gameId}`));
        
        ev.currentTarget.reset();
    }
    
    const [comments, game] = await Promise.all([
        requestService.getCommentsById(gameId),
        requestService.getById(gameId)
    ]);

    const isOwner = user && user._id === game._ownerId;

    ctx.render(detailsTemplate(game, user, isOwner, comments, onComment, onDelete));

    async function onDelete() {
        const confirmed = confirm('Are you sure you want to delete this game?');
        if (confirmed) {
            await requestService.deleteById(gameId);
            ctx.page.redirect('/');
        }
    }
};