function extensibleObject() {
    const proto = {};
    const instance = Object.create(proto);

    instance.extend = function (template) {
        Object.entries(template).forEach(([key, value]) => {
            if (typeof value === 'function') {
                proto[key] = value;
            } else {
                instance[key] = value;
            }
        });
    }

    return instance;
}

const myObj = extensibleObject();

const template = {
    extensionMethod: function () { },
    extensionProperty: 'someString'
}
myObj.extend(template);
