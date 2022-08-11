const { expect } = require('chai');
const isSymmetric = require('./checkForSymmetry');

describe('isSymmetric', () => {
    it('returns false if input is not array', () => {
        expect(isSymmetric(1)).to.be.false;
    });

    it('returns true for symmetric numeric array', () => {
        expect(isSymmetric([1, 1])).to.be.true;
    });

    it('returns false for non-symmetric numeric array', () => {
        expect(isSymmetric([1, 2])).to.be.false;
    });

    it('returns true for symmetric string array', () => {
        expect(isSymmetric(['a', 'a'])).to.be.true;
    });

    it('returns true for symmetric odd-length array', () => {
        expect(isSymmetric([1, 1, 1])).to.be.true;
    });

    it('returns false for different type array elements', () => {
        expect(isSymmetric([1, '1'])).to.be.false;
    });
});