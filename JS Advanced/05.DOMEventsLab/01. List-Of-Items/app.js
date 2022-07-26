// function addItem() {
//     const text = document.getElementById('newItemText').value;
//     const newLi = document.createElement('li');
//     newLi.textContent = text;
//     const ul = document.getElementById('items');
//     ul.appendChild(newLi);
//     document.getElementById('newItemText').value = '';
// }


//short decision
function addItem() {
    const newLi = document.createElement('li');
    newLi.textContent = document.getElementById('newItemText').value;
    document.getElementById('items').appendChild(newLi);
    document.getElementById('newItemText').value = '';
}