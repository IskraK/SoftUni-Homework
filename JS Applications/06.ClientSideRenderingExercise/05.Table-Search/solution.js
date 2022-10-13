import { render } from '../node_modules/lit-html/lit-html.js';
import { tableTemplate } from './template.js';
import { getTableData } from './api.js';

const tbody = document.querySelector('tbody');
const searchField = document.getElementById('searchField');

async function renderTable() {
   const data = Object.values(await getTableData());
   render(tableTemplate(data), tbody);
}

document.querySelector('#searchBtn').addEventListener('click', onClick);
function onClick() {
   if (!searchField.value.trim()) {
      alert('Enter valid input data!');
      return;
   }

   const rows = Array.from(tbody.querySelectorAll('tr'));

   for (const row of rows) {
      if (row.textContent.toLowerCase().includes(searchField.value.trim().toLowerCase())) {
         row.classList.add('select');
      } else {
         row.classList.remove('select');
      }
   }

   searchField.value = '';
}

renderTable();