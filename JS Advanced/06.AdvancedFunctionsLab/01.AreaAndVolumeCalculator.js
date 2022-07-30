function solve(area, vol, inputJsonString) {
    const figures = JSON.parse(inputJsonString);
    const result = [];

    for (const figure of figures) {
        const objArea = area.call(figure);
        const objVol = vol.call(figure);

        const output = {
            area: objArea,
            volume: objVol
        };

        result.push(output);
    }

    return result;
}


// //shorter decision
// function solve(area, vol, inputJsonString) {
//     const figures = JSON.parse(inputJsonString);

//     const result = figures.map(figure => ({
//         area: area.call(figure),
//         volume: vol.call(figure)
//     }));

//     return result;
// }


// //1 line decision
// const solve = (area, vol, inputJsonString) => JSON.parse(inputJsonString).map(figure => ({
//     area: area.call(figure),
//     volume: vol.call(figure)
// }));


console.log(solve(area, vol, `[
    {"x":"1","y":"2","z":"10"},
    {"x":"7","y":"7","z":"10"},
    {"x":"5","y":"2","z":"10"}
    ]`
));

console.log(solve(area, vol, `[
    {"x":"10","y":"-22","z":"10"},
    {"x":"47","y":"7","z":"-5"},
    {"x":"55","y":"8","z":"0"},
    {"x":"100","y":"100","z":"100"},
    {"x":"55","y":"80","z":"250"}
    ]`
));

function area() {
    return Math.abs(this.x * this.y);
};

function vol() {
    return Math.abs(this.x * this.y * this.z);
};
