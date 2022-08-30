function extendPrototype(classToExtend) {
    classToExtend.prototype.species = 'Human';
    classToExtend.prototype.toSpeciesString = function () {
        return `I am a ${this.species}. ${this.toString()}`;
    };
}



function Person(name, age) {
    this.name = name;
    this.age = age;
}

Person.prototype.toString = function () {
    return `To string method from prototype of ${this.name}`;
}

extendPrototype(Person);

const person = new Person('Peter', 21);

console.log(person.toSpeciesString());
console.log(person.species);