// function solve(input) {
//     const cars = new Map();

//     for (const item of input) {
//         let [brand, model, quantity] = item.split(' | ');
//         quantity = Number(quantity);

//         if (!cars.has(brand)) {
//             cars.set(brand, {});
//         }

//         if (!cars.get(brand).hasOwnProperty(model)) {
//             cars.get(brand)[model] = quantity;
//         } else {
//             cars.get(brand)[model] += quantity;
//         }
//     }

//     for (const car of cars) {
//         console.log(car[0]);

//         const models = car[1];

//         for (const model of Object.keys(models)) {
//             console.log(`###${model} -> ${models[model]}`);
//         }
//     }
// }

function solve(input) {
    const brands = new Map();

    for (const car of input) {
        const [brand, model, quantity] = car.split(' | ');

        if (!brands.has(brand)) {
            const models = new Map();

            models.set(model, Number(quantity));
            brands.set(brand, models);
        } else {
            let models = brands.get(brand);

            if (!models.has(model)) {
                models.set(model, Number(quantity));
            } else {
                models.set(model, models.get(model) + Number(quantity));
            }
        }
    }

    for (const [brand, models] of brands) {
        console.log(brand);

        for (const [model, quantity] of models) {
            console.log(`###${model} -> ${quantity}`);
        }
    }
}

solve(['Audi | Q7 | 1000',
    'Audi | Q6 | 100',
    'BMW | X5 | 1000',
    'BMW | X6 | 100',
    'Citroen | C4 | 123',
    'Volga | GAZ-24 | 1000000',
    'Lada | Niva | 1000000',
    'Lada | Jigula | 1000000',
    'Citroen | C4 | 22',
    'Citroen | C5 | 10']
);