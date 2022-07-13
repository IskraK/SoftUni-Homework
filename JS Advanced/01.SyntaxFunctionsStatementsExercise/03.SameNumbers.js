function solve(inputNumber) {
    let isSame = true;
    let sumOfDigits = 0;
    let inputAsString = inputNumber.toString();

    for (let i = 0; i < inputAsString.length; i++) {
        sumOfDigits += Number(inputAsString[i]);
        if (inputAsString[i] !== inputAsString[i + 1] && (i + 1) < inputAsString.length) {
            isSame = false;
        }
    }

    return `${isSame}\n${sumOfDigits}`;
}

console.log(solve(2222222));
console.log(solve(1234));