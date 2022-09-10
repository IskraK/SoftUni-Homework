window.addEventListener("load", solve);

function solve() {

  const titleField = document.getElementById('post-title');
  const categoryField = document.getElementById('post-category');
  const contentField = document.getElementById('post-content');
  const publishBtn = document.getElementById('publish-btn');
  const reviewList = document.getElementById('review-list');
  const publishedList = document.getElementById('published-list');
  const clearBtn = document.getElementById('clear-btn');

  publishBtn.addEventListener('click', publish);

  function publish(ev) {
    ev.preventDefault();

    const title = titleField.value;
    const category = categoryField.value;
    const content = contentField.value;

    if (!title || !category || !content) {
      return;
    }

    const liElement = el('li', '', 'rpost');
    const articleElement = el('article');
    const h4 = el('h4', `${title}`);
    const pCategory = el('p', `Category: ${category}`);
    const pContent = el('p', `Content: ${content}`);
    const editBtn = el('button', 'Edit', 'action-btn edit');
    const approveBtn = el('button', 'Approve', 'action-btn approve');

    articleElement.appendChild(h4);
    articleElement.appendChild(pCategory);
    articleElement.appendChild(pContent);
    liElement.appendChild(articleElement);
    liElement.appendChild(editBtn);
    liElement.appendChild(approveBtn);
    reviewList.appendChild(liElement);

    clearInputFields();

    editBtn.addEventListener('click', () => {
      titleField.value = title;
      categoryField.value = category;
      contentField.value = content;
      liElement.remove();
    });

    approveBtn.addEventListener('click', () => {
      liElement.removeChild(editBtn);
      liElement.removeChild(approveBtn);
      publishedList.appendChild(liElement);
    });
  }

  clearBtn.addEventListener('click', () => {
    publishedList.innerHTML = '';
  });

  function clearInputFields() {
    titleField.value = '';
    categoryField.value = '';
    contentField.value = '';
  }

  function el(type, content, className) {
    const element = document.createElement(type);
    element.textContent = content;
    if (className) {
      element.className = className;
    }
    return element;
  }
}

