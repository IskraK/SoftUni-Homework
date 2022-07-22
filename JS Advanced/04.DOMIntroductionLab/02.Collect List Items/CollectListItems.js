function extractText() {
    let liElements = document.getElementsByTagName('li');
    let elementText = [...liElements].map(e => e.textContent);
    let textArea = document.getElementById('result');
    textArea.value = elementText.join('\n');
}