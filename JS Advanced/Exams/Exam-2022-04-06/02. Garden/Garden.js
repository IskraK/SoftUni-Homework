class Garden {
    constructor(spaceAvailable) {
        this.spaceAvailable = spaceAvailable;
        this.plants = [];
        this.storage = [];
    }

    addPlant(plantName, spaceRequired) {
        if (this.spaceAvailable < spaceRequired) {
            throw new Error('Not enough space in the garden.');
        }

        let plant = { plantName, spaceRequired, ripe: false, quantity: 0 };
        this.plants.push(plant);
        this.spaceAvailable -= spaceRequired;

        return `The ${plantName} has been successfully planted in the garden.`;
    }

    ripenPlant(plantName, quantity) {
        let plant = this.plants.find(p => p.plantName == plantName);

        if (!plant) {
            throw new Error(`There is no ${plantName} in the garden.`);
        }

        if (plant.ripe) {
            throw new Error(`The ${plantName} is already ripe.`);
        }

        if (quantity <= 0) {
            throw new Error('The quantity cannot be zero or negative.');
        }

        plant.ripe = true;
        plant.quantity += quantity;

        if (quantity == 1) {
            return `${quantity} ${plantName} has successfully ripened.`;
        } else if (quantity > 1) {
            return `${quantity} ${plantName}s have successfully ripened.`;
        }
    }

    harvestPlant(plantName) {
        let plant = this.plants.find(p => p.plantName == plantName);

        if (!plant) {
            throw new Error(`There is no ${plantName} in the garden.`);
        }

        if (!plant.ripe) {
            throw new Error(`The ${plantName} cannot be harvested before it is ripe.`);
        }

        this.plants = this.plants.filter(p => p.plantName != plantName);
        this.storage.push(`${plantName} (${plant.quantity})`);
        this.spaceAvailable += plant.spaceRequired;

        return `The ${plantName} has been successfully harvested.`;
    }

    generateReport() {
        const result = [];

        result.push(`The garden has ${this.spaceAvailable} free space left.`);

        this.plants.sort((a, b) => a.plantName.localeCompare(b.plantName));
        let sortedPlants = [];
        this.plants.forEach(p => sortedPlants.push(p.plantName));

        result.push(`Plants in the garden: ${sortedPlants.join(', ')}`);

        if (this.storage.length === 0) {
            result.push('Plants in storage: The storage is empty.');
        } else {
            result.push(`Plants in storage: ${this.storage.join(', ')}`);
        }

        return result.join('\n');
    }
}

// const myGarden = new Garden(250)
// console.log(myGarden.addPlant('apple', 20));
// console.log(myGarden.addPlant('orange', 200));
// console.log(myGarden.addPlant('olive', 50));

// // Output 1
// // The apple has been successfully planted in the garden.
// // The orange has been successfully planted in the garden.
// // Uncaught Error Error: Not enough space in the garden.


// const myGarden = new Garden(250)
// console.log(myGarden.addPlant('apple', 20));
// console.log(myGarden.addPlant('orange', 100));
// console.log(myGarden.addPlant('cucumber', 30));
// console.log(myGarden.ripenPlant('apple', 10));
// console.log(myGarden.ripenPlant('orange', 1));
// console.log(myGarden.ripenPlant('orange', 4));

// // Output 2
// // The apple has been successfully planted in the garden.
// // The orange has been successfully planted in the garden.
// // The cucumber has been successfully planted in the garden.
// // 10 apples have successfully ripened.
// // 1 orange has successfully ripened.
// // Uncaught Error Error: The orange is already ripe.


// const myGarden = new Garden(250)
// console.log(myGarden.addPlant('apple', 20));
// console.log(myGarden.addPlant('orange', 100));
// console.log(myGarden.addPlant('cucumber', 30));
// console.log(myGarden.ripenPlant('apple', 10));
// console.log(myGarden.ripenPlant('orange', 1));
// console.log(myGarden.ripenPlant('olive', 30));

// // Output 3
// // The apple has been successfully planted in the garden.
// // The orange has been successfully planted in the garden.
// // The cucumber has been successfully planted in the garden.
// // 10 apples have successfully ripened.
// // 1 orange has successfully ripened.
// // Uncaught Error Error: There is no olive in the garden.


// const myGarden = new Garden(250)
// console.log(myGarden.addPlant('apple', 20));
// console.log(myGarden.addPlant('orange', 100));
// console.log(myGarden.addPlant('cucumber', 30));
// console.log(myGarden.ripenPlant('apple', 10));
// console.log(myGarden.ripenPlant('orange', 1));
// console.log(myGarden.ripenPlant('cucumber', -5));

// // Output 4
// // The apple has been successfully planted in the garden.
// // The orange has been successfully planted in the garden.
// // The cucumber has been successfully planted in the garden.
// // 10 apples have successfully ripened.
// // 1 orange has successfully ripened.
// // Uncaught Error Error: The quantity cannot be zero or negative.


// const myGarden = new Garden(250)
// console.log(myGarden.addPlant('apple', 20));
// console.log(myGarden.addPlant('orange', 200));
// console.log(myGarden.addPlant('raspberry', 10));
// console.log(myGarden.ripenPlant('apple', 10));
// console.log(myGarden.ripenPlant('orange', 1));
// console.log(myGarden.harvestPlant('apple'));
// console.log(myGarden.harvestPlant('olive'));

// // Output 5
// // The apple has been successfully planted in the garden.
// // The orange has been successfully planted in the garden.
// // The raspberry has been successfully planted in the garden.
// // 10 apples have successfully ripened.
// // 1 orange has successfully ripened.
// // The apple has been successfully harvested.
// // Uncaught Error Error: There is no olive in the garden.


// const myGarden = new Garden(250)
// console.log(myGarden.addPlant('apple', 20));
// console.log(myGarden.addPlant('orange', 200));
// console.log(myGarden.addPlant('raspberry', 10));
// console.log(myGarden.ripenPlant('apple', 10));
// console.log(myGarden.ripenPlant('orange', 1));
// console.log(myGarden.harvestPlant('apple'));
// console.log(myGarden.harvestPlant('raspberry'));

// // Output 6
// // The apple has been successfully planted in the garden.
// // The orange has been successfully planted in the garden.
// // The raspberry has been successfully planted in the garden.
// // 10 apples have successfully ripened.
// // 1 orange has successfully ripened.
// // The apple has been successfully harvested.
// // Uncaught Error Error: The raspberry cannot be harvested before it is ripe.


const myGarden = new Garden(250)
console.log(myGarden.addPlant('apple', 20));
console.log(myGarden.addPlant('orange', 200));
console.log(myGarden.addPlant('raspberry', 10));
console.log(myGarden.ripenPlant('apple', 10));
console.log(myGarden.ripenPlant('orange', 1));
console.log(myGarden.harvestPlant('orange'));
console.log(myGarden.generateReport());

// Output 6
// The apple has been successfully planted in the garden.
// The orange has been successfully planted in the garden.
// The raspberry has been successfully planted in the garden.
// 10 apples have successfully ripened.
// 1 orange has successfully ripened.
// The orange has been successfully harvested.
// The garden has 220 free space left.
// Plants in the garden: apple, raspberry
// Plants in storage: orange (1)
