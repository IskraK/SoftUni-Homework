function solve(objCar) {
    const engines = {
        small: { power: 90, volume: 1800 },
        normal: { power: 120, volume: 2400 },
        monster: { power: 200, volume: 3500 }
    };

    let engine;

    if (objCar.power <= 90) {
        engine = engines.small;
    } else if (objCar.power <= 120) {
        engine = engines.normal;
    } else {
        engine = engines.monster;
    }

    let carriage = { type: objCar.carriage, color: objCar.color };

    let size = objCar.wheelsize;
    if (size % 2 == 0) {
        size--;
    }

    //let wheels = [size, size, size, size];
    let wheels = Array(4).fill(size, 0, 4);

    const car = {
        model: objCar.model,
        engine,
        carriage,
        wheels
    };

    return car;
}

console.log(solve({
    model: 'VW Golf II',
    power: 90,
    color: 'blue',
    carriage: 'hatchback',
    wheelsize: 14
}));

console.log(solve({
    model: 'Opel Vectra',
    power: 110,
    color: 'grey',
    carriage: 'coupe',
    wheelsize: 17
}));