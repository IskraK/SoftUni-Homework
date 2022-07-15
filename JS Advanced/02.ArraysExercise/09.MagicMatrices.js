// 83/100
function solve(matrix) {
    let isMagical = true;
    const sums = [];
    for (let row = 0; row < matrix.length; row++) {
        sums.push(matrix[row].reduce((acc, curr) => acc + curr, 0));
    }

    for (col = 0; col < matrix.length; col++) {
        sums.push(matrix[col].reduce((acc, curr) => acc + curr, 0));
    }

    if (sums.some(x => x !== sums[0])) {
        isMagical = false;
    }

    return isMagical;
}


// 100/100
function solve3(matrix) {
    let isMagical = true;
    const sums = [];
    for (let row = 0; row < matrix.length; row++) {
        sums.push(matrix[row].reduce((acc, curr) => acc + curr, 0));

        let sumForCols = 0;

        for (let col = 0; col < matrix.length; col++) {
            sumForCols += matrix[col][row];
        }
        sums.push(sumForCols);
    }

    if (sums.some(x => x !== sums[0])) {
        isMagical = false;
    }

    return isMagical;
}

// 100/100
function solve2(matrix) {
    let isMagical = true;
    for (let row = 0; row < matrix.length - 1; row++) {
        let currentRow = matrix[row].reduce((a, b) => a + b, 0);
        let nextRow = matrix[row + 1].reduce((a, b) => a + b, 0);

        let currentCol = 0;
        let nextCol = 0;
        for (let col = 0; col < matrix.length; col++) {
            currentCol += matrix[row][col];
            nextCol += matrix[row + 1][col];
        }

        if (currentRow !== nextRow || currentCol !== nextCol) {
            isMagical = false
        }
    }

    return isMagical;
}

console.log(solve([
    [4, 5, 6],
    [6, 5, 4],
    [5, 5, 5]
]));
console.log(solve([
    [11, 32, 45],
    [21, 0, 1],
    [21, 1, 1]
]));
console.log(solve([
    [1, 0, 0],
    [0, 0, 1],
    [0, 1, 0]
]));

console.log(solve2([
    [4, 5, 6],
    [6, 5, 4],
    [5, 5, 5]
]));
console.log(solve2([
    [11, 32, 45],
    [21, 0, 1],
    [21, 1, 1]
]));
console.log(solve2([
    [1, 0, 0],
    [0, 0, 1],
    [0, 1, 0]
]));

console.log(solve3([
    [4, 5, 6],
    [6, 5, 4],
    [5, 5, 5]
]));
console.log(solve3([
    [11, 32, 45],
    [21, 0, 1],
    [21, 1, 1]
]));
console.log(solve3([
    [1, 0, 0],
    [0, 0, 1],
    [0, 1, 0]
]));
