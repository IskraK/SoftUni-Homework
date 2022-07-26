////doesn't work in Judge because of forEach
// function focused() {
//     document.querySelectorAll('input').forEach(i => {
//         i.addEventListener('focus', onFocus);
//         i.addEventListener('blur', onBlur);
//     });

//     function onFocus(ev) {
//         ev.target.parentNode.className = 'focused';
//     }

//     function onBlur(ev) {
//         ev.target.parentNode.className = '';
//     }
// }


function focused() {
    const fields = Array.from(document.getElementsByTagName('input'));

    for (const field of fields) {
        field.addEventListener('focus', onFocus);
        field.addEventListener('blur', onBlur);
    }

    function onFocus(ev) {
        ev.target.parentNode.className = 'focused';
    }

    function onBlur(ev) {
        ev.target.parentNode.className = '';
    }
}