function solve(...args) {
    const input = Array.from(args);
    const types = {};

    for (const arg of args) {
        const type = typeof arg;
        console.log(`${type}: ${arg}`);

        if (types[type] === undefined) {
            types[type] = 0;
        }

        types[type]++;
    }

    const result = Object.entries(types).sort((a, b) => b[1] - a[1]);

    for (const [type, count] of result) {
        console.log(`${type} = ${count}`)
    }
}

solve('cat', 42, function () { console.log('Hello world!'); });
solve(1, 2, 3);
solve(1, 2, 'cat');