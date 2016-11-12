import React, { Component } from 'react';
import 'whatwg-fetch';
import Loader from '../SimpleComponents/Loader';
import BgrImage from '../SimpleComponents/BgrImage';

class PixContentBrowser extends Component {
  constructor() {
    super();
    this.state = {
      pixDirId: 0,
      paletteId: 0,
      isLoading: true,
      dirName: '',
      files: []
    }
  }
  componentWillReceiveProps(nextProps) {
    let pixDirId = nextProps.params.pixDirId;
    let paletteId = nextProps.params.paletteId;
    if (pixDirId == this.props.params.pixDirId
      && paletteId == this.props.params.paletteId) {
      return
    } else {
      this.getPixData(pixDirId, paletteId);
    }
  }
  componentDidMount() {
    let pixDirId = this.props.params.pixDirId;
    let paletteId = this.props.params.paletteId;
    this.getPixData(pixDirId, paletteId);
  }

  getPixData(pixDirId, paletteId) {
    var oldState = this.state;
    var newState = Object.assign({}, oldState, {
      isLoading: true
    });
    this.setState(newState);
    fetch(`/api/pix/getPixData?pixDirId=${pixDirId}&paletteId=${paletteId}`)
      .then((response) => response.json())
      .then((responseData) => {
        newState = Object.assign({}, newState, {
          isLoading: false,
          dirName: responseData.dirName,
          files: responseData.files,
          pixDirId: pixDirId,
          paletteId: paletteId
        });
        this.setState(newState);
      })
      .catch((error) => {
        console.log('Error fetching settings', error);
        this.setState(oldState);
      });
  }
  handleRowClick(index, hasImages) {
    if (!hasImages) {
      return;
    }
    this.context.router.push(`/pix/${this.state.pixDirId}/palette/${this.state.paletteId}/preview/${index}`);
  }
  render() {
    if (this.state.isLoading) {
      return (<Loader />);
    }
    var header = `Pix content browser for dir ${this.state.pixDirId} and palette ${this.state.paletteId}.`;
    var rows = this.state.files.map(function (item, index) {
      var image = 'NO IMAGE INSIDE';
      var hasImages = !!item.images.length;
      if (hasImages) {
        image = <BgrImage width={item.images[0].width} height={item.images[0].height} encodedData={item.images[0].bgrData} />
      }
      return (
        <tr key={index} className={hasImages ? 'pointer' : ''} onClick={this.handleRowClick.bind(this, index, hasImages)}>
          <td>
            {image}
          </td>
          <td>{item.name}</td>
          <td>{item.images.length}</td>
        </tr>
      );
    }.bind(this));
    let children = this.props.children && React.cloneElement(this.props.children, {
      selectedPix: this.props.params.pixIndex 
        ? this.state.files[this.props.params.pixIndex] 
        : this.state.files[0] 
    });
    return (
      <div>
        <table className="table table-striped table-hover">
          <thead>
            <tr>
              <th>Preview</th>
              <th>File name</th>
              <th>Images inside</th>
            </tr>
          </thead>
          <tbody>
            {rows}
          </tbody>
        </table>
        {children}
      </div>
    );
  }
}

PixContentBrowser.contextTypes = {
  router: React.PropTypes.object.isRequired
};

export default PixContentBrowser;