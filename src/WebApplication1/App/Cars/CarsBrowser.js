import React, { Component } from 'react';
import CarsList from './CarsList';

class CarsBrowser extends Component {
  render() {
    return (
      <div>
        <div className="row">
          <div className="col-lg-3">
            <CarsList/>
          </div>
          <div className="col-lg-9">
            {this.props.children}
          </div>
        </div>
      </div>
    );
  }
}

export default CarsBrowser;