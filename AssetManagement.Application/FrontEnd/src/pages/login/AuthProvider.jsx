import simpleRestProvider from 'ra-data-simple-rest';
import { fetchUtils, Admin, Resource } from 'react-admin';

// Customize Request header
const httpClient = (url, options = {}) => {
    if (!options.headers) {
        options.headers = new Headers({ Accept: 'application/json' });
    }
    const { token } = JSON.parse(localStorage.getItem('auth'));
    options.headers.set('Authorization', `Bearer ${token}`);
    return fetchUtils.fetchJson(url, options);
};

const authURL = 'https://localhost:7173'

// Setup AuthProvider
function AuthProvider(authURL){
    const dataPorvider = simpleRestProvider(authURL, httpClient);
    
    return ({
        ...dataPorvider,
        // send username and password to the auth server and get back credentials
        login: ({ username, password }) =>  {
            const request = new Request(`${authURL}/Auth/Login_`, {
                method: 'POST',
                body: JSON.stringify({ userName:username, password:password }),
                headers: new Headers({ 'Content-Type': 'application/json' }),
            });
            return fetch(request)
                .then(response => {
                    if (response.status < 200 || response.status >= 300) {
                        throw new Error(response.statusText);
                    }
                    return response.json()
                })
                .then(auth => {
                    localStorage.setItem('auth', JSON.stringify(auth.value));
                })
                .catch(() => {
                    throw new Error('Network error')
                });
        },

        // when the dataProvider returns an error, check if this is an authentication error
        checkError: (error) => {
            const status = error.status;
            if (status === 401 || status === 403) {
                localStorage.removeItem('auth');
                return Promise.reject();
            }
            // other error code (404, 500, etc): no need to log out
            return Promise.resolve();
        },

        // when the user navigates, make sure that their credentials are still valid
        checkAuth: () => localStorage.getItem('auth')
        ? Promise.resolve()
        // react-admin passes the error message to the translation layer
        : Promise.reject({ message: 'login.required' }), 

        // remove local credentials and notify the auth server that the user logged out
        logout: () => {
            localStorage.removeItem('auth');
            return Promise.resolve('/Login');
        },

        // get the user's profile
        getIdentity: () => {
            try {
                const { id, fullName, avatar } = JSON.parse(localStorage.getItem('auth'));
                return Promise.resolve({ id, fullName, avatar });
            } catch (error) {
                return Promise.reject(error);
            }
        },

        // get the user permissions (optional)
        getPermissions: () => Promise.resolve(),
    })
};

export default AuthProvider