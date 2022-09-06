const { Repository } = require("./solution.js");
const { expect, assert } = require('chai');

//90/100
describe("Repository tests", function () {
    let properties;
    this.beforeEach(() => {
        properties = {
            name: "string",
            age: "number",
            birthday: "object"
        };
    });

    describe("Constructor tests", () => {
        it('Should add props', () => {
            let repo = new Repository(properties);
            expect(repo).to.have.property('props');
            expect(repo.props).to.deep.equal({
                name: "string",
                age: "number",
                birthday: "object"
            });
        });

        it('Should initialize properties data and nextId', () => {
            let repo = new Repository(properties);
            expect(repo).to.have.property('data');
            expect(typeof repo.data).to.equal('object');
            expect(repo.data).instanceOf(Map);
            expect(repo).to.have.property('nextId');
            expect(repo.nextId()).to.equal(0);
        });
    });

    describe('Count tests', () => {
        it('Returns zero when no entities are added to data map', () => {
            let repo = new Repository(properties);
            expect(repo.count).to.equal(0);
        });

        it('Returns correct size of data map', () => {
            let repo = new Repository(properties);
            let entity = {
                name: "Pesho",
                age: 22,
                birthday: new Date(1998, 0, 7)
            };
            repo.add(entity);

            expect(repo.count).to.equal(1);
        });
    });

    describe('Add tests', () => {
        it('Should work correct when entity is valid', () => {
            let repo = new Repository(properties);
            let entity = {
                name: "Pesho",
                age: 22,
                birthday: new Date(1998, 0, 7)
            };

            expect(repo.add(entity)).to.equal(0);
            expect(repo.count).to.equal(1);
        });

        it('Should work correct when entities are valid', () => {
            let repo = new Repository(properties);
            let entity = {
                name: "Pesho",
                age: 22,
                birthday: new Date(1998, 0, 7)
            };
            let entity2 = {
                name: "Gosho",
                age: 32,
                birthday: new Date(1998, 0, 7)
            };

            expect(repo.add(entity)).to.equal(0);
            expect(repo.add(entity2)).to.equal(1);
            expect(repo.count).to.equal(2);
        });

        it('Should throw error when a propery is missing', () => {
            let repo = new Repository(properties);
            let entity = {
                name: "Pesho",
                age: 22,
            };
            let entity2 = {
                name: "Gosho",
                birthday: new Date(1998, 0, 7)
            };
            let entity3 = {
                age: 22,
                birthday: new Date(1998, 0, 7)
            };
            let entity4 = {
                name: "Pesho",
                age: 22,
                day: new Date(1998, 0, 7)
            };

            expect(() => repo.add(entity)).to.throw('Property birthday is missing from the entity!');
            expect(() => repo.add(entity2)).to.throw('Property age is missing from the entity!');
            expect(() => repo.add(entity3)).to.throw('Property name is missing from the entity!');
            expect(() => repo.add(entity4)).to.throw('Property birthday is missing from the entity!');
        });

        it('Should throw error when a propery is not in correct type', () => {
            let repo = new Repository(properties);
            let entity = {
                name: "Pesho",
                age: 22,
                birthday: 2022 / 07 / 31
            };
            let entity2 = {
                name: "Pesho",
                age: '22',
                birthday: new Date(1998, 0, 7)
            };
            let entity3 = {
                name: 1,
                age: 22,
                birthday: new Date(1998, 0, 7)
            };

            expect(() => repo.add(entity)).to.throw(TypeError, 'Property birthday is not of correct type!');
            expect(() => repo.add(entity2)).to.throw(TypeError, 'Property age is not of correct type!');
            expect(() => repo.add(entity3)).to.throw(TypeError, 'Property name is not of correct type!');
        });
    });

    describe('getId tests', () => {
        it('Should throw error when entity with given id does not exist', () => {
            let repo = new Repository(properties);
            let entity = {
                name: "Pesho",
                age: 22,
                birthday: new Date(1998, 0, 7)
            };
            repo.add(entity);

            expect(() => repo.getId(1)).to.throw('Entity with id: 1 does not exist!');
            expect(() => repo.getId(-1)).to.throw('Entity with id: -1 does not exist!');
        });

        it('Should return entity with given id', () => {
            let repo = new Repository(properties);
            let entity = {
                name: "Pesho",
                age: 22,
                birthday: new Date(1998, 0, 7)
            };
            let entity2 = {
                name: "Gosho",
                age: 32,
                birthday: new Date(1998, 0, 7)
            };
            repo.add(entity);
            repo.add(entity2);

            expect(repo.getId(0)).to.deep.equal(entity);
            expect(repo.getId(1)).to.deep.equal(entity2);
        });
    });

    describe('Update tests', () => {
        it('Should throw error when the given id does not exist', () => {
            let repo = new Repository(properties);
            let entity = {
                name: "Pesho",
                age: 22,
                birthday: new Date(1998, 0, 7)
            };
            let entity2 = {
                name: "Gosho",
                age: 32,
                birthday: new Date(1998, 0, 7)
            };
            repo.add(entity);
            repo.add(entity2);

            expect(() => repo.update(2, entity2)).to.throw('Entity with id: 2 does not exist!');
            expect(() => repo.update(-1, entity2)).to.throw('Entity with id: -1 does not exist!');

        });

        it('Should throw error when entity with invalid type of params is passed', () => {
            let repo = new Repository(properties);
            let entity = {
                name: "Pesho",
                age: 22,
                birthday: new Date(1998, 0, 7)
            };
            repo.add(entity);

            let entity2 = {
                name: "Gosho",
                age: 32,
                birthday: '1'
            };
            let entity3 = {
                name: "Pesho",
                age: '22',
                birthday: new Date(1998, 0, 7)
            };
            let entity4 = {
                name: 1,
                age: 22,
                birthday: new Date(1998, 0, 7)
            };

            expect(() => repo.update(0, entity2)).to.throw();
            expect(() => repo.update(0, entity3)).to.throw();
            expect(() => repo.update(0, entity4)).to.throw();
        });

        it('Should throw error when entity with missing params is passed', () => {
            let repo = new Repository(properties);
            let entity = {
                name: "Pesho",
                age: 22,
                birthday: new Date(1998, 0, 7)
            };
            repo.add(entity);

            let entity2 = {
                name: "Pesho",
                age: 22
            };
            let entity3 = {
                name: "Pesho",
                birthday: new Date(1998, 0, 7)
            };
            let entity4 = {
                age: 22,
                birthday: new Date(1998, 0, 7)
            };

            expect(() => repo.update(0, entity2)).to.throw();
            expect(() => repo.update(0, entity3)).to.throw();
            expect(() => repo.update(0, entity4)).to.throw();
        });

        it('Should replace entity on valid id with valid entity', () => {
            let repo = new Repository(properties);
            let entity = {
                name: "Pesho",
                age: 22,
                birthday: new Date(1998, 0, 7)
            };
            let entity2 = {
                name: "Gosho",
                age: 32,
                birthday: new Date(1998, 0, 7)
            };
            repo.add(entity);
            repo.add(entity2);
            repo.update(0, entity2);

            expect(repo.getId(0)).to.deep.equal(entity2);
        });
    });

    describe('Del tests', () => {
        it('Should throw error when the given id does not exist', () => {
            let repo = new Repository(properties);
            let entity = {
                name: "Pesho",
                age: 22,
                birthday: new Date(1998, 0, 7)
            };
            let entity2 = {
                name: "Gosho",
                age: 32,
                birthday: new Date(1998, 0, 7)
            };
            repo.add(entity);
            repo.add(entity2);

            expect(() => repo.del(2)).to.throw('Entity with id: 2 does not exist!');
            expect(() => repo.del(-1)).to.throw('Entity with id: -1 does not exist!');

        });

        it('Should delete entity on valid id', () => {
            let repo = new Repository(properties);
            let entity = {
                name: "Pesho",
                age: 22,
                birthday: new Date(1998, 0, 7)
            };
            let entity2 = {
                name: "Gosho",
                age: 32,
                birthday: new Date(1998, 0, 7)
            };
            repo.add(entity);
            repo.add(entity2);

            expect(repo.count).to.equal(2);

            repo.del(0);

            expect(repo.count).to.equal(1);
        });
    });
});


