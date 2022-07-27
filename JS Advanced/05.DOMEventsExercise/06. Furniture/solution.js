function solve() {
  let textarea = document.querySelectorAll('textarea');
  let tbody = document.querySelector('tbody');

  [...document.querySelectorAll('button')].forEach(btn => btn.addEventListener('click', onClick));

  function onClick(ev) {
    if (ev.target.textContent === 'Generate') {
      let input = JSON.parse(textarea[0].value);
      input.forEach(item => {
        tbody.innerHTML += `<tr>
          <td><img src=${item.img}></td>
          <td><p>${item.name}</p></td>
          <td><p>${item.price}</p></td>
          <td><p>${item.decFactor}</p></td>
          <td><input type="checkbox"/></td>
          </tr>`
      });
    } else {
      let names = [];
      let totalPrice = 0;
      let sumDecFactor = 0;

      [...document.querySelectorAll('input:checked')].forEach(item => {
        let parentRow = item.parentNode.parentNode;
        names.push(parentRow.children[1].textContent);
        totalPrice += Number(parentRow.children[2].textContent);
        sumDecFactor += Number(parentRow.children[3].textContent);
      });

      textarea[1].value += `Bought furniture: ${names.join(', ')}\n` +
        `Total price: ${totalPrice.toFixed(2)}\n` +
        `Average decoration factor: ${sumDecFactor / names.length}`;
    }
  }
}