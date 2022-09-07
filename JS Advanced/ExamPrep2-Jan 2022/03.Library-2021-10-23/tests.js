let library = require('./library.js');
const { expect } = require('chai');

describe('Library tests', () => {
    describe('calcPriceOfBook tests', () => {
        it('Throws error when input is not valid', () => {
            expect(() => library.calcPriceOfBook(1, 1)).to.throw('Invalid input');
            expect(() => library.calcPriceOfBook('a', 1.1)).to.throw('Invalid input');
            expect(() => library.calcPriceOfBook('a', 'b')).to.throw('Invalid input');
        });

        it('Returns default price when year is after 1980', () => {
            expect(library.calcPriceOfBook('a', 1990)).to.equal('Price of a is 20.00');
        });

        it('Returns discount price when year is before or equal 1980', () => {
            expect(library.calcPriceOfBook('a', 1980)).to.equal('Price of a is 10.00');
            expect(library.calcPriceOfBook('a', 1900)).to.equal('Price of a is 10.00');
        });
    });

    describe('findBook tests', () => {
        it('Throws error if no books available', () => {
            expect(() => library.findBook([], 'a')).to.throw('No books currently available');
        });

        it('Returns correct message when desire book exists', () => {
            expect(library.findBook(['a'], 'a')).to.equal('We found the book you want.');
            expect(library.findBook(['a', 'b', 'c'], 'a')).to.equal('We found the book you want.');
        });

        it('Returns correct message when desire book does not exist', () => {
            expect(library.findBook(['a'], 'b')).to.equal('The book you are looking for is not here!');
            expect(library.findBook(['a', 'b', 'c'], 'd')).to.equal('The book you are looking for is not here!');
        });
    });

    describe('arrangeTheBooks tests', () => {
        it('Throws error when countBooks is not integer or positive number', () => {
            expect(() => library.arrangeTheBooks(1.1)).to.throw('Invalid input');
            expect(() => library.arrangeTheBooks(-1)).to.throw('Invalid input');
            expect(() => library.arrangeTheBooks('a')).to.throw('Invalid input');
        });

        it('Returns correct message when countBooks is less or equal 40', () => {
            expect(library.arrangeTheBooks(30)).to.equal('Great job, the books are arranged.');
            expect(library.arrangeTheBooks(40)).to.equal('Great job, the books are arranged.');
        });

        it('Returns correct message when countBooks is more than 40', () => {
            expect(library.arrangeTheBooks(50)).to.equal('Insufficient space, more shelves need to be purchased.');
        });
    });
});