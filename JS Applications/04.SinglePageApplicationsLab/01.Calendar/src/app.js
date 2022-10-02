// const sections = document.querySelectorAll('section');
// sections.forEach(s => s.style.display = 'none');

// const yearsSection = sections[0];
// yearsSection.style.display = 'block';
// yearsSection.addEventListener('click', onYear);

// const months = {
//     Jan: 1,
//     Feb: 2,
//     Mar: 3,
//     Apr: 4,
//     May: 5,
//     Jun: 6,
//     Jul: 7,
//     Aug: 8,
//     Sept: 9,
//     Oct: 10,
//     Nov: 11,
//     Dec: 12,
// }

// function onYear(ev){
//     const current = ev.target;
//     if (current.tagName !== 'TD' && current.tagName !== 'DIV') {
//         return;
//     }

//     const year = current.tagName === 'TD' ? current.children[0].textContent : current.textContent;
//     yearsSection.style.display = 'none';

//     setMonth(year);
// }

// function setMonth(year) {
//     const yearId = `year-${year}`;
//     const monthSection = document.getElementById(yearId);
//     monthSection.style.display = 'block';
//     monthSection.addEventListener('click',setDays.bind(null,monthSection,year));
// }

// function setDays(monthSection,year,ev) {
//     monthSection.style.display = 'none';

//     const current = ev.target;
//     if (current.tagName !== 'TD' && current.tagName !== 'DIV') {
//         return;
//     }

//     const month = current.tagName === 'TD' ? current.children[0].textContent : current.textContent;
//     const monthId = `month-${year}-${months[month]}`;

//     const daysSection = document.getElementById(monthId);
//     daysSection.style.display = 'block';
// }



//another decision
import {renderElement} from './render.js';
import {validateYear, validateMonth} from './validator.js';

const yearsBase = document.getElementById('years');
const years = Array.from(document.querySelectorAll('.monthCalendar')).reduce((year, data) => {
    year[data.id] = data;
    return year;
}, {});

const monthsElements = Array.from(document.querySelectorAll('.daysCalendar'));

renderElement(yearsBase);

document.addEventListener('click', (ev) => {
    if (validateYear(ev)) {
        const year = ev.target.textContent.trim();
        renderElement(years[`year-${year}`]);

    } else if (validateMonth(ev)) {
        const year = document.querySelector('caption').textContent;
        const month = ev.target.innerText.trim();
        const monthIndex = months.findIndex(x => x == month);

        if (monthIndex !== -1) {
            const monthElement = monthsElements.find(x => x.id === `month-${year}-${monthIndex + 1}`);
            renderElement(monthElement);
        }
    }

    if (ev.target.tagName == 'CAPTION') {
        const dataText = ev.target.innerText;

        if (dataText.match(/^([1-2]{1}[0-9]{3}) \- ([1-2]{1}[0-9]{3})$/g)) {
            return;
        }

        if (isNaN(dataText)) {
            const year = dataText.match(/[1-2]{1}[0-9]{3}/g);
            renderElement(years[`year-${year}`]);
        } else {
            renderElement(yearsBase);
        }
    }
});

const months = ['Jan', 'Feb', 'Mar', 'Apr', 'May', 'Jun', 'Jul', 'Aug', 'Sep', 'Oct', 'Nov', 'Dec'];