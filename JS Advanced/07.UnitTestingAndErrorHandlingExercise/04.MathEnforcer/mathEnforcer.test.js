const { expect } = require('chai');
const { mathEnforcer } = require('./mathEnforcer');

describe('Math Enforcer', () => {
    describe('addFive', () => {
        it('returns undefined with non-number parameter', () => {
            expect(mathEnforcer.addFive('1')).to.be.undefined;
        });

        it('returns correct result for positive integer param', () => {
            expect(mathEnforcer.addFive(1)).to.equal(6);
        });

        it('returns correct result for negative integer param', () => {
            expect(mathEnforcer.addFive(-1)).to.equal(4);
        });

        it('returns correct result for floating-point param', () => {
            expect(mathEnforcer.addFive(2.56)).to.be.closeTo(7.56, 0.01);
        });
    });

    describe('subtractTen', () => {
        it('returns undefined with non-number parameter', () => {
            expect(mathEnforcer.subtractTen('1')).to.be.undefined;
        });

        it('returns correct result for positive integer param', () => {
            expect(mathEnforcer.subtractTen(20)).to.equal(10);
        });

        it('returns correct result for negative integer param', () => {
            expect(mathEnforcer.subtractTen(-10)).to.equal(-20);
        });

        it('returns correct result for floating-point param', () => {
            expect(mathEnforcer.subtractTen(12.56)).to.be.closeTo(2.56, 0.01);
        });
    });

    describe('sum', () => {
        it('returns undefined with one non-number parameter', () => {
            expect(mathEnforcer.sum('1', 1)).to.be.undefined;
            expect(mathEnforcer.sum(1, '')).to.be.undefined;
        });

        it('returns undefined with both non-number params', () => {
            expect(mathEnforcer.sum('1', '2')).to.be.undefined;
        });

        it('returns correct result for positive integer params', () => {
            expect(mathEnforcer.sum(1, 2)).to.equal(3);
        });

        it('returns correct result for negative integer params', () => {
            expect(mathEnforcer.sum(-1, -2)).to.equal(-3);
        });

        it('returns correct result for floating-point params', () => {
            expect(mathEnforcer.sum(2.56, -4.77)).to.be.closeTo(-2.21, 0.01);
        });
    });
});