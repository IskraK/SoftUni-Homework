function solve(arr) {
    const result = [];

    for (let i = 1; i < arr.length; i += 2) {
        result.push(arr[i] * 2);
    }

    return result
        .reverse()
        .join(' ');
}

function solve2(arr) {
    return arr.filter((a, i) => i % 2 !== 0)
        .map(x => x * 2)
        .reverse()
        .join(' ');
}


console.log(solve([10, 15, 20, 25]));
console.log(solve([3, 0, 10, 4, 7, 3]));

console.log(solve2([10, 15, 20, 25]));
console.log(solve2([3, 0, 10, 4, 7, 3]));
