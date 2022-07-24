function generateReport() {
    const checkboxes = Array.from(document.querySelectorAll('thead tr th input'));
    const rows = Array.from(document.querySelectorAll('tbody tr'));
    const output = document.getElementById('output');

    const result = [];

    for (const row of rows) {
        const current = {};
        const cells = Array.from(row.querySelectorAll('td'));

        cells.forEach((c, i) => {
            if (checkboxes[i].checked) {
                current[checkboxes[i].name] = c.textContent;
            }
        });
        
        result.push(current);
    }
    
    output.value = JSON.stringify(result);
}