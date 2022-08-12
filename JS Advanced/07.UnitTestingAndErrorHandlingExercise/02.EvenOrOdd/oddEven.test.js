const { expect } = require('chai');
const isOddOrEven = require('./isOddOrEven');

describe('Odd or Even', () => {
    it('returns undefined when input is not string', () => {
        expect(isOddOrEven(1)).to.be.undefined;
    });

    it('returns odd when input string has length odd number', () => {
        expect(isOddOrEven('a')).to.equal('odd');
    });

    it('returns even when input string has length even number', () => {
        expect(isOddOrEven('ab')).to.equal('even');
    });
});