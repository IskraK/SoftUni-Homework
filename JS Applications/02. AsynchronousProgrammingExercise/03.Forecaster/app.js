// function attachEvents() {
//     const locationField = document.getElementById('location');
//     const getWeatherBtn = document.getElementById('submit');
//     const forecast = document.getElementById('forecast');
//     const current = document.getElementById('current');
//     const upcoming = document.getElementById('upcoming');
//     const label = document.querySelector('.label');

//     getWeatherBtn.addEventListener('click', getWeather);

//     async function getWeather() {
//         try {
//             const locationName = locationField.value;
//             const code = await getCode(locationName);

//             const [currentData, upcomingData] = await Promise.all([
//                 getCurrent(code),
//                 getUpcoming(code)
//             ]);

//             forecast.style.display = 'block';

//             createCurrent(currentData);
//             createUpcoming(upcomingData);
//         } catch (error) {
//             label.textContent = 'Error';
//             forecast.style.display = '';
//             upcoming.style.display = 'none';
//         }

//     }

//     async function getCode(locationName) {
//         const url = 'http://localhost:3030/jsonstore/forecaster/locations';

//         const response = await fetch(url);
//         const data = await response.json();

//         return data.find(x => x.name.toLowerCase() == locationName.toLowerCase()).code;
//     }

//     async function getCurrent(code) {
//         const url = `http://localhost:3030/jsonstore/forecaster/today/${code}`;

//         const response = await fetch(url);
//         const data = await response.json();

//         return data;
//     }

//     async function getUpcoming(code) {
//         const url = `http://localhost:3030/jsonstore/forecaster/upcoming/${code}`;

//         const response = await fetch(url);
//         const data = await response.json();

//         return data;
//     }

//     function createCurrent(data) {
//         const divElement = el('div', '', 'forecasts');
//         const conditionSymbolSpan = el('span', getWeatherSymbol(data.forecast.condition), 'condition symbol');
//         const conditionSpan = el('span', '', 'condition');
//         const nameSpan = el('span', data.name, 'forecast-data');
//         const tempSpan = el('span', `${data.forecast.low}°/${data.forecast.high}°`, 'forecast-data');
//         const conditionTextSpan = el('span', data.forecast.condition, 'forecast-data');

//         conditionSpan.appendChild(nameSpan);
//         conditionSpan.appendChild(tempSpan);
//         conditionSpan.appendChild(conditionTextSpan);

//         divElement.appendChild(conditionSymbolSpan);
//         divElement.appendChild(conditionSpan);

//         current.appendChild(divElement);
//     }

//     function createUpcoming(data) {
//         const divElement = el('div', '', 'forecast-info');

//         data.forecast.forEach(e => {
//             const upcomingSpan = el('span', '', 'upcoming');
//             const conditionSymbolSpan = el('span', getWeatherSymbol(e.condition), 'symbol');
//             const tempSpan = el('span', `${e.low}°/${e.high}°`, 'forecast-data');
//             const conditionTextSpan = el('span', e.condition, 'forecast-data');

//             upcomingSpan.appendChild(conditionSymbolSpan);
//             upcomingSpan.appendChild(tempSpan);
//             upcomingSpan.appendChild(conditionTextSpan);
//             divElement.appendChild(upcomingSpan);
//         });

//         upcoming.appendChild(divElement);
//     }

//     function el(type, content, className) {
//         const element = document.createElement(type);
//         element.textContent = content;
//         element.className = className;

//         return element;
//     }

//     function getWeatherSymbol(condition) {
//         const types = {
//             'Sunny': '&#x2600;',
//             'Partly sunny': '&#x26C5;',
//             'Overcast': '&#x2601;',
//             'Rain': '&#x2614;',
//             'Degrees': '&#176;'
//         };

//         return types[condition];
//     }
// }

// attachEvents();


function attachEvents() {
    const idField = document.getElementById('location');
    const submitBtn = document.getElementById('submit');
    const forecast = document.getElementById('forecast');
    const current = document.getElementById('current');
    const upcoming = document.getElementById('upcoming');
    const label = document.querySelector('.label');

    submitBtn.addEventListener('click', getData);

    async function getData() {
        try {
            const locationUrl = `http://localhost:3030/jsonstore/forecaster/today/${idField.value}`;
            const response = await fetch(locationUrl);
            const data = await response.json();

            const upcomingUrl = `http://localhost:3030/jsonstore/forecaster/upcoming/${idField.value}`;
            const res = await fetch(upcomingUrl);
            const dataUpcoming = await res.json();

            forecast.style.display = 'block';

            createCurrent(data);
            createUpcoming(dataUpcoming);

        } catch (error) {
            label.textContent = 'Error';
            forecast.style.display = '';
            upcoming.style.display = 'none';
        }
    }

    function createCurrent(data) {
        const divForecasts = createComponent('div', '', 'forecasts');
        const conditionSymbol = createComponent('span', getWeatherIcon(data.forecast.condition), 'condition symbol')
        const spanCondition = createComponent('span', '', 'condition');
        const forecastDataOne = createComponent('span', data.name, 'forecast-data');
        const forecastDataTwo = createComponent('span', `${data.forecast.low}°/${data.forecast.high}°`, 'forecast-data');
        const forecastDataThree = createComponent('span', data.forecast.condition, 'forecast-data');

        spanCondition.appendChild(forecastDataOne);
        spanCondition.appendChild(forecastDataTwo);
        spanCondition.appendChild(forecastDataThree);

        divForecasts.appendChild(conditionSymbol);
        divForecasts.appendChild(spanCondition);

        current.appendChild(divForecasts);
    }

    function createUpcoming(dataUpcoming) {
        const forecastDiv = createComponent('div', '', 'forecasts-info');

        dataUpcoming.forecast.forEach(el => {
            const upcomingSpan = createComponent('span', '', 'upcoming');
            const symbolSpan = createComponent('span', getWeatherIcon(el.condition), 'symbol');
            const forecastSpan = createComponent('span', `${el.low}°/${el.high}°`, 'forecast-data',);
            const wordSpan = createComponent('span', el.condition, 'forecast-data');

            upcomingSpan.appendChild(symbolSpan);
            upcomingSpan.appendChild(forecastSpan);
            upcomingSpan.appendChild(wordSpan);
            forecastDiv.appendChild(upcomingSpan);
        });

        upcoming.appendChild(forecastDiv);
    }

    function createComponent(type, content, className) {
        const element = document.createElement(type);
        element.innerHTML = content;
        element.className = className;
        return element;
    }

    function getWeatherIcon(condition) {
        const types = {
            'Sunny': '&#x2600',
            'Partly sunny': '&#x26C5',
            'Overcast': '&#x2601',
            'Rain': '&#x2614',
            'Degrees': '&#176'
        };
        return types[condition];
    }
}

attachEvents();