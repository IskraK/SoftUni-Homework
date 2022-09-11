let rentCar = require('./rentCar.js');
const { expect } = require('chai');

describe('RentCar tests', () => {
    describe('searchCar tests', () => {
        it('Throws error when input params are invalid', () => {
            expect(() => rentCar.searchCar(1, 'a')).to.throw('Invalid input!');
            expect(() => rentCar.searchCar('a', 'a')).to.throw('Invalid input!');
            expect(() => rentCar.searchCar(['a'], 1)).to.throw('Invalid input!');
            expect(() => rentCar.searchCar(['a'], ['a'])).to.throw('Invalid input!');
        });

        it('Throws error when model is not found in shop', () => {
            expect(() => rentCar.searchCar(['a'], 'b')).to.throw('There are no such models in the catalog!');
            expect(() => rentCar.searchCar(['a', 'b'], 'c')).to.throw('There are no such models in the catalog!');
            expect(() => rentCar.searchCar([], 'a')).to.throw('There are no such models in the catalog!');
        });

        it('Works correct', () => {
            expect(rentCar.searchCar(['a'], 'a')).to.equal('There is 1 car of model a in the catalog!');
            expect(rentCar.searchCar(['a', 'b', 'a'], 'a')).to.equal('There is 2 car of model a in the catalog!');
        });
    });

    describe('calculatePriceOfCar tests', () => {
        it('Throws error when input params are invalid', () => {
            expect(() => rentCar.calculatePriceOfCar(1, 1)).to.throw('Invalid input!');
            expect(() => rentCar.calculatePriceOfCar('a', 'b')).to.throw('Invalid input!');
            expect(() => rentCar.calculatePriceOfCar(1, 'a')).to.throw('Invalid input!');
        });

        it('Throws error when model does not exist', () => {
            expect(() => rentCar.calculatePriceOfCar('a', 1)).to.throw('No such model in the catalog!');
        });

        it('Returns correct message when model exists', () => {
            expect(rentCar.calculatePriceOfCar('Audi', 1)).to.equal('You choose Audi and it will cost $36!');
            expect(rentCar.calculatePriceOfCar('Audi', 2)).to.equal('You choose Audi and it will cost $72!');
        });
    });

    describe('checkBudget tests', () => {
        it('Throws error when input params are invalid', () => {
            expect(() => rentCar.checkBudget(1, 1, 'a')).to.throw('Invalid input!');
            expect(() => rentCar.checkBudget(1, 'a', 1)).to.throw('Invalid input!');
            expect(() => rentCar.checkBudget('a', 1, 1)).to.throw('Invalid input!');
            expect(() => rentCar.checkBudget('a', 'b', 1)).to.throw('Invalid input!');
            expect(() => rentCar.checkBudget('a', 'b', '1')).to.throw('Invalid input!');
        });

        it('Returns correct message when budget is enough', () => {
            expect(rentCar.checkBudget(1, 2, 2)).to.equal('You rent a car!');
            expect(rentCar.checkBudget(1, 2, 5)).to.equal('You rent a car!');
        });
        
        it('Returns correct message when budget is not enough', () => {
            expect(rentCar.checkBudget(2, 3, 1)).to.equal('You need a bigger budget!');
            expect(rentCar.checkBudget(1, 2, 0)).to.equal('You need a bigger budget!');
        });
    });
});