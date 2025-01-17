import { html } from '../../node_modules/lit-html/lit-html.js';
import * as requestService from '../services/requestService.js';


const editTemplate = (pet, onSubmit) => html`
<section id="editPage">
    <form @submit=${onSubmit} class="editForm">
        <img src="./images/editpage-dog.jpg">
        <div>
            <h2>Edit PetPal</h2>
            <div class="name">
                <label for="name">Name:</label>
                <input name="name" id="name" type="text" .value=${pet.name}>
            </div>
            <div class="breed">
                <label for="breed">Breed:</label>
                <input name="breed" id="breed" type="text" .value=${pet.breed}>
            </div>
            <div class="Age">
                <label for="age">Age:</label>
                <input name="age" id="age" type="text" .value="${pet.age} years">
            </div>
            <div class="weight">
                <label for="weight">Weight:</label>
                <input name="weight" id="weight" type="text" value="${pet.weight}kg">
            </div>
            <div class="image">
                <label for="image">Image:</label>
                <input name="image" id="image" type="text" .value=${pet.image}>
            </div>
            <button class="btn" type="submit">Edit Pet</button>
        </div>
    </form>
</section>`;

export async function editView(ctx) {
    const petId = ctx.params.id;
    const pet = await requestService.getById(petId);

    async function onSubmit(ev) {
        ev.preventDefault();

        const data = Object.fromEntries(new FormData(ev.currentTarget));

        if (Object.values(data).some(x => x.trim() === '')) {
            return alert('All fields are required!');
        }

        await requestService.update(petId, {
            name: data.name,
            breed: data.breed,
            age: data.age,
            weight: data.weight,
            image: data.image
        });
        ev.target.reset();
        ctx.page.redirect('/details/' + petId);
    }

    ctx.render(editTemplate(pet, onSubmit));
};