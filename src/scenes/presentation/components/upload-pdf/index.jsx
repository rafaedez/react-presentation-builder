import React from 'react';
import CSSModules from 'react-css-modules';

import styles from './styles.scss';
import Dropzone from 'react-dropzone';
import Button from 'components/Button'

const UploadPDF = ({ onDrop }) => (
	<div styleName="UploadPDF">
		<Dropzone accept='application/pdf' multiple={false} className='dropzone' onDrop={onDrop}>
             <Button className="button">Upload your PDF</Button>
			 <div>... or just drag your pdf her</div>
        </Dropzone>
	</div>
);

export default CSSModules(UploadPDF, styles);