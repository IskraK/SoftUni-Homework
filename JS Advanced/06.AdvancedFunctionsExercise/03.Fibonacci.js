function getFibonator() {
    let prev = 0;
    let next = 0;

    return () => {
        const result = prev + next || 1;
        prev = next;
        next = result;

        return result;
    }
}

let fib = getFibonator();
console.log(fib()); // 1
console.log(fib()); // 1
console.log(fib()); // 2
console.log(fib()); // 3
console.log(fib()); // 5
console.log(fib()); // 8
console.log(fib()); // 13
