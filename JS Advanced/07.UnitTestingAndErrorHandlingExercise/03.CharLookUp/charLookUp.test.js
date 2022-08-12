const { expect } = require('chai');
const lookupChar = require('./charLookUp');

describe('Look up for a char in string', () => {
    it('returns undefined when the first param is not string', () => {
        expect(lookupChar(2, 1)).to.be.undefined;
        expect(lookupChar([1], 1)).to.be.undefined;
    });

    it('returns undefined when the second param is not number', () => {
        expect(lookupChar('a', '1')).to.be.undefined;
        expect(lookupChar('a', [1])).to.be.undefined;
    });

    it('returns undefined when the second param is floating-point number', () => {
        expect(lookupChar('ab', 2.5)).to.be.undefined;
    });

    it('returns undefined when both params are not valid type', () => {
        expect(lookupChar(2, 'aa')).to.be.undefined;
        expect(lookupChar([1], 'a')).to.be.undefined;
        expect(lookupChar([1, 2], ['a'])).to.be.undefined;
    });

    it('returns incorrect index when it is negative number', () => {
        expect(lookupChar('ab', -1)).to.equal('Incorrect index');
    });

    it('returns incorrect index when it is bigger than or equal to the string length', () => {
        expect(lookupChar('ab', 2)).to.equal('Incorrect index');
        expect(lookupChar('ab', 3)).to.equal('Incorrect index');
    });

    it('returns correct char of given index', () => {
        expect(lookupChar('ab', 1)).to.equal('b');
    });
});