function attachEventsListeners() {
    [...document.querySelectorAll('input[type="button"]')].forEach(i => i.addEventListener('click', onConvert));

    let days = document.getElementById('days');
    let hours = document.getElementById('hours');
    let minutes = document.getElementById('minutes');
    let seconds = document.getElementById('seconds');

    function onConvert(ev) {
        switch (ev.target.id) {
            case 'daysBtn':
                hours.value = Number(days.value) * 24;
                minutes.value = Number(days.value) * 24 * 60;
                seconds.value = Number(days.value) * 24 * 60 * 60;
                break;
            case 'hoursBtn':
                days.value = Number(hours.value) / 24;
                minutes.value = Number(hours.value) * 60;
                seconds.value = Number(hours.value) * 60 * 60;
                break;
            case 'minutesBtn':
                days.value = Number(minutes.value) / 60 / 24;
                hours.value = Number(minutes.value) / 60;
                seconds.value = Number(minutes.value) * 60;
                break;
            case 'secondsBtn':
                days.value = Number(seconds.value) / 24 / 60 / 60;
                hours.value = Number(seconds.value) / 60 / 60;
                minutes.value = Number(seconds.value) / 60;
                break;
        }
    }
}