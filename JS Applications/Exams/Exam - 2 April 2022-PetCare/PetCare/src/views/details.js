import { html, nothing } from '../../node_modules/lit-html/lit-html.js';
import * as requestService from '../services/requestService.js';
import * as userService from '../services/userService.js';

const detailsTemplate = (pet, isOwner, onDonation, donations, hasDonationBtn, onDelete) => html`
<section id="detailsPage">
    <div class="details">
        <div class="animalPic">
            <img src=${pet.image}>
        </div>
        <div>
            <div class="animalInfo">
                <h1>Name: ${pet.name}</h1>
                <h3>Breed: ${pet.breed}</h3>
                <h4>Age: ${pet.age} years</h4>
                <h4>Weight: ${pet.weight}kg</h4>
                <h4 class="donation">Donation: ${Number(donations)*100}$</h4>
            </div>
            
            <div class="actionBtn">
                    ${isOwner 
                    ? html`
                    <a href="/edit/${pet._id}" class="edit">Edit</a>
                    <a @click=${onDelete} href="javascript:void(0)" class="remove">Delete</a>`
                    : nothing
                    }
                    
                    ${hasDonationBtn
                    ? html`<a @click=${onDonation} href="javascript:void(0)" class="donate">Donate</a>`
                    : nothing
                    } 
            </div>
        </div>
    </div>
</section>`;

export async function detailsView(ctx) {
    const petId = ctx.params.id;
    const user = userService.getUser();
    const userId = user._id;

    const [pet, donations, hasDonation] = await Promise.all([
        requestService.getById(petId),
        requestService.getDonations(petId),
        user ? requestService.getDonationByUser(petId, userId) : 0
    ]);

    const isOwner = user && userId === pet._ownerId;
    const hasDonationBtn = user && !isOwner && hasDonation === 0;

    ctx.render(detailsTemplate(pet, isOwner, onDonation, donations, hasDonationBtn, onDelete));

    async function onDonation(){
        await requestService.addDonation(petId);
        ctx.page.redirect(`/details/${petId}`);
    }

    async function onDelete() {
        const confirmed = confirm('Are you sure you want to delete this pet?');
        if (confirmed) {
            await requestService.deleteById(petId);
            ctx.page.redirect('/');
        }
    }
};