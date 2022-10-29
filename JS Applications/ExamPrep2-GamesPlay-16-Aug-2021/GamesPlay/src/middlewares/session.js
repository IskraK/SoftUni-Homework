import { getUser } from "../services/userService.js";


export function addSession(ctx, next){
    ctx.user = getUser();
    next();
}