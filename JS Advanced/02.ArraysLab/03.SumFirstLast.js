function solve(arr) {
    let first = Number(arr[0]);
    let last = Number(arr[arr.length - 1]);

    return first + last;
}

function secondSolve(arr) {
    return Number(arr.shift()) + Number(arr.pop());
}

console.log(solve(['20', '30', '40']));
console.log(solve(['5', '10']));

console.log(secondSolve(['20', '30', '40']));
console.log(secondSolve(['5', '10']));

