import React, { Component } from 'react';
import ReactDOM from 'react-dom';
import BgrImage from '../SimpleComponents/BgrImage';

class PixPreview extends Component {
  constructor(props) {
    super(props);
    this.state = {
      selectedPix: {},
      selectedImageIndex: 0,
      maxImageIndex: 0,
      selectedImage: null
    }
  }
  componentDidMount() {
    this.setStateFromProps(this.props.selectedPix);
    $(ReactDOM.findDOMNode(this)).modal('show');
    //$(ReactDOM.findDOMNode(this)).on('hidden.bs.modal', this.props.handleHideModal);
  }
  componentWillReceiveProps(newProps) {
    this.setStateFromProps(newProps.selectedPix);
    $(ReactDOM.findDOMNode(this)).modal('show');
  }
  setStateFromProps(selectedPix) {
    this.setState({
      selectedPix: selectedPix,
      selectedImageIndex: 0,
      maxImageIndex: selectedPix.images.length - 1,
      selectedImage: selectedPix.images[0]
    })
  }
  incrementImage() {
    if (this.state.selectedImageIndex < this.state.maxImageIndex) {
      this.setState(Object.assign({}, this.state,
        {
          selectedImageIndex: this.state.selectedImageIndex + 1,
          selectedImage: this.state.selectedPix.images[this.state.selectedImageIndex + 1]
        }));
    }
  }
  decrementImage() {
    if (this.state.selectedImageIndex > 0) {
      this.setState(Object.assign({}, this.state,
        {
          selectedImageIndex: this.state.selectedImageIndex - 1,
          selectedImage: this.state.selectedPix.images[this.state.selectedImageIndex - 1]
        }));
    }
  }
  render() {
    var bgrImage = this.state.selectedImage 
      ? <BgrImage width={this.state.selectedImage.width} height={this.state.selectedImage.height} encodedData={this.state.selectedImage.bgrData} />
      : '';
    return (
      <div className="modal fade">
        <div className="modal-dialog">
          <div className="modal-content">
            <div className="modal-header">
              <button type="button" className="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
              <h4 className="modal-title">{this.state.selectedPix.name}</h4>
            </div>
            <div className="modal-body" style={{height: 300}}>
              {bgrImage}
            </div>
            <div className="modal-footer">
              <div className="row">
                <div className="col-lg-5" style={{ fontSize: '30px' }}>
                  <div className="label label-info pull-left">Image {this.state.selectedImageIndex + 1} of {this.state.maxImageIndex + 1}</div>
                </div>
                <div className="col-lg-7">
                  <button className="btn btn-default glyphicon glyphicon-chevron-left" onClick={this.decrementImage.bind(this)} />
                  <button className="btn btn-default glyphicon glyphicon-chevron-right" onClick={this.incrementImage.bind(this)} />
                  <button type="button" className="btn btn-default" data-dismiss="modal">Close</button>
                </div>
              </div>
            </div>
          </div>
        </div>
      </div >
    );
  }
}

export default PixPreview;