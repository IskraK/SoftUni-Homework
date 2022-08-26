const { expect } = require('chai');
const PaymentPackage = require('./PaymentPackage');

describe('Tests for Payment Package Class', () => {
    describe('Tests for property name', () => {
        it('Constructor sets correct values of properties', () => {
            let instance = new PaymentPackage('Name', 1);

            expect(instance._name).equal('Name');
            expect(instance._value).equal(1);
            expect(instance._VAT).equal(20);
            expect(instance._active).equal(true);
        });

        it('Setter should throw error when name is not string', () => {
            expect(() => new PaymentPackage('', 1)).to.throw('Name must be a non-empty string');
            expect(() => new PaymentPackage(1, 1)).to.throw('Name must be a non-empty string');
            expect(() => new PaymentPackage([1], 1)).to.throw('Name must be a non-empty string');
            expect(() => new PaymentPackage(['a'], 1)).to.throw('Name must be a non-empty string');
            expect(() => new PaymentPackage(null, 1)).to.throw('Name must be a non-empty string');
            expect(() => new PaymentPackage(undefined, 1)).to.throw('Name must be a non-empty string');
        });

        it('Setter works correct', () => {
            let instance = new PaymentPackage('Name', 1);
            instance.name = 'new Name';

            expect(instance._name).equal('new Name');
        });
    });

    describe('Tests for property value', () => {
        it('Setter should throw error when value is not positive number', () => {
            expect(() => new PaymentPackage('aaa', -1)).to.throw('Value must be a non-negative number');
            expect(() => new PaymentPackage('aaa', '1')).to.throw('Value must be a non-negative number');
            expect(() => new PaymentPackage('aaa', 'ab')).to.throw('Value must be a non-negative number');
            expect(() => new PaymentPackage('aaa', [1])).to.throw('Value must be a non-negative number');
            expect(() => new PaymentPackage('aaa', '')).to.throw('Value must be a non-negative number');
            expect(() => new PaymentPackage('aaa', null)).to.throw('Value must be a non-negative number');
            //expect(() => new PaymentPackage('aaa', NaN)).to.throw('Value must be a non-negative number');
            expect(() => new PaymentPackage('aaa', undefined)).to.throw('Value must be a non-negative number');
        });

        it('Setter works correct', () => {
            let instance = new PaymentPackage('Name', 1);
            instance.value = 2;

            expect(instance._value).equal(2);
            expect(() => instance.value = 3).not.to.throw('Value must be a non-negative number');
        });

        it('Setter works correct when value is set to zero', () => {
            let instance = new PaymentPackage('Name', 1);
            instance.value = 0;

            expect(instance._value).equal(0);
            expect(() => instance.value = 0).not.to.throw('Value must be a non-negative number');
        });
    });

    describe('Tests for property VAT', () => {
        it('Setter should throw error when VAT is not positive number', () => {
            let instance = new PaymentPackage('Name', 1);
            expect(() => instance.VAT = '').to.throw('VAT must be a non-negative number');
            expect(() => instance.VAT = 'a').to.throw('VAT must be a non-negative number');
            expect(() => instance.VAT = '1').to.throw('VAT must be a non-negative number');
            expect(() => instance.VAT = [1]).to.throw('VAT must be a non-negative number');
            expect(() => instance.VAT = null).to.throw('VAT must be a non-negative number');
            expect(() => instance.VAT = undefined).to.throw('VAT must be a non-negative number');
            expect(() => instance.VAT = -1).to.throw('VAT must be a non-negative number');
        });

        it('Setter works correct', () => {
            let instance = new PaymentPackage('Name', 1);
            instance.VAT = 2;

            expect(instance._VAT).equal(2);
            expect(() => instance.VAT = 3).not.to.throw('VAT must be a non-negative number');
        });

        it('Setter works correct when VAT is set to zero', () => {
            let instance = new PaymentPackage('Name', 1);
            instance.VAT = 0;

            expect(instance._VAT).equal(0);
            expect(() => instance.VAT = 0).not.to.throw('VAT must be a non-negative number');
        });
    });

    describe('Tests for property active', () => {
        it('Setter should throw error when active is not boolean', () => {
            let instance = new PaymentPackage('Name', 1);
            expect(() => instance.active = 'a').to.throw('Active status must be a boolean');
            expect(() => instance.active = 1).to.throw('Active status must be a boolean');
            expect(() => instance.active = [1]).to.throw('Active status must be a boolean');
            expect(() => instance.active = null).to.throw('Active status must be a boolean');
            expect(() => instance.active = undefined).to.throw('Active status must be a boolean');
            expect(() => instance.active = NaN).to.throw('Active status must be a boolean');
        });

        it('Setter works correct', () => {
            let instance = new PaymentPackage('Name', 1);
            instance.active = false;

            expect(instance._active).equal(false);
            expect(() => instance.VAT = true).not.to.throw('Active status must be a boolean');
            expect(() => instance.VAT = false).not.to.throw('Active status must be a boolean');
        });
    });

    describe('Tests for toString method', () => {
        it('Works correct and returns string when data are valid and active is true', () => {
            let instance = new PaymentPackage('Name', 10);

            let output = [
                `Package: Name`,
                `- Value (excl. VAT): 10`,
                `- Value (VAT 20%): 12`
            ]
            expect(instance.toString()).to.equal(output.join('\n'));
        });

        it('Works correct and returns string when data are valid and active is false', () => {
            let instance = new PaymentPackage('Name', 10);
            instance.active = false;
            instance.VAT = 30;

            let output = [
                `Package: Name (inactive)`,
                `- Value (excl. VAT): 10`,
                `- Value (VAT 30%): 13`
            ]
            expect(instance.toString()).to.equal(output.join('\n'));
        });
    });
});