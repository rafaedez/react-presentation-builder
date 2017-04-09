import { Buffer } from 'buffer';
import { fetchApi } from 'services/api';
import apiConfig from 'services/api/config';

const endPoints = {
	authenticate: '/users/auth',
	revoke: '/users/auth/revoke',
	refresh: '/users/auth/refresh',
};

export const authenticate = (email, password) => fetchApi(endPoints.authenticate, {}, 'post', {
	Authorization: `Basic ${new Buffer(`${email}:${password}`).toString('base64')}`,
});

export const refresh = (token, user) => fetchApi(endPoints.refresh, { token, user }, 'post', {
	Authorization: null
});

export const revoke = tokens => fetchApi(endPoints.revoke, { tokens }, 'post');
