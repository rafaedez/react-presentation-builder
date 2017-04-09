import { fetchApi } from 'services/api';

const endPoints = {
	create: '/presentations',
	get: '/presentations',
};

export const create = payload => fetchApi(endPoints.create, payload, 'post');

export const get = payload => fetchApi(endPoints.get, payload, 'get');