function solve(arr) {
let sum = 0;
let reciprocalSum = 0;
let concat = '';

for (let i = 0; i < arr.length; i++){
    sum += arr[i];
    reciprocalSum += 1/arr[i];
    concat += arr[i];
}

return `${sum}\n${reciprocalSum}\n${concat}`;
}

console.log(solve([1, 2, 3]));
console.log(solve([2, 4, 8, 16]));