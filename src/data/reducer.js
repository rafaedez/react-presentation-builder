import { combineReducers } from 'redux';
import { reducer as presentationsReducer } from './presentations/reducer';

export const reducer = combineReducers({
	presentations: presentationsReducer,
});