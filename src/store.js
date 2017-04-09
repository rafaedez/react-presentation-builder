import { createStore, combineReducers, compose, applyMiddleware } from 'redux';
import thunk from 'redux-thunk';
import { reducer as dataReducer } from './data/reducer';
import { reducer as servicesReducer } from './services/reducer';

const appReducer = combineReducers({
	services: servicesReducer,
	data: dataReducer,
});

const enhancer = compose(
	applyMiddleware(
		thunk,
	)
);

const store = createStore(
	appReducer,
	enhancer
);

export default store;