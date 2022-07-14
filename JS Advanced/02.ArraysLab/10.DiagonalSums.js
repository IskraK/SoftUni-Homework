function solve(matrix) {
    let mainSum = 0;
    let secondarySum = 0;
    const matrixLength = matrix.length;

    for (let i = 0; i < matrixLength; i++) {
        mainSum += matrix[i][i];
        secondarySum += matrix[i][matrixLength - 1 - i];
    }

    return `${mainSum} ${secondarySum}`;
}

console.log(solve([[20, 40],
                   [10, 60]]
));

console.log(solve([[3, 5, 17],
                   [-1, 7, 14],
                   [1, -8, 89]]
));