function encodeAndDecodeMessages() {
    const textareas = document.querySelectorAll('textarea');
    const buttons = document.querySelectorAll('button');

    buttons[0].addEventListener('click', encode);
    buttons[1].addEventListener('click', decode);

    function encode() {
        const input = textareas[0].value;
        let encoded = '';

        for (let i = 0; i < input.length; i++) {
            encoded += String.fromCharCode(input[i].charCodeAt(0) + 1);
        }

        textareas[1].value = encoded;
        textareas[0].value = '';
    }

    function decode() {
        const received = textareas[1].value;
        let decoded = '';

        for (let i = 0; i < received.length; i++) {
            decoded += String.fromCharCode(received[i].charCodeAt(0) - 1);
        }

        textareas[1].value = decoded;
    }
}