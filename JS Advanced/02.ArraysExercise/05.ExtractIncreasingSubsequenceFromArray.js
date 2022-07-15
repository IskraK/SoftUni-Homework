function solve(arr) {
    const result = [];
    let biggestElement = arr[0];

    for (let i = 0; i < arr.length; i++) {
        if (arr[i] >= biggestElement) {
            result.push(arr[i]);
            biggestElement = arr[i];
        }
    }

    return result;
}

console.log(solve([1, 3, 8, 4, 10, 12, 3, 2, 24]));
console.log(solve([1, 2, 3, 4]));
console.log(solve([20, 3, 2, 15, 6, 1]));
