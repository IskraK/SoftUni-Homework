import page from '../node_modules/page/page.mjs';
import { addSession } from './middlewares/session.js';
import { addRender } from './middlewares/render.js';
import { homeView } from './views/home.js';
import { dashboardView } from './views/dashboard.js';
import { loginView } from './views/login.js';
import { registerView } from './views/register.js';
import { logout } from './services/requestService.js';
import { createView } from './views/create.js';
import { detailsView } from './views/details.js';
import { editView } from './views/edit.js';

page(addSession);
page(addRender);

page('/', homeView);
page('/dashboard', dashboardView);
page('/login', loginView);
page('/register', registerView);
page('/logout', onLogout);
page('/create', createView);
page('/details/:id', detailsView);
page('/edit/:id', editView);

page.start();

function onLogout() {
    logout();
    page.redirect('/');
}