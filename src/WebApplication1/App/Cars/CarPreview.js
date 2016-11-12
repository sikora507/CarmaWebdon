import React, { Component } from 'react';
import 'whatwg-fetch';
import Loader from '../SimpleComponents/Loader';

class CarPreview extends Component {
  constructor() {
    super();
    this.state = {
      isLoading: true,
      selectedCarActors: {}
    }
  }
  componentDidMount() {
    this.getCarData(this.props.params.carId);
  }
  componentWillReceiveProps(nextProps) {
    this.getCarData(nextProps.params.carId);
  }
  getCarData(carId) {
    var oldState = this.state;
    var newState = Object.assign({}, oldState, {
      isLoading: true
    });
    this.setState(newState);
    fetch(`/api/cars/GetCar?carId=${carId}`)
      .then((response) => response.json())
      .then((responseData) => {
        newState = Object.assign({}, newState, {
          isLoading: false,
          selectedCarActors: responseData
        });
        this.setState(newState);
      })
      .catch((error) => {
        console.log('Error fetching settings', error);
        this.setState(oldState);
      });
  }
  render() {
    if (this.state.isLoading) {
      return (<Loader />);
    }
    let actors = this.state.selectedCarActors.map(function (item, index) {
      return (
        <tr key={index}>
          <td>{item.name}</td>
          <td>{item.modelName}</td>
          <td>{item.materialName}</td>
        </tr>
      );
    });
    return (
      <div>
        <h2>Car .act file root</h2>
        <table className="table">
          <thead>
            <tr>
              <th>Name</th>
              <th>Model name</th>
              <th>Material name</th>
            </tr>
          </thead>
          <tbody>
            {actors}
          </tbody>
        </table>
      </div>
    );
  }
}

export default CarPreview;