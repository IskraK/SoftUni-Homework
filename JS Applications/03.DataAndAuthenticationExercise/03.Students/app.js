const url = 'http://localhost:3030/jsonstore/collections/students';

const tbody = document.querySelector('#results tbody');
loadStudents();

const form = document.getElementById('form');
form.addEventListener('submit', onSubmit);

function onSubmit(ev) {
    ev.preventDefault();

    const formData = new FormData(ev.currentTarget);

    const firstName = formData.get('firstName');
    const lastName = formData.get('lastName');
    const facultyNumber = formData.get('facultyNumber');
    const grade = formData.get('grade');

    if (firstName === '' || lastName === '' || facultyNumber === '' || grade === '') {
        return alert('The fields are required!');
    }

    if (isNaN(Number(facultyNumber)) || isNaN(Number(grade))) {
        return alert('Enter valid numeric values for Faculty Number or Grade!');
    }

    fetch(url, {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify({
            firstName,
            lastName,
            facultyNumber,
            grade
        })
    })
        .then(() => createTableRow(firstName, lastName, facultyNumber, grade))
        .catch(error => console.log(error.message));

    form.reset();
}

async function loadStudents() {
    try {
        const response = await fetch(url);
        const data = await response.json();

        Object.values(data).forEach(s => createTableRow(s.firstName, s.lastName, s.facultyNumber, s.grade));
    } catch (error) {
        console.log(error.message);
    }
}

function createTableRow(firstName, lastName, facultyNumber, grade) {
    const row = document.createElement('tr');

    const firstNameCell = document.createElement('td');
    firstNameCell.textContent = firstName;

    const lastNameCell = document.createElement('td');
    lastNameCell.textContent = lastName;

    const facultyNumberCell = document.createElement('td');
    facultyNumberCell.textContent = facultyNumber;

    const gradeCell = document.createElement('td');
    gradeCell.textContent = grade;

    row.appendChild(firstNameCell);
    row.appendChild(lastNameCell);
    row.appendChild(facultyNumberCell);
    row.appendChild(gradeCell);
    tbody.appendChild(row);
}