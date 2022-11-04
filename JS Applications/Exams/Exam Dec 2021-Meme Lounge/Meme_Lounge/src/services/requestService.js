import * as request from '../api/requester.js';
import * as userService from '../services/userService.js';


const baseUrl = 'http://localhost:3030';
const url = `${baseUrl}/users`;

export async function login(email, password) {
    const result = await request.post(`${url}/login`, { email, password });
    userService.saveUser(result);

    return result;
}

export async function register(username, email, password, gender) {
    const result = await request.post(`${url}/register`, { username, email, password, gender });
    userService.saveUser(result);

    return result;
}

export async function logout() {
    request.get(`${url}/logout`);
    userService.removeUser();
}

export async function getAll() {
    return request.get(`${baseUrl}/data/memes?sortBy=_createdOn%20desc`);
}

export async function create(data) {
    return request.post(`${baseUrl}/data/memes`, data);
}

export async function getById(id) {
    return request.get(`${baseUrl}/data/memes/${id}`);
}

export async function update(id, data) {
    return request.put(`${baseUrl}/data/memes/${id}`, data);
}

export async function deleteById(id) {
    return request.del(`${baseUrl}/data/memes/${id}`);
}

export async function getByUser(userId) {
    return request.get(`${baseUrl}/data/memes?where=_ownerId%3D%22${userId}%22&sortBy=_createdOn%20desc`);
}