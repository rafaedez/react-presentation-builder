import React, { Component } from 'react';
import CSSModules from 'react-css-modules';

import styles from './styles.scss';
import UploadPDF from '../components/upload-pdf';

const initialState = {
	pdfloaded: false,
	images: []
};

class NewPresentation extends Component {

    constructor(props) {
        super(props);
        this.state = initialState;
        this.onDropPDF = this.onDropPDF.bind(this);
    }

    onDropPDF(acceptedFiles, rejectedFiles) {
      console.log('Accepted files: ', acceptedFiles);
      console.log('Rejected files: ', rejectedFiles);
    }

	reset() {
		this.setState(initialState);
	}

	render() {
		return (
			<div styleName="NewPresentation">
				<h1>
					Create your great presentation
				</h1>

				<div className="uploadpdf">
					<UploadPDF onDrop={(acceptedFiles, rejectedFiles)=>this.onDropPDF(acceptedFiles, rejectedFiles)}
					/>
				</div>

			</div>
		);
	}
}

export default CSSModules(NewPresentation, styles);
