function solve(input) {
    const products = {};

    for (const item of input) {
        let [town, product, price] = item.split(' | ');
        price = Number(price);

        if (!(products.hasOwnProperty(product)) || products[product].price > price) {
            products[product] = { price: price, town: town };
        }
    }

    for (const [product, items] of Object.entries(products)) {
        console.log(`${product} -> ${items.price} (${items.town})`);
    }
}

solve(['Sample Town | Sample Product | 1000',
    'Sample Town | Orange | 2',
    'Sample Town | Peach | 1',
    'Sofia | Orange | 3',
    'Sofia | Peach | 2',
    'New York | Sample Product | 1000.1',
    'New York | Burger | 10']
);