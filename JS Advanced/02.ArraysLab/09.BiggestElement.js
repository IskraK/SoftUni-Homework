function solve(matrix) {
    let maxElement = matrix[0][0];

    for (let row = 0; row < matrix.length; row++) {
        for (let col = 0; col < matrix[row].length; col++) {
            if (matrix[row][col] > maxElement) {
                maxElement = matrix[row][col];
            }
        }
    }

    return maxElement;
}

console.log(solve([[20, 50, 10],
                   [8, 33, 145]]
));

console.log(solve([[3, 5, 7, 12],
                   [-1, 4, 33, 2],
                   [8, 3, 0, 4]]
   ))