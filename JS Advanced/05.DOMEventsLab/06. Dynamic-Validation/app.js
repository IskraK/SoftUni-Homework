function validate() {
    document.getElementById('email').addEventListener('change', onChange);

    function onChange(ev) {
        const email = ev.target.value;
        const pattern = /^[a-z]+@[a-z]+\.[a-z]+$/;

        if (pattern.test(email)) {
             ev.target.className = '';
            //ev.target.classList.remove('error');

        } else {
            ev.target.className = 'error';
            //ev.target.classList.add('error');
        }
    }
}