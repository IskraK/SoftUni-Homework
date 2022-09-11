let carService = require('./03.CarService.js');
const { expect } = require('chai');

describe('CarService tests', () => {
    describe('isItExpensive tests', () => {
        it('Returns correct message when param issue is "Engine" or "Transmission', () => {
            expect(carService.isItExpensive('Engine'))
                .to.equal('The issue with the car is more severe and it will cost more money');

            expect(carService.isItExpensive('Transmission'))
                .to.equal('The issue with the car is more severe and it will cost more money');
        });

        it('Returns correct message when param issue is not "Engine" or "Transmission', () => {
            expect(carService.isItExpensive('a'))
                .to.equal('The overall price will be a bit cheaper');
        });
    });

    describe('discount  tests', () => {
        it('Throws error when input is invalid', () => {
            expect(() => carService.discount(1, 'a')).to.throw('Invalid input');
            expect(() => carService.discount('a', 1)).to.throw('Invalid input');
            expect(() => carService.discount('a', 'a')).to.throw('Invalid input');
        });

        it('Returns correct message when param numberOfParts is smaller or equal to 2', () => {
            expect(carService.discount(1, 1)).to.equal('You cannot apply a discount');
            expect(carService.discount(2, 1)).to.equal('You cannot apply a discount');
        });

        it('Returns correct message with discount 15% when param numberOfParts is higher than 2 and smaller or equal to 7', () => {
            expect(carService.discount(3, 100)).to.equal('Discount applied! You saved 15$');
            expect(carService.discount(7, 100)).to.equal('Discount applied! You saved 15$');
        });

        it('Returns correct message with discount 30% when param numberOfParts is higher than 7', () => {
            expect(carService.discount(8, 100)).to.equal('Discount applied! You saved 30$');
        });
    });

    describe('partsToBuy  tests', () => {
        it('Throws error when input is invalid', () => {
            expect(() => carService.partsToBuy(1, 'a')).to.throw('Invalid input');
            expect(() => carService.partsToBuy(['a'], 1)).to.throw('Invalid input');
            expect(() => carService.partsToBuy('a', ['a'])).to.throw('Invalid input');
        });

        it('Returns 0 when partsCatalog is empty', () => {
            expect(carService.partsToBuy([], ['a'])).to.equal(0);
        });

        it('Works correct', () => {
            expect(carService.partsToBuy([{ part: 'a', price: 1 }, { part: 'b', price: 2 }], ['a'])).to.equal(1);
            expect(carService.partsToBuy([{ part: 'a', price: 1 }, { part: 'b', price: 2 },
            { part: 'c', price: 3 }], ['a', 'c'])).to.equal(4);
        });
    });
});