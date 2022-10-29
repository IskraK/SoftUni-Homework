import * as request from '../api/requester.js';
import * as userService from '../services/userService.js';


const baseUrl = 'http://localhost:3030';
const url = `${baseUrl}/users`;

export async function getRecent() {
    return request.get(`${baseUrl}/data/games?sortBy=_createdOn%20desc&distinct=category`);
}

export async function getAll() {
    return request.get(`${baseUrl}/data/games?sortBy=_createdOn%20desc`);
}

export async function login(email, password) {
    const result = await request.post(`${url}/login`, { email, password });
    userService.saveUser(result);

    return result;
}

export async function register(email, password) {
    const result = await request.post(`${url}/register`, { email, password });
    userService.saveUser(result);

    return result;
}

export async function logout() {
    request.get(`${url}/logout`);
    userService.removeUser();
}

export async function create(data) {
    return request.post(`${baseUrl}/data/games`, data);
}

export async function getById(id) {
    return request.get(`${baseUrl}/data/games/${id}`);
}

export async function update(id, data) {
    return request.put(`${baseUrl}/data/games/${id}`, data);
}

export async function deleteById(id) {
    return request.del(`${baseUrl}/data/games/${id}`);
}

export async function getCommentsForGame(gameId) {
    request.get(`${baseUrl}/data/comments?where=gameId%3D%22${gameId}%22`);
}

export async function addNewComment(gameId, comment) {
    request.post(`${baseUrl}/data/comments`, { gameId, comment });
}

// export const getRecent = () => request.get(`${baseUrl}/data/games?sortBy=_createdOn%20desc&distinct=category`);

// export const getAll = () => request.get(`${baseUrl}/data/games?sortBy=_createdOn%20desc`);

// export const login = (email, password) =>
//     request.post(`${url}/login`, { email, password })
//         .then(user => userService.saveUser(user));

// export const register = (email, password) =>
//     request.post(`${url}/register`, { email, password })
//         .then(user => userService.saveUser(user));

// export const logout = () =>
//     request.get(`${url}/logout`)
//         .then(() => userService.removeUser());

// export const getCommentsForGame = (gameId) =>
//     request.get(`${baseUrl}/data/comments?where=gameId%3D%22${gameId}%22`);

// export const addNewComment = (gameId, comment) =>
//     request.post(`${baseUrl}/data/comments`, { gameId, comment });