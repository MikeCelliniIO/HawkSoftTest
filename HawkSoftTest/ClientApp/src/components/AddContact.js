import React, { Component } from 'react';

export class AddContact extends Component {

  constructor(props) {
    super(props);
      this.state = { firstName: '', lastName: '', email: '', postCallback: props.postCallback };
  }

  componentDidMount() {
      
  }

    onChangeHandler(e) {
        this.setState({
            [e.target.name]: e.target.value
        });
    }

  render() {
      return (
          <form onSubmit={this.postContact.bind(this)}>
              <div>
                  <div>
                      <label>First Name</label>
                      <input type="text" name="firstName" value={this.state.firstName} onChange={this.onChangeHandler.bind(this)} />
                  </div>
                  <div>
                      <label>Last Name</label>
                      <input type="text" name="lastName" value={this.state.lastName} onChange={this.onChangeHandler.bind(this)} />
                  </div>
                  <div>
                      <label>Email</label>
                      <input type="text" name="email" value={this.state.email} onChange={this.onChangeHandler.bind(this)} />
                  </div>
                  <div><button>Add</button></div>
              </div>
          </form>
    );
    }

    async postContact(e) {
        e.preventDefault();
        const settings = {
            method: 'POST',
            headers: {
                Accept: 'application/json',
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({ firstName: this.state.firstName, lastName: this.state.lastName, email: this.state.email })
        };
        try {
            const response = await fetch('contacts/', settings);
            this.setState({ firstName: '', lastName: '', email: '' });
            this.state.postCallback();
        }
        catch (ex) {

        }
    }

}
