import React, { Component } from 'react';
import 'whatwg-fetch';
import Loader from '../SimpleComponents/Loader';
import NavLi from '../Navigation/NavLi';

class CarsList extends Component {
  constructor() {
    super();
    this.state = {
      isLoading: true,
      cars: []
    }
  }
  componentDidMount() {
    fetch('/api/cars/GetCarsList')
      .then((response) => response.json())
      .then((responseData) => {
        this.setState({
          isLoading: false,
          cars: responseData
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
    var carsNavs = this.state.cars.map(function (item) {
      return <NavLi key={item.key} to={`/cars/${item.key}`}>{item.value}</NavLi>
    });
    return (
      <ul className="nav nav-pills nav-stacked">
        {carsNavs}
      </ul>
    );
  }
}

export default CarsList;