// class ChristmasDinner {
//     constructor(budget) {
//         this.budget = budget;
//         this.dishes = [];
//         this.products = [];
//         this.guests = {};
//     }

//     get budget() {
//         return this._budget;
//     }

//     set budget(value) {
//         if (value < 0) {
//             throw new Error('The budget cannot be a negative number');
//         }

//         this._budget = value;
//     }

//     shopping(product) {
//         let [type, price] = [...product];

//         if (this.budget < price) {
//             throw new Error('Not enough money to buy this product');
//         }

//         this.budget -= price;
//         this.products.push(type);
//         return `You have successfully bought ${type}!`;
//     }

//     recipes(recipe) {
//         for (const product of recipe.productsList) {
//             if (this.products.includes(product) == false) {
//                 throw new Error('We do not have this product');
//             }
//         }

//         this.dishes.push(recipe);
//         return `${recipe.recipeName} has been successfully cooked!`;
//     }

//     inviteGuests(name, dish) {
//         if (this.dishes.find(d => d.recipeName == dish) == undefined) {
//             throw new Error('We do not have this dish');
//         }

//         if (this.guests[name]) {
//             throw new Error('This guest has already been invited');
//         }

//         this.guests[name] = dish;
//         return `You have successfully invited ${name}!`;
//     }

//     showAttendance() {
//         let result = [];

//         for (const guest in this.guests) {
//             let dish = this.dishes.find(d => d.recipeName == this.guests[guest]);
//             result.push(`${guest} will eat ${this.guests[guest]}, which consists of ${dish.productsList.join(', ')}`);
//         }

//         return result.join('/n');
//     }
// }


//second decision
class ChristmasDinner {
    constructor(budget) {
        this.budget = budget;
        this.dishes = [];
        this.products = [];
        this.guests = {};
    }

    get budget() {
        return this._budget;
    }

    set budget(value) {
        if (value < 0) {
            throw new Error('The budget cannot be a negative number');
        }

        this._budget = value;
    }

    shopping([type, price]) {
        if (price > this.budget) {
            throw new Error('Not enough money to buy this product');
        }

        this.budget -= price;
        this.products.push(type);
        return `You have successfully bought ${type}!`;
    }

    recipes({ recipeName, productsList }) {
        if (productsList.some(p => this.products.includes(p) == false)) {
            throw new Error('We do not have this product');
        }

        this.dishes.push({ recipeName, productsList });
        return `${recipeName} has been successfully cooked!`;
    }

    inviteGuests(name, dish) {
        if (this.dishes.some(d => d.recipeName == dish) == false) {
            throw new Error('We do not have this dish');
        } else if (this.guests.hasOwnProperty(name)) {
            throw new Error('This guest has already been invited');
        }

        this.guests[name] = dish;
        return `You have successfully invited ${name}!`;
    }

    showAttendance() {
        // let result = [];

        // Object.entries(this.guests).forEach(([guestName, dish]) => {
        //     result.push(`${guestName} will eat ${dish}, which consists of ${this.dishes.find(d => d.recipeName == dish).productsList.join(', ')}`);
        // });

        // return result.join('/n');

        return Object
            .entries(this.guests)
            .reduce((acc, [guestName, dish]) =>
                acc.concat([`${guestName} will eat ${dish}, which consists of ${this.dishes.find(d => d.recipeName == dish).productsList.join(', ')}`])
                , [])
            .join('/n');
    }
}


let dinner = new ChristmasDinner(300);

dinner.shopping(['Salt', 1]);
dinner.shopping(['Beans', 3]);
dinner.shopping(['Cabbage', 4]);
dinner.shopping(['Rice', 2]);
dinner.shopping(['Savory', 1]);
dinner.shopping(['Peppers', 1]);
dinner.shopping(['Fruits', 40]);
dinner.shopping(['Honey', 10]);

dinner.recipes({
    recipeName: 'Oshav',
    productsList: ['Fruits', 'Honey']
});
dinner.recipes({
    recipeName: 'Folded cabbage leaves filled with rice',
    productsList: ['Cabbage', 'Rice', 'Salt', 'Savory']
});
dinner.recipes({
    recipeName: 'Peppers filled with beans',
    productsList: ['Beans', 'Peppers', 'Salt']
});

dinner.inviteGuests('Ivan', 'Oshav');
dinner.inviteGuests('Petar', 'Folded cabbage leaves filled with rice');
dinner.inviteGuests('Georgi', 'Peppers filled with beans');

console.log(dinner.showAttendance());
