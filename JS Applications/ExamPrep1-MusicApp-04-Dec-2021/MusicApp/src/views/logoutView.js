import * as requesterService from '../services/requestService.js';

export const logoutView = (ctx) => {
    requesterService.logout()
        .then(() => ctx.page.redirect('/'));
}