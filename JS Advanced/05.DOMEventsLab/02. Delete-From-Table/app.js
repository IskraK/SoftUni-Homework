//// function deleteByEmail() {
//     const email = document.querySelector('input[name="email"]').value;
//     const rows = Array.from(document.querySelectorAll('tbody tr'));
//     const result = document.getElementById('result');

//     for (const row of rows) {
//         if (row.querySelectorAll('td')[1].textContent == email) {
//             row.parentNode.removeChild(row);
//             result.textContent = 'Deleted.';
//         } else {
//             result.textContent = 'Not found.';
//         }
//     }
// }

//second decision
function deleteByEmail() {
    const email = document.querySelector('input[name="email"]').value;
    const rows = Array.from(document.querySelectorAll('tbody tr'));
    const result = document.getElementById('result');
    
    const matches = rows.filter(r => r.children[1].textContent.trim() == email);

    if (matches.length > 0) {
        matches.forEach(r => r.remove());
        result.textContent = 'Deleted.';
    } else {
        result.textContent = 'Not found.';
    }
}

// //third decision
// function deleteByEmail() {
//     const inputField = document.querySelector('input[name="email"]');

//     const rows = Array.from(document.querySelector('tbody').children)
//         .filter(r => r.children[1].textContent == inputField.value.trim());

//     rows.forEach(r => r.remove());

//     document.getElementById('result').textContent = rows.length > 0 ? 'Deleted.' : 'Not found.';
//     inputField.value = '';
// }