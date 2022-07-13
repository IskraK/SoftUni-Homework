function solve(num, opr1, opr2, opr3, opr4, opr5) {
    let number = Number(num);
    let arr = [opr1, opr2, opr3, opr4, opr5];

    for (let i = 0; i < arr.length; i++) {
        switch (arr[i]) {
            case 'chop':
                number /= 2;
                break;
            case 'dice':
                number = Math.sqrt(number);
                break;
            case 'spice':
                number +=1;
                break;
            case 'bake':
                number *= 3;
                break;
            case 'fillet':
                number *= 0.8;
                break;
        }

        console.log(number);
    }
}

solve('32', 'chop', 'chop', 'chop', 'chop', 'chop');
solve('9', 'dice', 'spice', 'chop', 'bake', 'fillet');