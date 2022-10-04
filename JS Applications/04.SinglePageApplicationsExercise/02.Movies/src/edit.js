import { showView } from './util.js';
import { detailsPage, getMovie } from './details.js';

let movieId;
const editSection = document.querySelector('#edit-movie');
const form = editSection.querySelector('form');
form.addEventListener('submit', onSubmit);

export async function editPage(id) {
    movieId = id;
    showView(editSection);
    const movie = await getMovie(id);
    const fields = form.querySelectorAll('.form-control');
    fields[0].value = movie.title;
    fields[1].value = movie.description;
    fields[2].value = movie.img;
}

async function onSubmit(ev) {
    ev.preventDefault();

    const formData = new FormData(form);
    const title = formData.get('title');
    const description = formData.get('description');
    const img = formData.get('imageUrl');

    await editMovie(title, description, img);
    form.reset();
    detailsPage(movieId);
}

async function editMovie(title, description, img) {
    const user = JSON.parse(localStorage.getItem('user'));

    await fetch('http://localhost:3030/data/movies/' + movieId, {
        method: 'PUT',
        headers: {
            'Content-Type': 'application/json',
            'X-Authorization': user.accessToken
        },
        body: JSON.stringify({ title, description, img })
    })
}