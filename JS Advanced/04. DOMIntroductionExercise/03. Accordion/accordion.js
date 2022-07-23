function toggle() {
    let button = document.getElementsByClassName('button')[0];
    let content = document.getElementById('extra');
    if (button.textContent === 'More') {
        button.textContent = 'Less';
        content.style.display = 'block';
    } else {
        button.textContent = 'More';
        content.style.display = 'none';
    }
}

// //second decision
// function toggle() {
//     const button = document.querySelector('.button');
//     const hiddenText = document.getElementById('extra');

//     button.textContent = button.textContent == 'More' ? 'Less' : 'More';

//     hiddenText.style.display = hiddenText.style.display == 'none'
//         || hiddenText.style.display == ' '
//         ? hiddenText.style.display = 'block'
//         : hiddenText.style.display = 'none';
// }