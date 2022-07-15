function solve(commands) {
    const result = [];
    let number = 1;

    for (let i = 0; i < commands.length; i++) {
        switch (commands[i]) {
            case 'add':
                result.push(number);
                break;
            case 'remove':
                result.pop();
                break;
        }

        number++;
    }

    return result.length != 0 ? result.join('\n') : 'Empty';
}

console.log(solve(['add','add','add','add']));

console.log(solve(['add','add','remove','add','add']));

console.log(solve(['remove','remove','remove']));