// //100/100
// describe("Repository Tests", () => {
//     let instance = {};

//     beforeEach(() => instance = new Repository({
//         name: 'string',
//         age: 'number',
//         birthday: 'object'
//     }));

//     describe('Test should check number of Map elements', () => {
//         it('should return that Map size is 0', () => {
//             expect(instance.count).to.equal(0);
//         });
//     });

//     describe('Test should add valid object to the instance', () => {
//         it('should return zero id for only one object added', () => {
//             expect(instance.add({ name: 'ji', age: 10, birthday: {} })).to.equal(0);
//         });
//     });

//     describe('Tests should check getId function', () => {
//         it('should return that entity with the given id does not exist', () => {
//             expect(() => instance.getId(10)).to.throw('Entity with id: 10 does not exist!');
//         });
//     });

//     describe('Tests should check update function', () => {
//         it('should throw error for no id presented in the data', () => {
//             expect(() => instance.update(0, {},)).to.throw('Entity with id: 0 does not exist!');
//         });

//         it('should throw error for missing prop in object', () => {
//             instance.add({ name: '', age: 0, birthday: {}, });
//             expect(() => instance.update(0, { age: 1, birthday: { date: 0 } })).to.throw(Error);
//         });

//         it('should throw TypeError for invalid type input', () => {
//             instance.add({ name: '', age: 0, birthday: {}, });
//             expect(() => instance.update(0, { name: 0, age: 1, birthday: { date: 0 } })).to.throw(TypeError);
//         });
//     })

