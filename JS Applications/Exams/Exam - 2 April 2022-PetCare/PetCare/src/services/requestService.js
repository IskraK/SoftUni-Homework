import * as request from '../api/requester.js';
import * as userService from '../services/userService.js';


const baseUrl = 'http://localhost:3030';
const url = `${baseUrl}/users`;

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

export async function getAll() {
    return request.get(`${baseUrl}/data/pets?sortBy=_createdOn%20desc&distinct=name`);
}

export async function create(data) {
    return request.post(`${baseUrl}/data/pets`, data);
}

export async function getById(id) {
    return request.get(`${baseUrl}/data/pets/${id}`);
}

export async function update(id, data) {
    return request.put(`${baseUrl}/data/pets/${id}`, data);
}

export async function deleteById(id) {
    return request.del(`${baseUrl}/data/pets/${id}`);
}

export async function addDonation(petId) {
    return request.post(`${baseUrl}/data/donation`, { petId });
}

export async function getDonations(petId) {
    return request.get(`${baseUrl}/data/donation?where=petId%3D%22${petId}%22&distinct=_ownerId&count`);
}

export async function getDonationByUser(petId, userId) {
    return request.get(`${baseUrl}/data/donation?where=petId%3D%22${petId}%22%20and%20_ownerId%3D%22${userId}%22&count`);
}