// function add(a) {
//     const inner = function (b) {
//         a += b;
//         return inner;
//     }

//     inner.valueOf = function () {
//         return a;
//     }

//     return inner;
// }

// console.log(Number(add(1)));
// console.log(Number(add(1)(6)(-3)));


//second decision
function add(num) {
    let sum = num;

    function calc(num2) {
        sum += num2;
        return calc;
    }

    calc.toString = function () {
        return sum;
    };

    return calc;
}

console.log(add(1).toString());
console.log(add(1)(6)(-3).toString());