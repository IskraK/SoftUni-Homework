async function getInfo() {
    const stopIdField = document.getElementById('stopId');
    const stopName = document.getElementById('stopName');
    const ulElement = document.getElementById('buses');
    ulElement.innerHTML = '';
    
    const url = `http://localhost:3030/jsonstore/bus/businfo/${stopIdField.value} `;
    
    
    try {
        const response = await fetch(url);
        const data = await response.json();
        
        stopName.textContent = data.name;
        
        for (const busId in data.buses) {
            const li = document.createElement('li');
            li.textContent = `Bus ${busId} arrives in ${data.buses[busId]} minutes`;
            ulElement.appendChild(li);
        }
        
        stopIdField.value = '';
    } catch (error) {
        stopName.textContent = 'Error';
    }
}