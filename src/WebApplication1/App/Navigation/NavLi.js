import React, { Component } from 'react'
import { Link } from 'react-router';

class NavLi extends Component {
  render() {
    let isActive = this.context.router.isActive(this.props.to, false),
      className = isActive ? "active" : "";
    return (
      <li className={className}>
        <Link {...this.props}>
          {this.props.children}
        </Link>
      </li>
    );
  }
}

NavLi.contextTypes = {
    router: React.PropTypes.object.isRequired
};

export default NavLi;