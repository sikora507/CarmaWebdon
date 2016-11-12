import React, { Component, PropTypes } from 'react';
import 'whatwg-fetch';
import NavLi from './Navigation/NavLi';
import Loader from './SimpleComponents/Loader';

class PaletteChooser extends Component {
  constructor() {
    super();
    this.state = {
      navs: [],
      isLoading: true
    }
  }
  componentDidMount() {
    fetch('/api/pix/GetPalettes')
      .then((response) => response.json())
      .then((responseData) => {
        this.setState({
          navs: responseData.palettes,
          isLoading: false
        });
      })
      .catch((error) => {
        console.log('Error fetching settings', error);
      });
  }

  render() {
    if (this.state.isLoading) {
      return <Loader />
    }
    var newNavs = this.state.navs.map(function (item, index) {
      return (
        <NavLi key={index}
          to={'/pix/' + this.props.params.pixDirId + '/palette/' + index}>{item}</NavLi>
      )
    }.bind(this))
    return (
      <div>
        <ul className="nav nav-pills">
          {newNavs}
        </ul>
        <div>
          {this.props.children}
        </div>
      </div>
    )
  }
}

PaletteChooser.PropTypes = {
  setPalette: PropTypes.func.isRequired
}
export default PaletteChooser;