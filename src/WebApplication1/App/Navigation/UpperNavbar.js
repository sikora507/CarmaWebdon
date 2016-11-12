import React from 'react';

class UpperNavbar extends React.Component {
  render() {
    var gameDirInput = this.props.isLoading 
      ? <input type="text" readOnly className="form-control" value="Loading..." />
      : <input type="text" readOnly className="form-control" value={this.props.gameDir} />
    return (
      <nav className="navbar navbar-default">
        <div className="container-fluid">
          <div className="navbar-header">
            <a className="navbar-brand" href="/">CarmaWebdon</a>
          </div>
          <div className="collapse navbar-collapse" id="bs-example-navbar-collapse-1">
            <form className="navbar-form navbar-left">
              <div className="form-group">
                {gameDirInput}
              </div>
            </form>
          </div>
        </div>
      </nav>
    );
  }
}

export default UpperNavbar;