import { html, nothing } from '../../node_modules/lit-html/lit-html.js';
import * as requestService from '../services/requestService.js';

const detailsTemplate = (album, isOwner) => html`
<section id="detailsPage">
    <div class="wrapper">
        <div class="albumCover">
            <img src=${album.imgUrl}>
        </div>
        <div class="albumInfo">
            <div class="albumText">
                <h1>Name: ${album.name}</h1>
                <h3>Artist: ${album.artist}</h3>
                <h4>Genre: ${album.genre}</h4>
                <h4>Price: $${album.price}</h4>
                <h4>Date: ${album.releaseDate}</h4>
                <p>${album.description}</p>
            </div>

            ${isOwner ? html`
            <div class="actionBtn">
                <a href="/albums/${album._id}/edit" class="edit">Edit</a>
                <a href="/albums/${album._id}/delete" class="remove">Delete</a>
            </div>`: nothing}
        </div>
    </div>
</section>`;

export const detailsView = (ctx) => {
    requestService.getAlbumById(ctx.params.albumId)
        .then(album => {
            const isOwner = ctx.user._id == album._ownerId;
            ctx.render(detailsTemplate(album, isOwner));
        });
};