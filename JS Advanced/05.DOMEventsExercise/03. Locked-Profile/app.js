function lockedProfile() {
    [...document.querySelectorAll('.profile button')].forEach(b => b.addEventListener('click', onClick));

    function onClick(ev) {
        const profile = ev.target.parentNode;
        const isActive = profile.querySelector('input[type="radio"][value="unlock"]').checked;

        if (isActive) {
            const moreInfo = profile.querySelector('div');
            const button = ev.target;

            if (button.textContent == 'Show more') {
                moreInfo.style.display = 'block';
                button.textContent = 'Hide it';
            } else {
                moreInfo.style.display = 'none';
                button.textContent = 'Show more';
            }
        }
    }
}