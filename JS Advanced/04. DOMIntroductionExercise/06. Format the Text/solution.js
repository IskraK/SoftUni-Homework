function solve() {
  const sentences = document.getElementById('input').value
    .split('.')
    .filter(s => s.length > 0);
  const output = document.getElementById('output');

  for (let i = 0; i < sentences.length; i += 3) {
    let textArray = [];

    for (let j = 0; j < 3; j++) {
      if (sentences[i + j]) {
        textArray.push(sentences[i + j]);
      }
    }

    let paragraph = textArray.join('. ') + '.';
    output.innerHTML += `<p>${paragraph}</p>`;
  }
}