function solve(year, month, day) {
    let inputDate = `${year}-${month}-${day}`;
    let date = new Date(inputDate);
    date.setDate(date.getDate() - 1);

    return `${date.getFullYear()}-${date.getMonth() + 1}-${date.getDate()}`;
}

console.log(solve(2016, 9, 30));
console.log(solve(2016, 10, 1));
