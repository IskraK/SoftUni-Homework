import { html, render } from '../node_modules/lit-html/lit-html.js';
import { towns } from './towns.js';

const townsList = document.getElementById('towns');
const searchBtn = document.querySelector('button');
searchBtn.addEventListener('click', search);

const template = (towns) => html`
<ul>
   ${towns.map(townTemplate)}
</ul>`;

const townTemplate = (town) => html`<li>${town}</li>`;

render(template(towns), townsList);

function search() {
   let searchText = document.getElementById('searchText');
   const matches = document.getElementById('result');
   const towns = [...document.querySelectorAll('#towns li')];
   let countMatches = 0;

   for (const town of towns) {
      if (town.textContent.toLowerCase().includes(searchText.value.toLowerCase()) && searchText != '') {
         town.classList.add('active');
         countMatches++;
      } else {
         town.classList.remove('active');
      }
   }

   searchText.value = '';
   matches.textContent = `${countMatches} matches found`;
}
