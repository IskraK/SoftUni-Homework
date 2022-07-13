function solve(input) {
    let words = input.toUpperCase()
        .split(/\W+/)
        .filter(w => w !== "");

    return words.join(', ');
}


function solve2(input) {
    return input.match(/\w+/g).join(", ").toLocaleUpperCase()
}


console.log(solve('Hi, how are you?'));
console.log(solve('hello'));

console.log(solve2('Hi, how are you?'));
console.log(solve2('hello'));