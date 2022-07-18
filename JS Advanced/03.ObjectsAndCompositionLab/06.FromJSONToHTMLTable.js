function fromJSONToHTMLTable(json) {
    let arr = JSON.parse(json);
    let result = ["<table>"];
    result.push(makeKeyRow(arr[0]));
    arr.forEach((obj) => result.push(makeValueRow(obj)));
    result.push("</table>")

    function makeKeyRow(arr) {
        let keys = [];

        Object.keys(arr).forEach(key => {
            keys.push(`<th>${escapeHtml(key)}</th>`);
        });

        return ("   <tr>" + keys.join('') + "</tr>");
    }

    function makeValueRow(obj) {
        const rows = [];

        Object.values(obj).forEach(value => {
            rows.push(`<td>${escapeHtml(value)}</td>`);
        });

        return ("   <tr>" + rows.join('') + "</tr>");
    }

    function escapeHtml(value) {
        return value
            .toString()
            .replace(/&/g, '&amp;')
            .replace(/</g, '&lt;')
            .replace(/>/g, '&gt;')
            .replace(/"/g, '&quot;')
            .replace(/'/g, '&#39;');
    }

    return result.join('\n');
}

//console.log(fromJSONToHTMLTable(['[{"Name":"Stamat","Price":5.5},{"Name":"Rumen","Price":6}]']));

window.onload = function(){
    let container = document.getElementById('wrapper');
    container.innerHTML = fromJSONToHTMLTable(['[{"Name":"Stamat","Price":5.5},{"Name":"Rumen","Price":6}]']);
};