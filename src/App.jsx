import React, { Component } from 'react';
import 'font-awesome/css/font-awesome.css';
import 'normalize.css/normalize.css';

import './styles.scss';
import NewPresentation from './scenes/presentation/new-presentation';

class App extends Component {
	render() {
		return (
			<NewPresentation />
		);
	}
}

export default App;
