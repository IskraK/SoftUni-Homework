const { expect } = require('chai');
const sum = require('./sumNumbers');

describe('Sum function', () => {
    it('sums single number', () => {
        expect(sum([1])).to.equal(1);
    });

    //Test overloading
    it('sums multiple numbers', () => {
        expect(sum([1,1])).to.equal(2);
    });

    it('sums different numbers', () => {
        expect(sum([1, 2, 3])).to.equal(6);
    });
});