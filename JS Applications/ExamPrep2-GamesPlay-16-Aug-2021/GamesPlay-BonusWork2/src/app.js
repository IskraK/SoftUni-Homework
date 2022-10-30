import page from '../node_modules/page/page.mjs';
import { addRender } from './middlewares/render.js';
import { addSession } from './middlewares/session.js';
import { logout } from './services/requestService.js';
import { catalogView } from './views/catalog.js';
import { createView } from './views/create.js';
import { detailsView } from './views/details.js';
import { editView } from './views/edit.js';
import { homeView } from './views/home.js';
import { loginView } from './views/login.js';
import { registerView } from './views/register.js';

import * as api from './services/requestService.js';
window.api = api;

page(addSession);
page(addRender);

page('/', homeView);
page('/catalog', catalogView);
page('/login', loginView);
page('/register', registerView);
page('/create', createView);
page('/details/:id', detailsView);
page('/edit/:id', editView);
page('/logout', onLogout)


page.start();

function onLogout() {
    logout();
    page.redirect('/');
}