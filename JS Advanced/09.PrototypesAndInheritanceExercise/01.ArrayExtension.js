(function solve() {
    Array.prototype.last = function () {
        return this[this.length - 1];
    };

    Array.prototype.skip = function (n) {
        let result = [];
        for (let i = n; i < this.length; i++) {
            result.push(this[i]);
        }

        return result;
    };

    Array.prototype.take = function (n) {
        let result = [];
        for (let i = 0; i < n; i++) {
            result.push(this[i]);
        }

        return result;
    }

    Array.prototype.sum = function () {
        let sum = 0;
        for (const item of this) {
            sum += item;
        }

        return sum;
    }

    Array.prototype.average = function () {
        return this.sum() / this.length;
    }
})();


// //second decision
// (function solve() {
//     Array.prototype.last = function () {
//         return this[this.length - 1];
//     }

//     Array.prototype.skip = function (n) {
//         return this.slice(n);
//     }

//     Array.prototype.take = function (n) {
//         return this.slice(0, n);
//     }

//     Array.prototype.sum = function () {
//         return this.reduce((acc, curr) => acc + curr, 0);
//     }

//     Array.prototype.average = function () {
//         return this.sum() / this.length;
//     }
// })();

let arr = [1, 2, 3];
console.log(arr.last());
console.log(arr.skip(1));
console.log(arr.take(2));
console.log(arr.sum());
console.log(arr.average());
