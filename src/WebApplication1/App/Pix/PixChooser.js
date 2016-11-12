import React, { Component } from 'react';
import 'whatwg-fetch';
import NavLi from '../Navigation/NavLi';
import Loader from '../SimpleComponents/Loader';

class PixChooser extends Component {
  constructor() {
    super();
    this.state = {
      dirs: [],
      isLoading: true,
      palette: 0
    }
  }
  componentWillReceiveProps(nextProps){
    let palette = nextProps.params.paletteId || 0;
    this.setState(Object.assign({}, this.state, {palette: palette}));
  }
  componentDidMount() {
    let palette = this.props.params.paletteId || 0;
    this.getPixData(palette);
  }
  getPixData(palette){
    this.setState(Object.assign({}, this.state, {palette: palette}));
    fetch('/api/pix')
      .then((response) => response.json())
      .then((responseData) => {
        this.setState({
          dirs: responseData.pixFolders,
          isLoading: false,
          palette: palette
        });
      })
      .catch((error) => {
        console.log('Error fetching data', error);
      });
  }
  render() {
    if (this.state.isLoading) {
      return <Loader />
    }
    var dirNavs = this.state.dirs.map(function (item, index) {
      return <NavLi key={index} to={`/pix/${index}/palette/${this.state.palette}`} >{item.name}</NavLi>
    }.bind(this));

    return (
      <div>
        <ul className="nav nav-tabs">
          {dirNavs}
        </ul>
        <div>
          {this.props.children}
        </div>
      </div>
    );
  }
}

export default PixChooser;