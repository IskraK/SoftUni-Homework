function solve(fruit, weight, pricePerKg){
    let weightKg = weight / 1000;
    let money = weightKg * pricePerKg;

    return `I need $${money.toFixed(2)} to buy ${weightKg.toFixed(2)} kilograms ${fruit}.`;
}

console.log(solve('orange', 2500, 1.80));
console.log(solve('apple', 1563, 2.3));