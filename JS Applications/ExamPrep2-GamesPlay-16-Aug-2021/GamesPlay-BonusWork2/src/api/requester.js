import * as userService from '../services/userService.js';

// export const request = async (method, url, data) => {
//     const options = {
//         method,
//         headers: {}
//     };

//     const token = userService.getAccessToken();

//     if (token) {
//         options.headers['X-Authorization'] = token;
//     }

//     if (data) {
//         options.headers['Content-Type'] = 'application/json';

//         if (method != 'GET') {
//             options.body = JSON.stringify(data);
//         }
//     }

//     const response = await fetch(url, options);
//     return await response.json();
// }



async function request(method, url, data) {
    const options = {
        method,
        headers: {}
    };

    if (data !== undefined) {
        options.headers['Content-Type'] = 'application/json';
        options.body = JSON.stringify(data);
    }

    const user = JSON.parse(localStorage.getItem('user'));
    if (user) {
        options.headers['X-Authorization'] = user.accessToken;
    }

    try {
        const response = await fetch(url, options);

        if (response.ok == false) {

            //if token is invalid
            if(response.status == 403){
                localStorage.removeItem('user');
            };

            const error = await response.json();
            throw Error(error.message);
        }

        //if response is empty
        if (response.status == 204) {
            return response;
        } else {
            return response.json();
        }

    } catch (err) {
        alert(err.message);
        throw err;
    }
}


export const get = request.bind(null, 'GET');
export const post = request.bind(null, 'POST');
export const put = request.bind(null, 'PUT');
export const patch = request.bind(null, 'PATCH');
export const del = request.bind(null, 'DELETE');