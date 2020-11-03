import React, { Component } from 'react';

export class Home extends Component {
  static displayName = Home.name;

  render () {
    return (
      <div>
        <h1>Welcome!</h1>
            <p>This is an app for managing your contacts.</p>
            <p>If you have not already, please publish the database and update the connection string in the AppSettings.</p>
      </div>
    );
  }
}
