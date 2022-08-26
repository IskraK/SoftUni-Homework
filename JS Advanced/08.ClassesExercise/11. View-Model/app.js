// class Textbox {
//     constructor(selector, regex) {
//         this.selector = selector;
//         this.regex = regex;
//         this.elements = document.querySelectorAll(selector);
//         this._invalidSymbols = new RegExp(this.regex);
//     }

//     get regex() {
//         return this._regex;
//     }

//     set regex(value) {
//         this._regex = value;
//         this._invalidSymbols = new RegExp(this.regex);
//     }

//     get elements() {
//         return this._elements;
//     }

//     set elements(value) {
//         this._elements = value;
//         Array.from(this._elements).forEach(e => e.addEventListener('input', (ev) => {
//             Array.from(this.elements).forEach(e => e.value = ev.target.value);
//             this.value = ev.target.value;
//         }));
//     }

//     get value() {
//         return this._value;
//     }

//     set value(value) {
//         this._value = value;
//         Array.from(this._elements).forEach(e => e.value = value);
//     }

//     isValid() {
//         for (const item of this._elements) {
//             if (this._invalidSymbols.test(item.value)) {
//                 return false;
//             }
//         }
//         return true;
//     }
// }


//another decision
class Textbox {
    constructor(selector, regex) {
        this.selector = selector;
        this.regex = regex; //pattern
        this.elements = document.querySelectorAll(selector);
        this._invalidSymbols = new RegExp(this.regex);

    }

    get elements() {
        return this._elements;
    }

    set elements(value) {
        this._elements = value;
        Array.from(this._elements).forEach(e => e.addEventListener('input', (ev) => {
            Array.from(this.elements).forEach(e => e.value = ev.target.value);
            this.value = ev.target.value;
        }));
    }

    get value() {
        return this._value;
    }

    set value(value) {
        Array.from(this._elements).forEach(e => e.value = value);
        this._value = value;
    }

    isValid() {
        for (const item of this._elements) {
            if (this._invalidSymbols.test(item.value)) {
                return false;
            }
        }
        return true;
    }
}

let textbox = new Textbox(".textbox", /[^a-zA-Z0-9]/);
let inputs = document.getElementsByClassName('.textbox');

inputs.addEventListener('click', function () { console.log(textbox.value); });
