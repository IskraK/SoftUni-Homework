class SummerCamp {
    constructor(organizer, location) {
        this.organizer = organizer;
        this.location = location;
        this.priceForTheCamp = {
            child: 150,
            student: 300,
            collegian: 500,
        };
        this.listOfParticipants = [];
    }

    registerParticipant(name, condition, money) {
        if (!this.priceForTheCamp[condition]) {
            throw new Error('Unsuccessful registration at the camp.');
        }

        if (this.listOfParticipants.some(p => p.name == name)) {
            return `The ${name} is already registered at the camp.`;
        }

        if (money < this.priceForTheCamp[condition]) {
            return 'The money is not enough to pay the stay at the camp.';
        }

        let participant = {
            name,
            condition,
            power: 100,
            wins: 0
        };

        this.listOfParticipants.push(participant);
        return `The ${name} was successfully registered.`;
    }

    unregisterParticipant(name) {
        if (this.listOfParticipants.some(p => p.name == name) == false) {
            throw new Error(`The ${name} is not registered in the camp.`);
        }

        this.listOfParticipants = this.listOfParticipants.filter(p => p.name != name);
        return `The ${name} removed successfully.`;
    }

    timeToPlay(typeOfGame, participant1, participant2) {
        let player1 = this.listOfParticipants.find(p => p.name == participant1);
        let player2;

        if (!player1) {
            throw new Error('Invalid entered name/s.');
        }

        if (typeOfGame == 'Battleship') {
            player1.power += 20;

            return `The ${player1.name} successfully completed the game ${typeOfGame}.`;
        } else if (typeOfGame == 'WaterBalloonFights') {
            let winnerName;

            player2 = this.listOfParticipants.find(p => p.name == participant2);

            if (!player2) {
                throw new Error('Invalid entered name/s.');
            }

            if (player1.condition != player2.condition) {
                throw new Error('Choose players with equal condition.');
            }

            if (player1.power > player2.power) {
                player1.wins++;
                winnerName = player1.name;
            } else if (player1.power < player2.power) {
                player2.wins++;
                winnerName = player2.name;
            } else {
                return 'There is no winner.';
            }

            return `The ${winnerName} is winner in the game ${typeOfGame}.`;
        }
    }

    toString() {
        let result = [];
        result.push(`${this.organizer} will take ${this.listOfParticipants.length} participants on camping to ${this.location}`);

        this.listOfParticipants
            .sort((a, b) => b.wins - a.wins)
            .forEach(p => result.push(`${p.name} - ${p.condition} - ${p.power} - ${p.wins}`));

        return result.join('\n');
    }
}

// const summerCamp = new SummerCamp("Jane Austen", "Pancharevo Sofia 1137, Bulgaria");
// console.log(summerCamp.registerParticipant("Petar Petarson", "student", 200));
// console.log(summerCamp.registerParticipant("Petar Petarson", "student", 300));
// console.log(summerCamp.registerParticipant("Petar Petarson", "student", 300));
// console.log(summerCamp.registerParticipant("Leila Wolfe", "childd", 200));

// // The money is not enough to pay the stay at the camp.
// // The Petar Petarson was successfully registered.
// // The Petar Petarson is already registered at the camp.
// // Uncaught Error: Unsuccessful registration at the camp.


// const summerCamp = new SummerCamp("Jane Austen", "Pancharevo Sofia 1137, Bulgaria");
// console.log(summerCamp.registerParticipant("Petar Petarson", "student", 300));
// console.log(summerCamp.unregisterParticipant("Petar"));
// console.log(summerCamp.unregisterParticipant("Petar Petarson"));

// // The Petar Petarson was successfully registered.
// // Uncaught Error: The Petar is not registered in the camp.
// // The Petar Petarson removed successfully.


// const summerCamp = new SummerCamp("Jane Austen", "Pancharevo Sofia 1137, Bulgaria");
// console.log(summerCamp.registerParticipant("Petar Petarson", "student", 300));
// console.log(summerCamp.timeToPlay("Battleship", "Petar Petarson"));
// console.log(summerCamp.registerParticipant("Sara Dickinson", "child", 200));
// console.log(summerCamp.timeToPlay("WaterBalloonFights", "Petar Petarson", "Sara Dickinson"));
// console.log(summerCamp.registerParticipant("Dimitur Kostov", "student", 300));
// console.log(summerCamp.timeToPlay("WaterBalloonFights", "Petar Petarson", "Dimitur Kostov"));

// // The Petar Petarson was successfully registered.
// // The Petar Petarson successfully completed the game Battleship.
// // The Sara Dickinson was successfully registered.
// // Uncaught Error: Choose players with equal condition.
// // The Dimitur Kostov was successfully registered.
// // The Petar Petarson is winner in the game WaterBalloonFights.


const summerCamp = new SummerCamp("Jane Austen", "Pancharevo Sofia 1137, Bulgaria");
console.log(summerCamp.registerParticipant("Petar Petarson", "student", 300));
console.log(summerCamp.timeToPlay("Battleship", "Petar Petarson"));
console.log(summerCamp.registerParticipant("Sara Dickinson", "child", 200));
console.log(summerCamp.timeToPlay("WaterBalloonFights", "Petar Petarson", "Sara Dickinson"));
console.log(summerCamp.registerParticipant("Dimitur Kostov", "student", 300));
console.log(summerCamp.timeToPlay("WaterBalloonFights", "Petar Petarson", "Dimitur Kostov"));

console.log(summerCamp.toString());

// The Petar Petarson was successfully registered.
// The Petar Petarson successfully completed the game Battleship.
// The Sara Dickinson was successfully registered.
// Uncaught Error: Choose players with equal condition.
// The Dimitur Kostov was successfully registered.
// The Petar Petarson is winner in the game WaterBalloonFights.
// Jane Austen will take 3 participants on camping to Pancharevo Sofia 1137, Bulgaria
// Petar Petarson - student - 120 - 1
// Sara Dickinson - child - 100 - 0
// Dimitur Kostov - student - 100 - 0
