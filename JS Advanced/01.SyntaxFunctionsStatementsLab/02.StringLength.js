function solve(input1, input2, input3) {
    let sumLength = input1.length + input2.length + input3.length;
    let averageLength = Math.floor(sumLength / 3);

    console.log(sumLength);
    console.log(averageLength);
}

solve('chocolate', 'ice cream', 'cake');
solve('pasta', '5', '22.3');