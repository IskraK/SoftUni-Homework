import { render, TemplateResult } from '../../node_modules/lit-html/lit-html.js';
import { navigationView } from '../views/navigationView.js';

const headerElement = document.querySelector('.header-navigation');
const contentElement = document.querySelector('#main-content');
const ctxRender = (TemplateResult) => {
    render(TemplateResult, contentElement);
}


export const renderNavigation = (ctx, next) => {
    render(navigationView(ctx), headerElement);

    next();
};

export const renderContent = (ctx, next) => {
    ctx.render = ctxRender;

    next();
};