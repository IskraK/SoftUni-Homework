function create(words) {
   const content = document.getElementById('content');

   for (const word of words) {
      const div = document.createElement('div');
      const paragraph = document.createElement('p');
      paragraph.textContent = word;
      paragraph.style.display = 'none';
      div.appendChild(paragraph);

      div.addEventListener('click', onClick);
      content.appendChild(div);

      function onClick(ev) {
         ev.target.children[0].style.display = '';
      }
   }
}

// //second decision
// function create(words) {
//    const content = document.getElementById('content');
//    words.forEach((word) => {
//       const div = document.createElement('div');
//       const paragraph = document.createElement('p');
//       paragraph.textContent = word;
//       paragraph.style.display = 'none';
//       div.appendChild(paragraph);

//       div.addEventListener('click', () => paragraph.style.display = '');
//       content.appendChild(div);
//    });
// }