const { expect } = require('chai');
const createCalculator = require('./addSubtract');

describe('Add Subtract', () => {
    it('returns object', () => {
        expect(typeof createCalculator()).to.equal('object');
    });

    it('returns functions as properties', () => {
        expect(typeof createCalculator().add).to.equal('function');
        expect(typeof createCalculator().subtract).to.equal('function');
        expect(typeof createCalculator().get).to.equal('function');
    });

    it('add works and get returns correct sum', () => {
        let calc = createCalculator();
        calc.add('1');
        expect(calc.get()).to.equal(1);
    });

    it('subtract works and get returns correct sum', () => {
        let calc = createCalculator();
        calc.subtract('1');
        expect(calc.get()).to.equal(-1);
    });

    it('add/subtract works correct with a lot of operations', () => {
        let calc = createCalculator();
        calc.add('1');
        calc.subtract(2);
        calc.add(3);
        expect(calc.get()).to.equal(2);
    });

    it('add only takes number or number as string', () => {
        let calc = createCalculator();
        calc.add('a');
        expect(calc.get()).to.be.NaN;
    });

    it('subtract only takes number or number as string', () => {
        let calc = createCalculator();
        calc.subtract('a');
        expect(calc.get()).to.be.NaN;
    });

    it('add does not work without parameter', () => {
        let calc = createCalculator();
        calc.add();
        expect(calc.get()).to.be.NaN;
    });

    it('subtract does not work without parameter', () => {
        let calc = createCalculator();
        calc.subtract();
        expect(calc.get()).to.be.NaN;
    });

    it('internal sum cannot be modified from outside', () => {
        let calc = createCalculator();
        calc.add('1');
        expect(calc.value += 1).to.be.NaN;
    });

    it('internal sum value cannot be accessed', () => {
        let calc = createCalculator();
        calc.add('1');
        expect(calc.value).to.be.undefined;
    });
});