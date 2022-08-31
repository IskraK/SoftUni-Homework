function solve() {
    class Employee {
        constructor(name, age) {
            if (new.target == Employee) {
                throw new Error("Cannot make instance of abstract class Employee.");
            }

            this.name = name;
            this.age = age;
            this.salary = 0;
            this.tasks = [];
        }

        work() {
            let currentTask = this.tasks.shift();
            console.log(`${this.name} ` + currentTask);
            this.tasks.push(currentTask);
        }

        getSalary() {
            return this.salary;
        }

        collectSalary() {
            console.log(`${this.name} received ${this.getSalary()} this month.`);
        }
    }

    class Junior extends Employee {
        constructor(name, age) {
            super(name, age);
            this.tasks.push('is working on a simple task.');
        }
    }

    class Senior extends Employee {
        constructor(name, age) {
            super(name, age);
            this.tasks.push('is working on a complicated task.');
            this.tasks.push('is taking time off work.');
            this.tasks.push('is supervising junior workers.');
        }
    }

    class Manager extends Employee {
        constructor(name, age) {
            super(name, age);
            this.dividend = 0;
            this.tasks.push('scheduled a meeting.');
            this.tasks.push('is preparing a quarterly report.');
        }

        getSalary() {
            return super.getSalary() + this.dividend;
        }
    }

    return { Employee, Junior, Senior, Manager };
}


////second decision 80/100 in Judge, Error:Salary property not found on Junior instance.
// function solve() {
//     class Employee {
//         constructor(name, age) {
//             if (new.target == Employee) {
//                 throw new Error("Cannot make instance of abstract class Employee.");
//             }

//             this.name = name;
//             this.age = age;
//             this._salary = 0;
//             this.tasks = [];
//         }

//         work() {
//             let currentTask = this.tasks.shift();
//             console.log(`${this.name} ` + currentTask);
//             this.tasks.push(currentTask);
//         }

//         get salary() {
//             return this._salary;
//         }

//         set salary(value) {
//             this._salary = value;
//         }

//         collectSalary() {
//             console.log(`${this.name} received ${this.salary} this month.`);
//         }
//     }

//     class Junior extends Employee {
//         constructor(name, age) {
//             super(name, age);
//             this.tasks.push('is working on a simple task.');
//         }
//     }

//     class Senior extends Employee {
//         constructor(name, age) {
//             super(name, age);
//             this.tasks.push('is working on a complicated task.');
//             this.tasks.push('is taking time off work.');
//             this.tasks.push('is supervising junior workers.');
//         }
//     }

//     class Manager extends Employee {
//         constructor(name, age) {
//             super(name, age);
//             this.dividend = 0;
//             this.tasks.push('scheduled a meeting.');
//             this.tasks.push('is preparing a quarterly report.');
//         }

//         get salary() {
//             return this._salary + this.dividend;
//         }

//         set salary(value) {
//             this._salary = value;
//         }
//     }

//     return { Employee, Junior, Senior, Manager };
// }

const classes = solve();
const junior = new classes.Junior('Ivan', 25);

junior.work();
junior.work();

junior.salary = 5811;
junior.collectSalary();

const sinior = new classes.Senior('Alex', 31);

sinior.work();
sinior.work();
sinior.work();
sinior.work();

sinior.salary = 12050;
sinior.collectSalary();

const manager = new classes.Manager('Tom', 55);

manager.salary = 15000;
manager.collectSalary();
manager.dividend = 2500;
manager.collectSalary();
