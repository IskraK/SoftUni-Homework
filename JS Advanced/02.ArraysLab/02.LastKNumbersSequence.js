function solve(n, k) {
    const arr = [1];
    const arrLength = n;

    for (let i = 1; i < arrLength; i++) {
        let start = i - k >= 0 ? i - k : 0;
        let previous = arr.slice(start, i);
        let current = previous.reduce((a, b) => a + b, 0);
        arr.push(current);
    }

    return arr;
}

console.log(solve(6, 3));
console.log(solve(8, 2));
