const dealership = require('./dealership');
const { expect } = require('chai');

describe('Dealership tests', () => {
    describe('newCarCost tests', () => {
        it('returns discounted price when model is supported', () => {
            expect(dealership.newCarCost('Audi A4 B8', 30000)).to.equal(15000);
        });

        it('returns original price when model is not supported', () => {
            expect(dealership.newCarCost('a', 1)).to.equal(1);
        });
    });

    describe('carEquipment tests', () => {
        it('returns the correct array with single element', () => {
            expect(dealership.carEquipment(['a'], [0])).to.deep.equal(['a']);
        });

        it('returns the correct array with multiple elements', () => {
            expect(dealership.carEquipment(['a', 'b', 'c'], [0, 2])).to.deep.equal(['a', 'c']);
        });

        it('returns the correct array with multiple elements and one selected', () => {
            expect(dealership.carEquipment(['a', 'b', 'c'], [1])).to.deep.equal(['b']);
        });
    });

    describe('euroCategory tests', () => {
        it('category is bellow 4', () => {
            expect(dealership.euroCategory(1)).to.equal('Your euro category is low, so there is no discount from the final price!');
        });

        it('category is above 4', () => {
            expect(dealership.euroCategory(5)).to.equal('We have added 5% discount to the final price: 14250.');
        });

        it('category is equal to 4', () => {
            expect(dealership.euroCategory(4)).to.equal('We have added 5% discount to the final price: 14250.');
        });
    });
});