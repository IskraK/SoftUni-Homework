window.addEventListener('load', solution);

function solution() {
  const submitBtn = document.getElementById('submitBTN');
  const edittBtn = document.getElementById('editBTN');
  const continueBtn = document.getElementById('continueBTN');
  const previewElement = document.getElementById('infoPreview');
  const blockElement = document.getElementById('block');
  const inputFields = Array.from(document.getElementById('form').querySelectorAll('input'));
  const labelElements = Array.from(document.getElementById('form').querySelectorAll('label'));
  inputFields.pop();

  submitBtn.addEventListener('click', (ev) => {
    const fullName = inputFields[0];
    const email = inputFields[1];

    if (fullName.value == '' || email.value == '') {
      return;
    }

    for (let i = 0; i < inputFields.length; i++) {
      const liElement = document.createElement('li');
      liElement.textContent = `${labelElements[i].textContent} ${inputFields[i].value}`;
      previewElement.appendChild(liElement);
    }

    for (const input of inputFields) {
      input.value = '';
    }

    ev.target.disabled = true;
    edittBtn.disabled = false;
    continueBtn.disabled = false;
  });

  edittBtn.addEventListener('click', () => {
    const liItems = Array.from(previewElement.childNodes);

    for (let i = 0; i < inputFields.length; i++) {
      inputFields[i].value = liItems[i].textContent.split(': ')[1];
      liItems[i].remove();
    }

    submitBtn.disabled = false;
    edittBtn.disabled = true;
    continueBtn.disabled = true;
  });

  continueBtn.addEventListener('click', () => {
    blockElement.innerHTML = '';

    const h3Element = document.createElement('h3');
    h3Element.textContent = 'Thank you for your reservation!';
    blockElement.appendChild(h3Element);
  });
}
