function solve(arr, typeSorting) {
    switch (typeSorting) {
        case 'asc':
            return arr.sort((a, b) => a - b);
        case 'desc':
            return arr.sort((a, b) => b - a);
        default:
            break;
    }
}

console.log(solve([14, 7, 17, 6, 8], 'asc'));
console.log(solve([14, 7, 17, 6, 8], 'desc'));

// //second decision
// function sortArray(arr, type) {
//     const methods = {
//         asc: (a, b) => a - b,
//         desc: (a, b) => b - a
//     }

//     arr.sort(methods[type]);

//     return arr;
// }

// console.log(sortArray([14, 7, 17, 6, 8], 'asc'));
// console.log(sortArray([14, 7, 17, 6, 8], 'desc'));
