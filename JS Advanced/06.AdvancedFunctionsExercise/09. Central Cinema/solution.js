function solve() {
    const [name, hall, ticketPrice] = document.querySelectorAll('#container input');
    const moviesSection = document.querySelector('#movies ul');
    const archiveSection = document.querySelector('#archive ul');
    const clearButton = archiveSection.parentElement.querySelector('button');
    clearButton.addEventListener('click', () => {
        archiveSection.innerHTML = '';
    });

    const onScreenButton = document.querySelector('#container button');
    onScreenButton.addEventListener('click', addMovie);

    function addMovie(ev) {
        ev.preventDefault();

        if (name.value && hall.value && Number(ticketPrice.value) || ticketPrice.value === '0') {
            const movie = document.createElement('li');
            movie.innerHTML =
                `<span>${name.value}</span>
                <strong>Hall: ${hall.value}</strong>
                <div>
                    <strong>${Number(ticketPrice.value).toFixed(2)}</strong>
                    <input placeholder="Tickets Sold">
                    <button >Archive</button>
                </div>`;

            moviesSection.appendChild(movie);

            const archiveButton = movie.querySelector('div button');
            archiveButton.addEventListener('click', addToArchive);

            name.value = '';
            hall.value = '';
            ticketPrice.value = '';
        }
    }

    function addToArchive(ev) {
        const soldTickets = ev.target.parentElement.querySelector('input');
        const ticketPrice = ev.target.parentElement.querySelector('strong');
        const movieName = ev.target.parentElement.parentElement.querySelector('span');

        if (Number(soldTickets.value) || soldTickets.value === '0') {
            const totalPrice = Number(ticketPrice.textContent) * Number(soldTickets.value);
            const archivedMovie = document.createElement('li');

            archivedMovie.innerHTML = `<span>${movieName.textContent}</span>
                                       <strong>Total amount: ${totalPrice.toFixed(2)}</strong>
                                       <button>Delete</button>`;

            const deleteButton = archivedMovie.querySelector('button');
            deleteButton.addEventListener('click', deleteMovie);
            archiveSection.appendChild(archivedMovie);
        }

        ev.target.parentElement.parentElement.remove();
    }

    function deleteMovie(ev) {
        ev.target.parentElement.remove();
    }
}