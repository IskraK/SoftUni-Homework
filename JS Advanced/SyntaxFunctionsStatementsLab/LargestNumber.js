function solve(num1, num2, num3)
{
    let maxNumber;

    if (num1 > num2 && num1 > num3){
        maxNumber = num1;
    }
    else if(num2 > num1 && num2 > num3){
        maxNumber = num2;
    }
    else{
        maxNumber = num3;
    }

    console.log(`The largest number is ${maxNumber}.`);
}

solve(5, -3, 16);
solve(-3, -5, -22.5);