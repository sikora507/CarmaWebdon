import React, { Component } from 'react';
import NavLi from './Navigation/NavLi';
import UpperNavbarContainer from './Navigation/UpperNavbarContainer';

class App extends Component {
  render() {
    return (
      <div>
        <UpperNavbarContainer />
        <div className="row">
          <div className="col-sm-3">
            <ul className="nav nav-pills nav-stacked">
              <NavLi to="/pix">Pix</NavLi>
              <NavLi to="/cars">Cars</NavLi>
              <NavLi to="/maps">Maps</NavLi>
            </ul>
          </div>
          <div className="col-sm-9">
            {this.props.children}
          </div>
        </div>
      </div>
    );
  }
}

export default App;