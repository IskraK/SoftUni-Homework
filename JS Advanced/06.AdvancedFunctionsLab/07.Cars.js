function solve(input) {
    const result = {};

    const commands = {
        create: (name, inherits, parentName) => {
            result[name] = inherits
                ? result[name] = Object.create(result[parentName]) : result[name] = {};
        },
        set: (name, key, value) => result[name][key] = value,
        print: (name) => {
            const objects = [];

            for (const object in result[name]) {
                objects.push(`${object}:${result[name][object]}`);
            }

            console.log(objects.join());
        }
    };

    input.forEach(e => {
        const [command, name, key, value] = e.split(' ');
        commands[command](name, key, value);
    });
}

solve(['create c1',
    'create c2 inherit c1',
    'set c1 color red',
    'set c2 model new',
    'print c1',
    'print c2']
);