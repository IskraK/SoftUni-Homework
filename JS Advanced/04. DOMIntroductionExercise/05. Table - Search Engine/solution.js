function solve() {
   document.querySelector('#searchBtn').addEventListener('click', onClick);
   let search = document.getElementById('searchField');
   let rows = document.querySelectorAll('tbody tr');

   function onClick() {
      for (let row of rows) {
         row.classList.remove('select');

         if (search.value !== '' && row.innerHTML.includes(search.value)) {
            row.className = 'select';
         }
      }

      search.value = '';
   }
}


////second decision
// function solve() {
//    document.querySelector('#searchBtn').addEventListener('click', onClick);

//    function onClick() {
//       const rows = Array.from(document.querySelectorAll('tbody tr'));
//       const search = document.getElementById('searchField').value.toLowerCase();

//       rows.forEach((el) => {
//          let textEl = el.textContent.toLowerCase();
//          if (textEl.includes(search)) {
//             el.classList.add('select');
//          } else {
//             el.classList.remove('select');
//          }
//       });
//    }
// }