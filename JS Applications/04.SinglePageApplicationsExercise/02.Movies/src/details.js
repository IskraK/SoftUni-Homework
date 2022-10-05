import { showView, spinner } from './util.js';
import { homePage } from './home.js';
import { editPage } from './edit.js';

const detailsSection = document.querySelector('#movie-example');

export function detailsPage(id) {
    showView(detailsSection);
    displayMovie(id);
}

async function displayMovie(id) {
    detailsSection.replaceChildren(spinner());

    const user = JSON.parse(localStorage.getItem('user'));
    const [movie, likes, ownLike] = await Promise.all([
        getMovie(id),
        getLikes(id),
        getOwnLike(id, user)
    ]);
    detailsSection.replaceChildren(createMovieCard(movie, user, likes, ownLike));
}

function createMovieCard(movie, user, likes, ownLike) {
    const element = document.createElement('div');
    element.classList.add('container');
    element.innerHTML = `
        <div class="row bg-light text-dark">
            <h1>Movie title: ${movie.title}</h
            <div class="col-md-8">
                <img class="img-thumbnail" src="${movie.img}" alt="Movie">
            </div>
            <div class="col-md-4 text-center">
                <h3 class="my-3 ">Movie Description</h3>
                <p>${movie.description}</p>
                ${createControls(movie, user, likes, ownLike)}
            </div>
        </div>`;

    const likeBtn = element.querySelector('.like-btn');
    if (likeBtn) {
        likeBtn.addEventListener('click', (ev) => likeMovie(ev, movie._id));
    }

    const deleteBtn = element.querySelector('.btn.btn-danger');
    if (deleteBtn) {
        deleteBtn.addEventListener('click', (ev) => deleteMovie(ev, movie._id));
    }

    const editBtn = element.querySelector('.btn.btn-warning');
    if (editBtn) {
        editBtn.addEventListener('click', () => editPage(movie._id));
    }

    return element;
}

function createControls(movie, user, likes, ownLike) {
    const isOwner = user && user._id == movie._ownerId;
    let controls = [];

    if (isOwner) {
        controls.push(`<a class="btn btn-danger" href="#">Delete</a>`);
        controls.push(`<a class="btn btn-warning" href="#">Edit</a>`);
    } else if (user && ownLike == false) {
        controls.push(`<a class="btn btn-primary like-btn" href="#">Like</a>`);
    }

    controls.push(`<span class="enrolled-span">${likes}</span>`);

    return controls.join('');
}

export async function getMovie(id) {
    const response = await fetch(`http://localhost:3030/data/movies/${id}`);
    const movie = await response.json();

    return movie;
}

async function getLikes(id) {
    const response = await fetch(`http://localhost:3030/data/likes?where=movieId%3D%22${id}%22&distinct=_ownerId&count`);
    const likes = await response.json();

    return likes;
}

async function getOwnLike(movieId, user) {
    if (!user) {
        return false;
    } else {
        const userId = user._id;

        const response = await fetch(`http://localhost:3030/data/likes?where=movieId%3D%22${movieId}%22%20and%20_ownerId%3D%22${userId}%22`);
        const like = await response.json();

        return like.length > 0;
    }
}

async function likeMovie(ev, movieId) {
    ev.preventDefault();
    const user = JSON.parse(localStorage.getItem('user'));

    await fetch('http://localhost:3030/data/likes', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
            'X-Authorization': user.accessToken
        },
        body: JSON.stringify({ movieId })
    });

    detailsPage(movieId);
}

async function deleteMovie(ev, movieId) {
    ev.preventDefault();
    const user = JSON.parse(localStorage.getItem('user'));
    const confirmed = confirm('Are you sure you want to delete this movie?');

    if (confirmed) {
        const response = await fetch('http://localhost:3030/data/movies/' + movieId, {
            method: 'DELETE',
            headers: {
                'X-Authorization': user.accessToken
            }
        });
        if (response.ok) {
            alert('Movie deleted');
            homePage();
        } else {
            const error = await response.json();
            alert(error.message);
            console.log(error.message);
        }
    }
}