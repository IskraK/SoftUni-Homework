// //25/100 in Judge but gives correct output
// function solve() {
//     const ingredients = {
//         protein: 0,
//         carbohydrate: 0,
//         fat: 0,
//         flavour: 0
//     };

//     // •	apple - made with 1 carbohydrate and 2 flavour
//     // •	lemonade - made with 10 carbohydrate and 20 flavour
//     // •	burger - made with 5 carbohydrate, 7 fat and 3 flavour
//     // •	eggs - made with 5 protein, 1 fat and 1 flavour
//     // •	turkey - made with 10 protein, 10 carbohydrate, 10 fat and 10 flavour
    
//     const recipes = {
//         apple: recipeIngredients(0, 1, 0, 2),
//         lemonade: recipeIngredients(0, 10, 0, 20),
//         burger: recipeIngredients(0, 5, 7, 3),
//         eggs: recipeIngredients(5, 0, 1, 1),
//         turkey: recipeIngredients(10, 10, 10, 10)
//     };

//     function recipeIngredients(protein, carbohydrate, fat, flavour) {
//         return { protein, carbohydrate, fat, flavour };
//     }

//     const commands = {
//         restock,
//         prepare,
//         report
//     };

//     return manager;

//     function manager(input) {
//         const [command, param, qty] = input.split(' ');
//         return commands[command](param, qty);
//     }

//     function restock(ingredient, qty) {
//         ingredients[ingredient] += Number(qty);
//         return 'Success';
//     }

//     function prepare(recipeName, qty) {
//         qty = Number(qty);
//         const recipe = Object.entries(recipes[recipeName]);

//         recipe.forEach(ingredient => ingredient[1] *= qty);

//         for (const [ingredient, requiredQty] of recipe) {
//             if (ingredients[ingredient] < requiredQty) {
//                 return `Error: not enough ${ingredient} in stock`;
//             }
//         }

//         recipe.forEach(([ingredient, requiredQty]) => ingredients[ingredient] -= requiredQty);
//         return 'Success';
//     }

//     function report() {
//         return `protein=${ingredients.protein} carbohydrate=${ingredients.carbohydrate} fat=${ingredients.fat} flavour=${ingredients.flavour} `;
//     }
// }

// let manager = solve();

// // console.log(manager('restock flavour 50'));
// // console.log(manager('prepare lemonade 4'));
// // console.log(manager('restock carbohydrate 10'));
// // console.log(manager('restock flavour 10'));
// // console.log(manager('prepare apple 1'));
// // console.log(manager('restock fat 10'));
// // console.log(manager('prepare burger 1'));
// // console.log(manager('report'));


// // console.log(manager('prepare turkey 1'));
// // console.log(manager('restock protein 10'));
// // console.log(manager('prepare turkey 1'));
// // console.log(manager('restock carbohydrate 10'));
// // console.log(manager('prepare turkey 1'));
// // console.log(manager('restock fat 10'));
// // console.log(manager('prepare turkey 1'));
// // console.log(manager('restock flavour 10'));
// // console.log(manager('prepare turkey 1'));
// // console.log(manager('report'));


// console.log(manager('restock carbohydrate 10'));
// console.log(manager('restock flavour 10'));
// console.log(manager('prepare apple 1'));
// console.log(manager('restock fat 10'));
// console.log(manager('prepare burger 1'));
// console.log(manager('report'));


//second decision 100/100
function breakfastRobot() {
    // apple - made with 1 carbohydrate and 2 flavour
    // lemonade - made with 10 carbohydrate and 20 flavour
    // burger - made with 5 carbohydrate, 7 fat and 3 flavour
    // eggs - made with 5 protein, 1 fat and 1 flavour
    // turkey - made with 10 protein, 10 carbohydrate, 10 fat and 10 flavour
    const recipes = {
        apple: {
            carbohydrate: 1,
            flavour: 2
        },
        lemonade: {
            carbohydrate: 10,
            flavour: 20
        },
        burger: {
            carbohydrate: 5,
            fat: 7,
            flavour: 3
        },
        eggs: {
            protein: 5,
            fat: 1,
            flavour: 1
        },
        turkey: {
            protein: 10,
            carbohydrate: 10,
            fat: 10,
            flavour: 10
        }
    };

    const stock = {
        protein: 0,
        carbohydrate: 0,
        fat: 0,
        flavour: 0
    };

    const commands = {
        restock,
        prepare,
        report
    };

    return manager;

    function manager(line) {
        const [command, param, qty] = line.split(' ');
        return commands[command](param, qty);
    };

    function restock(type, qty) {
        stock[type] += Number(qty);
        return 'Success';
    };

    function prepare(recipeAsString, qty) {
        qty = Number(qty);

        // find recipe
        const recipe = Object.entries(recipes[recipeAsString]);

        // calculate total ingredient quantity
        recipe.forEach(ingredient => ingredient[1] *= qty);

        // compare one by one with stock
        for (let [ingredient, required] of recipe) {
            if (stock[ingredient] < required) {
                // if one is insufficient -> return error
                return `Error: not enough ${ingredient} in stock`;
            }
        }

        // otherwise, subtract quantities from stock and return success
        recipe.forEach(([ingredient, required]) => stock[ingredient] -= required);
        return 'Success';

    };

    function report() {
        return `protein=${stock.protein} carbohydrate=${stock.carbohydrate} fat=${stock.fat} flavour=${stock.flavour}`;
    };
}

let manager = breakfastRobot();

console.log(manager("restock flavour 50")); // Success
console.log(manager("prepare lemonade 4")); // Error: not enough carbohydrate in stock
console.log(manager("restock carbohydrate 10")); // Success
console.log(manager("restock flavour 10")); // Success
console.log(manager("prepare apple 1")); // Success
console.log(manager("restock fat 10")); // Success
console.log(manager("prepare burger 1")); // Success
console.log(manager("report")); // protein=0 carbohydrate=4 fat=3 flavour=55
