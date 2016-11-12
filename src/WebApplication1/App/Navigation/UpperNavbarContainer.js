import React, { Component } from 'react';
import UpperNavbar from './UpperNavbar';
import 'whatwg-fetch';

class UpperNavbarContainer extends Component {
  constructor() {
    super();
    this.state = {
      gameDir: '',
      isLoading: true
    }
  }

  componentDidMount() {
    fetch('/api/data')
      .then((response) => response.json())
      .then((responseData) => {
        this.setState({
          gameDir: responseData.gameDir,
          isLoading: false
        });
      })
      .catch((error) => {
        console.log('Error fetching settings', error);
      });
  }

  render() {
    return (
      <UpperNavbar isLoading={this.state.isLoading} gameDir={this.state.gameDir} />
    );
  }
}

export default UpperNavbarContainer;