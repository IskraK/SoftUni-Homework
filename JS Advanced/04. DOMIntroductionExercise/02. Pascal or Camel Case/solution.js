// function solve() {
//   const text = document.getElementById('text').value.toLowerCase();
//   const caseType = document.getElementById('naming-convention').value;

//   let result = '';

//   if (caseType === 'Camel Case') {
//     result += text[0];
//     for (let i = 1; i < text.length; i++) {
//       if (text[i] === ' ') {
//         result += text[i + 1].toUpperCase();
//         i++;
//       } else {
//         result += text[i];
//       }
//     }
//   } else if (caseType === 'Pascal Case') {
//     result += text[0].toUpperCase();

//     for (let i = 1; i < text.length; i++) {
//       if (text[i] === ' ') {
//         result += text[i + 1].toUpperCase();
//         i++;
//       } else {
//         result += text[i];
//       }
//     }
//   } else {
//     result = 'Error!';
//   }

//   document.getElementById('result').textContent = result;

//   return result;
// }

////second decision
// function solve() {
//   const text = document.getElementById('text').value.toLowerCase();
//   const caseType = document.getElementById('naming-convention').value;

//   let result = '';

//   if (caseType === 'Camel Case') {
//     result += text[0];
//     transform(text);
//   } else if (caseType === 'Pascal Case') {
//     result += text[0].toUpperCase();

//     transform(text);
//   } else {
//     result = 'Error!';
//   }

//   function transform(text) {
//     for (let i = 1; i < text.length; i++) {
//       if (text[i] === ' ') {
//         result += text[i + 1].toUpperCase();
//         i++;
//       } else {
//         result += text[i];
//       }
//     }
//   }

//   document.getElementById('result').textContent = result;

//   return result;
// }

//third decision
function solve() {
  const text = document.getElementById('text').value.toLowerCase();
  const caseType = document.getElementById('naming-convention').value;

  let result = '';

  if (caseType === 'Camel Case') {
    result = transform(text);
    result = result[0].toLowerCase().concat(result.slice(1));
  } else if (caseType === 'Pascal Case') {
    result = transform(text);
  } else {
    result = 'Error!';
  }

  function transform(text) {
    return text
      .split(' ')
      .map(word => word[0]
        .toUpperCase()
        .concat(word.slice(1)))
      .join('');
  }

  document.getElementById('result').textContent = result;

  return result;
}