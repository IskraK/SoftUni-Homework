let bookSelection = require('./bookSelection.js');
const { expect } = require('chai');

describe('Book Selection tests', () => {
    describe('isGenreSuitable tests', () => {
        it('Returns correct message when genre is "Thriller" and age is less or equal to 12', () => {
            expect(bookSelection.isGenreSuitable('Thriller', 1))
                .to.equal('Books with Thriller genre are not suitable for kids at 1 age');

            expect(bookSelection.isGenreSuitable('Thriller', 12))
                .to.equal('Books with Thriller genre are not suitable for kids at 12 age');
        });

        it('Returns correct message when genre is "Horror" and age is less or equal to 12', () => {
            expect(bookSelection.isGenreSuitable('Horror', 11))
                .to.equal('Books with Horror genre are not suitable for kids at 11 age');

            expect(bookSelection.isGenreSuitable('Horror', 12))
                .to.equal('Books with Horror genre are not suitable for kids at 12 age');
        });

        it('Returns correct message when genre is not "Thriller" or "Horror"', () => {
            expect(bookSelection.isGenreSuitable('Story', 1))
                .to.equal('Those books are suitable');
        });

        it('Returns correct message when genre is "Thriller" or "Horror" and age is bigger than 12', () => {
            expect(bookSelection.isGenreSuitable('Thriller', 13))
                .to.equal('Those books are suitable');

            expect(bookSelection.isGenreSuitable('Horror', 13))
                .to.equal('Those books are suitable');
        });
    });

    describe('isItAffordable tests', () => {
        it('Throws error when input is invalid', () => {
            expect(() => bookSelection.isItAffordable('a', 1)).to.throw('Invalid input');
            expect(() => bookSelection.isItAffordable(1, 'a')).to.throw('Invalid input');
            expect(() => bookSelection.isItAffordable('a', 'a')).to.throw('Invalid input');
        });

        it('Returns correct message when the budget is less than the price of the book', () => {
            expect(bookSelection.isItAffordable(2, 1)).to.equal('You don\'t have enough money');
        });

        it('Returns correct message when the budget is more than the price of the book', () => {
            expect(bookSelection.isItAffordable(1, 2)).to.equal('Book bought. You have 1$ left');
        });
    });

    describe('suitableTitles tests', () => {
        it('Throws error when input is invalid', () => {
            expect(() => bookSelection.suitableTitles('a', 1)).to.throw('Invalid input');
            expect(() => bookSelection.suitableTitles(1, 'a')).to.throw('Invalid input');
            expect(() => bookSelection.suitableTitles('a', 'a')).to.throw('Invalid input');
        });

        it('Works correct', () => {
            expect(bookSelection.suitableTitles([{ title: 'a', genre: 'Thriller' }], 'Thriller'))
                .to.deep.equal(['a']);
            expect(bookSelection.suitableTitles([{ title: 'a', genre: 'Thriller' }, { title: 'b', genre: 'Thriller' }], 'Thriller'))
                .to.deep.equal(['a', 'b']);
            expect(bookSelection.suitableTitles([], 'Thriller'))
                .to.deep.equal([]);
        });
    });
});