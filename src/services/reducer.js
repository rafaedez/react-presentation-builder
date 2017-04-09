import { combineReducers } from 'redux';
import { reducer as routeHistoryReducer } from './routeHistory/reducer';
import { reducer as sessionReducer } from './session/reducer';

export const reducer = combineReducers({
	routeHistory: routeHistoryReducer,
	session: sessionReducer
});
