export function validateYear(ev) {
    return ev.path.some(y => y.id === 'years' && y.tagName == 'SECTION') &&
        (ev.target.className == 'date' || ev.target.className == 'day');
}

export function validateMonth(ev) {
    return ev.path.some(m => m.className == 'monthCalendar' && m.tagName == 'SECTION');
}