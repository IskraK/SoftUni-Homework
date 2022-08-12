function validate() {
    document.getElementById('company').addEventListener('change', showCompanyInfo);
    document.getElementById('submit').addEventListener('click', getValidation);

    function showCompanyInfo(ev) {
        let companyInfo = document.getElementById('companyInfo');
        if (ev.target.checked) {
            companyInfo.style.display = 'block';
        } else {
            companyInfo.style.display = 'none';
        }
    }

    function getValidation(ev) {
        ev.preventDefault();

        const [username, email, password, confirmPassword, company, companyNumber] = document.querySelectorAll('input');
        const invalidInput = [];

        const usernamePattern = /^[A-Za-z0-9]{3,20}$/;
        const passwordPattern = /^[\w]{5,15}$/;
        const emailPattern = /(.*)@(.*){1,}\.(.*){1,}/;
        const companyNumberPattern = /^[0-9]{4}$/;

        if (!usernamePattern.test(username.value)) {
            invalidInput.push(username);
        }

        if (!passwordPattern.test(password.value)) {
            invalidInput.push(password);
        }

        if (!passwordPattern.test(confirmPassword.value) || password.value !== confirmPassword.value) {
            invalidInput.push(confirmPassword);
        }

        if (!emailPattern.test(email.value)) {
            invalidInput.push(email);
        }

        if (company.checked && !companyNumberPattern.test(companyNumber.value)) {
            invalidInput.push(companyNumber);
        }

        invalidInput.forEach(field => field.style.borderColor = 'red');
        !invalidInput.length ? document.getElementById('valid').style.display = 'block'
            : document.getElementById('valid').style.display = 'none';
    }
}
