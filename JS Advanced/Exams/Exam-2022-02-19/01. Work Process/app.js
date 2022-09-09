function solve() {
    const firstNameField = document.getElementById('fname');
    const lastNameField = document.getElementById('lname');
    const emailField = document.getElementById('email');
    const birthField = document.getElementById('birth');
    const positionField = document.getElementById('position');
    const salaryField = document.getElementById('salary');
    const addBtn = document.getElementById('add-worker');
    const tbody = document.getElementById('tbody');
    const totalBudget = document.getElementById('sum');

    addBtn.addEventListener('click', (ev) => {
        if (!firstNameField.value && !lastNameField.value
            && !emailField.value && !birthField.value
            && positionField.value && salaryField.value) {
            return;
        }

        addWorker(ev);
        clearInputFields();
    });

    function addWorker(ev) {
        ev.preventDefault();

        const firstName = firstNameField.value
        const lastName = lastNameField.value;
        const email = emailField.value;
        const birth = birthField.value;
        const position = positionField.value;
        const salary = salaryField.value;

        const rowElement = el('tr');
        const fnameCell = el('td', firstName);
        const lnameCell = el('td', lastName);
        const emailCell = el('td', email);
        const birthCell = el('td', birth);
        const positionCell = el('td', position);
        const salaryCell = el('td', salary);
        const actionCell = el('td');
        const firedBtn = el('button', 'Fired');
        firedBtn.classList.add('fired');
        const editBtn = el('button', 'Edit');
        editBtn.classList.add('edit');

        actionCell.appendChild(firedBtn);
        actionCell.appendChild(editBtn);
        rowElement.appendChild(fnameCell);
        rowElement.appendChild(lnameCell);
        rowElement.appendChild(emailCell);
        rowElement.appendChild(birthCell);
        rowElement.appendChild(positionCell);
        rowElement.appendChild(salaryCell);
        rowElement.appendChild(actionCell);
        tbody.appendChild(rowElement);

        let currentBudget = Number(totalBudget.textContent);
        currentBudget += Number(salary);
        totalBudget.textContent = currentBudget.toFixed(2);

        editBtn.addEventListener('click', () => {
            firstNameField.value = firstName;
            lastNameField.value = lastName;
            emailField.value = email;
            birthField.value = birth;
            positionField.value = position;
            salaryField.value = salary;

            tbody.removeChild(rowElement);
            totalBudget.textContent = (Number(totalBudget.textContent) - Number(salary)).toFixed(2);
        });

        firedBtn.addEventListener('click', () => {
            totalBudget.textContent = (Number(totalBudget.textContent) - Number(salaryCell.textContent)).toFixed(2);
            tbody.removeChild(rowElement);
        });
    }

    function el(type, content) {
        const element = document.createElement(type);
        element.textContent = content;

        return element;
    }

    function clearInputFields() {
        firstNameField.value = '';
        lastNameField.value = '';
        emailField.value = '';
        birthField.value = '';
        positionField.value = '';
        salaryField.value = '';
    }
}
solve()