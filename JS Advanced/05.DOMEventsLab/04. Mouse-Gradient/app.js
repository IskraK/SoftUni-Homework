function attachGradientEvents() {
    const gradient = document.getElementById('gradient');
    gradient.addEventListener('mousemove', onMove);
    const output = document.getElementById('result');

    function onMove(ev) {
        const box = ev.target;
        const offSet = Math.floor(ev.offsetX / box.clientWidth * 100);

        output.textContent = `${offSet}%`;
    }
}

////second decision
function attachGradientEvents() {
    document.getElementById('gradient').addEventListener('mousemove', onMove);
    const output = document.getElementById('result');

    function onMove(ev) {
        // const offsetX = ev.pageX - ev.target.offsetLeft; ////doesn't work in Judge
        const offsetX = ev.offsetX;
        const percent = Math.floor(offsetX / ev.target.clientWidth * 100);

        output.textContent = `${percent}%`;
    }
}