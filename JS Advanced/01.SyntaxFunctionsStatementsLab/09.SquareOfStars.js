function solve(input) {
    if (input == null) {
        input = 5;
    }
    else {
        for (let i = 1; i <= input; i++) {
            let line = '';
            for (let j = 1; j <= input; j++) {
                line += '* ';
            }

            console.log(line);
        }
    }
}


solve(3);
solve();