//     describe('Tests should check del funtion', () => {
//         it('should delete the given index correctly', () => {
//             instance.add({ name: '', age: 1, birthday: {} });
//             instance.add({ name: '', age: 1, birthday: {} });
//             instance.del(1);
//             expect(instance.data.has(1)).to.eq(false);
//         });

//         it('should throw error for not existing index in the collection', () => {
//             expect(() => instance.del(-10)).to.throw('Entity with id: -10 does not exist!');
//         });
//     });
// });


// //100/100
// describe("Repository", function () {
//     let properties;
//     this.beforeEach(() => {
//         properties = {
//             name: "string",
//             age: "number",
//             birthday: "object"
//         };
//     })

//     describe("constructor", function () {
//         it("Instantiation should work", function () {
//             let repo = new Repository(properties)

//             assert.deepEqual(repo.props, {
//                 name: "string",
//                 age: "number",
//                 birthday: "object"
//             })

//             assert.equal(repo.nextId(), 0);
//             assert.typeOf(repo.data, 'Map');
//         });
//     });

//     describe("count", function () {
//         it("count should work", function () {
//             let repo = new Repository(properties)
//             let pesho = {
//                 name: "Pesho",
//                 age: 22,
//                 birthday: new Date(1998, 0, 7)
//             }
//             assert.equal(repo.count, 0);

//             repo.add(pesho);
//             assert.equal(repo.count, 1);
//         });
//     })

//     describe("add", function () {
//         it("add should work", function () {
//             let repo = new Repository(properties)
//             let firstId = repo.add({
//                 name: "Pesho",
//                 age: 22,
//                 birthday: new Date(1998, 0, 7)
//             });

//             let secondId = repo.add({
//                 name: "Pesho",
//                 age: 22,
//                 birthday: new Date(1998, 0, 7)
//             });

//             assert.equal(firstId, 0);
//             assert.equal(secondId, 1);
//             assert.equal(repo.count, 2);
//         });

//         it("add should throw error if non-existing property is passed", function () {
//             let repo = new Repository(properties)
//             assert.throw(() => {
//                 repo.add({
//                     name: "Pesho",
//                     birthday: new Date(1998, 0, 7)
//                 })
//             })

//             assert.throw(() => {
//                 repo.add({
//                     name: "Pesho",
//                     age: 22,
//                     peshoDate: new Date(1998, 0, 7)
//                 })
//             }, 'Property birthday is missing from the entity!')

//             assert.throw(() => {
//                 repo.add({
//                     age: 22,
//                     birthday: new Date(1998, 0, 7)
//                 })
//             })
//         });

