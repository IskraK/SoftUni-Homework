// function createRecord(name, population, treasury) {
//     const city = {};
//     city.name = name;
//     city.population = population;
//     city.treasury = treasury;

//     return city;
// }

function createRecord(name, population, treasury) {
    const city = {
        name,
        population,
        treasury
    };

    return city;
}

console.log(createRecord('Tortuga', 7000, 15000));
console.log(createRecord('Santo Domingo', 12000, 23500));
