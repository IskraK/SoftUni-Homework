window.addEventListener("load", solve);

function solve() {
    const makeField = document.getElementById('make');
    const modelField = document.getElementById('model');
    const yearField = document.getElementById('year');
    const fuelField = document.getElementById('fuel');
    const originalCostField = document.getElementById('original-cost');
    const sellingPriceField = document.getElementById('selling-price');
    const publishBtn = document.getElementById('publish');
    const tbodyElement = document.getElementById('table-body');
    const carsListElement = document.getElementById('cars-list');
    const profitElement = document.getElementById('profit');

    publishBtn.addEventListener('click', (ev) => {
        ev.preventDefault();

        const make = makeField.value;
        const model = modelField.value;
        const year = yearField.value;
        const fuel = fuelField.value;
        const originalCost = originalCostField.value;
        const sellingPrice = sellingPriceField.value;

        if (!make || !model || !year || !fuel || !originalCost || !sellingPrice) {
            return;
        }

        if (Number(originalCost) >= Number(sellingPrice)) {
            return;
        }

        const rowElement = el('tr');
        rowElement.classList.add('row');

        const makeCell = el('td', `${make}`, rowElement);
        const modelCell = el('td', `${model}`, rowElement);
        const yearCell = el('td', `${year}`, rowElement);
        const fuelCell = el('td', `${fuel}`, rowElement);
        const originalCostCell = el('td', `${originalCost}`, rowElement);
        const sellingPriceCell = el('td', `${sellingPrice}`, rowElement);
        const actionsCell = el('td', '', rowElement);
        const editBtn = el('button', 'Edit', actionsCell);
        const sellBtn = el('button', 'Sell', actionsCell);
        editBtn.classList.add('action-btn');
        editBtn.classList.add('edit');
        sellBtn.classList.add('action-btn');
        sellBtn.classList.add('sell');

        tbodyElement.appendChild(rowElement);

        clearInputFields();

        editBtn.addEventListener('click', () => {
            makeField.value = make;
            modelField.value = model;
            yearField.value = year;
            fuelField.value = fuel;
            originalCostField.value = originalCost;
            sellingPriceField.value = sellingPrice;

            rowElement.remove();
        });

        sellBtn.addEventListener('click', () => {
            rowElement.remove();

            const liElement = el('li', '', carsListElement);
            liElement.classList.add('each-list');
            const makeModelSpan = el('span', `${make} ${model}`, liElement);
            const yearSpan = el('span', `${year}`, liElement);
            const differencePrice = Number(sellingPrice) - Number(originalCost);
            const profitSpan = el('span', `${differencePrice}`, liElement);

            const currProfit = Number(profitElement.textContent);
            profitElement.textContent = (currProfit + differencePrice).toFixed(2);
        });
    });

    function clearInputFields() {
        makeField.value = '';
        modelField.value = '';
        yearField.value = '';
        fuelField.value = '';
        originalCostField.value = '';
        sellingPriceField.value = '';
    }

    function el(type, content, parent) {
        const element = document.createElement(type);
        element.textContent = content;

        if (parent) {
            parent.appendChild(element);
        }
        return element;
    }
}