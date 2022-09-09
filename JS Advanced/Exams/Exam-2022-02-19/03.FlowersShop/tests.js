let flowerShop = require('./flowerShop.js');
const { expect } = require('chai');

describe('Flower Shop tests', () => {
    describe('calcPriceOfFlower tests', () => {
        it('Throws error when invalid input', () => {
            expect(() => flowerShop.calcPriceOfFlowers(1, 1, 1)).to.throw('Invalid input!');
            expect(() => flowerShop.calcPriceOfFlowers('a', 'a', 1)).to.throw('Invalid input!');
            expect(() => flowerShop.calcPriceOfFlowers('a', 1, 'a')).to.throw('Invalid input!');
            expect(() => flowerShop.calcPriceOfFlowers(1, 'a', 'a')).to.throw('Invalid input!');
            expect(() => flowerShop.calcPriceOfFlowers('a', 1.5, 1.5)).to.throw('Invalid input!');
        });

        it('Returns correct message', () => {
            expect(flowerShop.calcPriceOfFlowers('a', 1, 2)).to.equal('You need $2.00 to buy a!');
        });
    });

    describe('checkFlowersAvailable tests', () => {
        it('Returns correct message when flower is available', () => {
            expect(flowerShop.checkFlowersAvailable('a', ['a', 'b'])).to.equal('The a are available!');
        });

        it('Returns correct message when flower is missing', () => {
            expect(flowerShop.checkFlowersAvailable('c', ['a', 'b'])).to.equal('The c are sold! You need to purchase more!');
        });
    });

    describe('sellFlowers tests', () => {
        it('Throws error when invalid input', () => {
            expect(() => flowerShop.sellFlowers(1, 1)).to.throw('Invalid input!');
            expect(() => flowerShop.sellFlowers('a', 1)).to.throw('Invalid input!');
            expect(() => flowerShop.sellFlowers(['a'], 'a')).to.throw('Invalid input!');
            expect(() => flowerShop.sellFlowers(['a'], -1)).to.throw('Invalid input!');
            expect(() => flowerShop.sellFlowers(['a'], 1.5)).to.throw('Invalid input!');
            expect(() => flowerShop.sellFlowers(['a', 'b'], 2)).to.throw('Invalid input!');
        });

        it('Works correct', () => {
            expect(flowerShop.sellFlowers(['a', 'b', 'c'], 1)).to.equal('a / c');
        });
    });
});