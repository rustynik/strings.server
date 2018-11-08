import React, { Component } from 'react';

export class FetchData extends Component {
  displayName = FetchData.name

  constructor(props) {
    super(props);
    this.state = { items: [], loading: true };
    this.fetchData();
  }
    handleClick() {
        this.fetchData();
    }
  fetchData() {
        fetch('api/Messages/index')
            .then(response => response.json())
            .then(data => {
                this.setState({ items: data.items, loading: false });
            });
  }

  static renderForecastsTable(forecasts) {
    return (
      <table className='table'>
        <thead>
          <tr>
            <th>Date</th>
            <th>Temp. (C)</th>
            
          </tr>
        </thead>
        <tbody>
          {forecasts.map(forecast =>
            <tr key={forecast.id}>
              <td>{forecast.message}</td>
              <td>{forecast.ip}</td>
             
            </tr>
          )}
        </tbody>
      </table>
    );
  }

  render() {
    let contents = this.state.loading
      ? <p><em>Loading...</em></p>
      : FetchData.renderForecastsTable(this.state.items);
      let button = !this.state.loading ? <button onClick={this.handleClick.bind(this)}>Update</button> : null;

    return (
      <div>
            <h1>Weather forecast</h1>
            {button}
        <p>This component demonstrates fetching data from the server.</p>
        {contents}
      </div>
    );
  }
}
