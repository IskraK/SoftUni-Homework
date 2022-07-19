function solve(input) {
    const result = [];

    for (let i = 1; i < input.length; i++) {
        const data = input[i].split(/\s*\|\s*/g);
        const name = data[1];
        const latitude = Number(data[2]).toFixed(2);
        const longitude = Number(data[3]).toFixed(2);
        const town = {
            Town: name,
            Latitude: Number(latitude),
            Longitude: Number(longitude)
        };

        result.push(town);
    }

    return JSON.stringify(result);
}

console.log(solve(['| Town | Latitude | Longitude |',
    '| Sofia | 42.696552 | 23.32601 |',
    '| Beijing | 39.913818 | 116.363625 |']
));

console.log(solve(['| Town | Latitude | Longitude |',
    '| Veliko Turnovo | 43.0757 | 25.6172 |',
    '| Monatevideo | 34.50 | 56.11 |']
));

// function solve(input) {
//     let towns = [];

//     for (let i = 1; i < input.length; i++) {
//         const data = input[i].split(/\s*\|\s*/g);
//         const town = data[1];
//         const latitude = Number(data[2]).toFixed(2);
//         const longitude = Number(data[3]).toFixed(2);

//         const current = {
//             Town: town,
//             Latitude: Number(latitude),
//             Longitude: Number(longitude)
//         }

//         towns.push(current);
//     }

//     console.log(JSON.stringify(towns));
// }

// solve(['| Town | Latitude | Longitude |',
//     '| Sofia | 42.696552 | 23.32601 |',
//     '| Beijing | 39.913818 | 116.363625 |']);

// solve(['| Town | Latitude | Longitude |',
//     '| Veliko Turnovo | 43.0757 | 25.6172 |',
//     '| Monatevideo | 34.50 | 56.11 |']);