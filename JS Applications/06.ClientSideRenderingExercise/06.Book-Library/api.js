const url = 'http://localhost:3030/jsonstore/collections/books/';

export async function getAllBooks() {
    try {
        const response = await fetch(url);
        validateResponse(response);

        const data = await response.json();
        return data;
    } catch (error) {
        console.log(error);
    }
}

export const getBookById = async (id) => await fetch(url + id);

export const createBook = async (data) => await fetch(url, {
    method: 'POST',
    headers: {
        'Content-Type': 'application/json'
    },
    body: JSON.stringify(data)
});

export const editBook = async (id, data) => await fetch(url + id, {
    method: 'PUT',
    headers: {
        'Content-Type': 'application/json'
    },
    body: JSON.stringify(data)
});

export const deleteBook = async (id) => await fetch(url + id, {
    method: 'DELETE'
});

function validateResponse(res) {
    if (!res.ok) {
        throw new Error(res.statusText);
    }
}