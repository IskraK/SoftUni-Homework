window.addEventListener('load', solve);

function solve() {
    const modelField = document.getElementById('model');
    const yearField = document.getElementById('year');
    const descriptionField = document.getElementById('description');
    const priceField = document.getElementById('price');
    const addBtn = document.getElementById('add');
    const furnitureList = document.getElementById('furniture-list');
    const totalPriceField = document.querySelector('.total-price');

    addBtn.addEventListener('click', addFurniture);

    function addFurniture(ev) {
        ev.preventDefault();

        const model = modelField.value;
        const year = Number(yearField.value);
        const description = descriptionField.value;
        const price = Number(priceField.value);

        if (year <= 0 || price <= 0) {
            return;
        }

        if (!model || !description || !year || !price) {
            return;
        }

        const productElement = document.createElement('tr');
        productElement.classList.add('info');

        const modelElement = document.createElement('td');
        modelElement.textContent = model;

        const priceElement = document.createElement('td');
        priceElement.textContent = price.toFixed(2);

        const actionsElement = document.createElement('td');
        const infoBtn = document.createElement('button');
        const buyBtn = document.createElement('button');
        infoBtn.classList.add('moreBtn');
        infoBtn.textContent = 'More Info';
        buyBtn.classList.add('buyBtn');
        buyBtn.textContent = 'Buy it';

        actionsElement.appendChild(infoBtn);
        actionsElement.appendChild(buyBtn);
        productElement.appendChild(modelElement);
        productElement.appendChild(priceElement);
        productElement.appendChild(actionsElement);
        furnitureList.appendChild(productElement);

        const infoElement = document.createElement('tr');
        infoElement.classList.add('hide');
        infoElement.style.display = 'none';

        const yearElement = document.createElement('td');
        yearElement.textContent = `Year: ${year}`;

        const descriptionElement = document.createElement('td');
        descriptionElement.setAttribute('colspan', 3);
        descriptionElement.textContent = `Description: ${description}`;

        infoElement.appendChild(yearElement);
        infoElement.appendChild(descriptionElement);
        furnitureList.appendChild(infoElement);

        infoBtn.addEventListener('click', (ev) => {
            if (ev.currentTarget.textContent == 'More Info') {
                ev.currentTarget.textContent = 'Less Info';
                infoElement.style.display = 'contents';
            } else {
                ev.currentTarget.textContent = 'More Info';
                infoElement.style.display = 'none';
            }
        });

        buyBtn.addEventListener('click', () => {
            let totalPrice = Number(totalPriceField.textContent);
            totalPrice += price;
            totalPriceField.textContent = totalPrice.toFixed(2);

            furnitureList.removeChild(productElement);
            furnitureList.removeChild(infoElement);
        });

        modelField.value = '';
        yearField.value = '';
        descriptionField.value = '';
        priceField.value = '';
    }
}