//         it("add should throw error if invalid property is passed", function () {
//             let repo = new Repository(properties)
//             assert.throw(() => {
//                 repo.add({
//                     name: "Pesho",
//                     age: '22',
//                     birthday: '1998/01/07'
//                 })
//             }, 'Property age is not of correct type!')

//             assert.throw(() => {
//                 repo.add({
//                     name: "Pesho",
//                     age: '22',
//                     birthday: new Date(1998, 0, 7)
//                 })
//             })

//             assert.throw(() => {
//                 repo.add({
//                     name: 55,
//                     age: 22,
//                     birthday: new Date(1998, 0, 7)
//                 })
//             })
//         });
//     })

//     describe("getId", function () {
//         it("getId should work", function () {
//             let repo = new Repository(properties)
//             let pesho = {
//                 name: "Pesho",
//                 age: 22,
//                 birthday: new Date(1998, 0, 7)
//             }

//             repo.add(pesho);
//             repo.add(pesho);

//             assert.deepEqual(pesho, repo.getId(0));
//             assert.deepEqual(pesho, repo.getId(1));
//         });

//         it("getId throw error if Id not exist should work", function () {
//             let repo = new Repository(properties)
//             assert.throw(() => {
//                 repo.getId(0);
//             })
//         });
//     })

//     describe("update", function () {
//         it("update throw error if entity with invalid params is passed", function () {
//             let repo = new Repository(properties)
//             let pesho = {
//                 name: "Pesho",
//                 age: 22,
//                 birthday: new Date(1998, 0, 7)
//             }
//             repo.add(pesho);

//             let gosho = {
//                 name: "Gosho",
//                 age: 22,
//                 date: new Date(2000, 1, 1)
//             }

//             let tosho = {
//                 name: "Gosho",
//                 age: 22,
//             }

//             assert.throw(() => {
//                 repo.update(0, gosho)
//             })

//             assert.throw(() => {
//                 repo.update(0, tosho)
//             })
//         });

//         it("update throw error if entity with invalid type is passed", function () {
//             let repo = new Repository(properties)
//             let pesho = {
//                 name: "Pesho",
//                 age: 22,
//                 birthday: new Date(1998, 0, 7)
//             }
//             repo.add(pesho);

//             let gosho = {
//                 name: "Gosho",
//                 age: '22',
//                 birthday: new Date(1998, 0, 7)
//             }

//             let t = {
//                 name: "Gosho",
//                 age: 22,
//                 birthday: '1998, 0, 7'
//             }

//             assert.throw(() => {
//                 repo.update(0, gosho)
//             })

//             assert.throw(() => {
//                 repo.update(0, t)
//             })
//         });

//         it("update throw error if Id not exist", function () {
//             let repo = new Repository(properties)
//             let pesho = {
//                 name: "Pesho",
//                 age: 22,
//                 birthday: new Date(1998, 0, 7)
//             }

//             assert.throw(() => {
//                 repo.update(0, pesho);
//             })

//             assert.throw(() => {
//                 repo.update(1, pesho);
//             })

//             assert.throw(() => {
//                 repo.update(-1, pesho);
//             })
//         });

//         it("update  should work", function () {
//             let repo = new Repository(properties)
//             let pesho = {
//                 name: "Pesho",
//                 age: 22,
//                 birthday: new Date(1998, 0, 7)
//             }

//             repo.add(pesho);
//             repo.add(pesho);

//             let gosho = {
//                 name: "Gosho",
//                 age: 22,
//                 birthday: new Date(1998, 0, 7)
//             }

//             repo.update(1, gosho);
//             assert.deepEqual(repo.getId(1), gosho)
//         });
//     })

//     describe('del', () => {
//         it('Should work', () => {
//             let repo = new Repository(properties)
//             let pesho = {
//                 name: "Pesho",
//                 age: 22,
//                 birthday: new Date(1998, 0, 7)
//             }
//             repo.add(pesho);
//             repo.add(pesho);

//             assert.equal(repo.count, 2);

//             repo.del(0);
//             repo.del(1);

//             assert.equal(repo.count, 0);
//         })

//         it('Should throw error if id dont exist', () => {
//             let repo = new Repository(properties)

//             assert.throw(() => {
//                 repo.del(1);
//             })
//         })
//     })
// });