function calculator() {
    let field1 = null;
    let field2 = null;
    let result = null;

    return {
        init,
        add,
        subtract
    };

    function init(n1, n2, res) {
        field1 = document.querySelector(n1);
        field2 = document.querySelector(n2);
        result = document.querySelector(res);
    }

    function add() {
        result.value = Number(field1.value) + Number(field2.value);
    }

    function subtract() {
        result.value = Number(field1.value) - Number(field2.value);
    }
}

const calculate = calculator();
calculate.init('#num1', '#num2', '#result'); 