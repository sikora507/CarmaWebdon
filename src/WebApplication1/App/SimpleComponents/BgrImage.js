import React, { Component } from 'react';

class BgrImage extends Component {
  constructor() {
    super();
    this.state = {
      width: 0,
      height: 0,
      bgrData: ''
    }
  }
  decodeData(width,  height, encodedData){
    const decodedData = atob(encodedData);
    //data comes with rgba 32 format
    var len = decodedData.length;
    let bgrData = new Uint8ClampedArray(len);
    for (var i = 0; i < len; i++) {
      bgrData[i] = decodedData.charCodeAt(i);
    }
    this.setState({
      width: width,
      height: height,
      bgrData: bgrData
    });
  }
  componentWillMount() {
    this.decodeData(this.props.width, this.props.height, this.props.encodedData);
  }
  componentWillReceiveProps(newProps){
    this.decodeData(newProps.width, newProps.height, newProps.encodedData);
  }
  componentDidMount() {
    this.refreshImage();
  }
  componentDidUpdate(){
    this.refreshImage();
  }
  refreshImage(){
    const ctx = this.refs.canvas.getContext('2d');
    const imageData = new ImageData(this.state.bgrData, this.state.width, this.state.height);
    ctx.putImageData(imageData, 0, 0);
  }
  render() {
    return (<canvas ref="canvas" width={this.state.width} height={this.state.height} />);
  }
}

export default BgrImage;