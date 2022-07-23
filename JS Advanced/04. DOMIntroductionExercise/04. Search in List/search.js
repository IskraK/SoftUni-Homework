function search() {
   let search = document.getElementById('searchText').value;
   let towns = [...document.getElementsByTagName('li')];
   let match = document.getElementById('result');
   let count = 0;

   for (const town of towns) {
      if (town.textContent.includes(search) && search !== '') {
         town.style.fontWeight = 'bold';
         town.style.textDecoration = 'underline';
         count++;
      } else {
         town.style.fontWeight = 'normal';
         town.style.textDecoration = 'none';
      }

      match.textContent = `${count} matches found`;
   }
}
