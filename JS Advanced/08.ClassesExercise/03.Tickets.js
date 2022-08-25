function solve(arr, sorting) {
    class Ticket {
        constructor(destination, price, status) {
            this.destination = destination;
            this.price = price;
            this.status = status;
        }
    }

    const tickets = [];

    for (const line of arr) {
        let [destination, price, status] = line.split('|');
        price = Number(price);
        tickets.push(new Ticket(destination, price, status));
    }

    tickets.sort((a, b) => {
        if (sorting == 'destination') {
            return a.destination.localeCompare(b.destination);
        } else if (sorting == 'status') {
            return a.status.localeCompare(b.status);
        } else if (sorting == 'price') {
            return a.price - b.price;
        }
    });

    return tickets;
}

console.log(solve(['Philadelphia|94.20|available',
    'New York City|95.99|available',
    'New York City|95.99|sold',
    'Boston|126.20|departed'],
    'destination'
));

console.log(solve(['Philadelphia|94.20|available',
    'New York City|95.99|available',
    'New York City|95.99|sold',
    'Boston|126.20|departed'],
    'status'
));