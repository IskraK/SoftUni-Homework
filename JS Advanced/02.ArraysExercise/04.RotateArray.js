function solve(arr, rotations) {
    const arrLength = arr.length;
    for (let i = 0; i < rotations; i++) {
        arr.unshift(arr.pop());
    }

    return arr.join(' ');
}

console.log(solve(['1', '2', '3', '4'], 2));

console.log(solve(['Banana', 'Orange', 'Coconut', 'Apple'], 15));