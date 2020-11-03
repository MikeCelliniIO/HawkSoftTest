import React, { Component } from 'react';

export class Contacts extends Component {
  static displayName = Contacts.name;

  constructor(props) {
    super(props);
    this.state = { contacts: [], loading: true, filter: "" };
  }

  componentDidMount() {
      this.populateContacts();
  }

  static renderContactCards(contacts) {
      return (
          contacts.map(contact => 
              <div className="row" key={contact.lastName + contact.firstName}>
                  <div className="col-sm">
                      <h3>{contact.lastName}, {contact.firstName}</h3>
                      {contact.email}
                  </div>
              </div>
          )
        );
    }

    onChangeHandler(e) {
        this.setState({ filter: e.target.value, loading: true });
        if (this.state.filter != "")
            this.filterContacts();
        else
            this.populateContacts();
    }

  render() {
    let contents = this.state.loading
      ? <p><em>Loading...</em></p>
        : Contacts.renderContactCards(this.state.contacts);

      return (
          <div>
              <div className="row">
                  <div className="col-sm">
                      <input type="text" name="filter" placeholder="Filter here..." value={this.state.filter} onChange={this.onChangeHandler.bind(this)} />
                  </div>
              </div>
              {contents}
       </div>
    );
  }

  async populateContacts() {
    const response = await fetch('contacts');
    const data = await response.json();
    this.setState({ contacts: data.data, loading: false });
    }

    async filterContacts() {
        const response = await fetch('contacts/GetByFilter/' + this.state.filter);
        const data = await response.json();
        this.setState({ contacts: data.data, loading: false });
    }
}
