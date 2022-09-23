function solve() {
    const departBtn = document.getElementById('depart');
    const arriveBtn = document.getElementById('arrive');
    const infoSpan = document.querySelector('#info span');

    let stop = {
        next: 'depot'
    };

    async function depart() {
        const url = `http://localhost:3030/jsonstore/bus/schedule/${stop.next}`;

        try {
            const response = await fetch(url);
            const data = await response.json();

            stop = data;
            infoSpan.textContent = `Next stop ${stop.name}`;

            disableButtons(true, false);
        } catch (error) {
            infoSpan.textContent = 'Error';
            disableButtons(true, true);
        }
    }

    function arrive() {
        infoSpan.textContent = `Arriving at ${stop.name}`;
        disableButtons(false, true);
    }

    return {
        depart,
        arrive
    };

    function disableButtons(d, e) {
        departBtn.disabled = d;
        arriveBtn.disabled = e;
    }
}

let result = solve();