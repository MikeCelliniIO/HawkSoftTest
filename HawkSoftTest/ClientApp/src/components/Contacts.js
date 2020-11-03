import React, { Component } from 'react';
import { AddContact } from './AddContact';

export class Contacts extends Component {
  static displayName = Contacts.name;

  constructor(props) {
    super(props);
      this.state = { contacts: [], loading: true, filter: "" };
      this.timer = null;
      this.handleDelete = this.handleDelete.bind(this);
  }

  componentDidMount() {
      this.populateContacts();
    }

    componentDidUpdate(prevProps, prevState) {
        if (prevState.filter !== this.state.filter) {
            this.handleFilter();
        }
    }

    onChangeHandler(e) {
        this.setState({ filter: e.target.value });
    }

    handleDelete(e) {
        this.deleteContact(e.target.value);
    }

    //Want to filter when user inputs into filter textbox, but prevent a trip on keystroke...
    handleFilter = () => {
        clearTimeout(this.timer);
        this.timer = setTimeout(() => {
            if (this.state.filter != "")
                this.filterContacts(this.state.filter);
            else
                this.populateContacts();
        }, 1000);
    }

  render() {
    let contents = this.state.loading
      ? <p><em>Loading...</em></p>
        : this.state.contacts.map(contact => 
              <div className="row" key={contact.id}>
                  <div className="col-sm">
                      <h3>{contact.lastName}, {contact.firstName}</h3>
                      {contact.email}
                  </div>
                  <div className="col-sm">
                      <button className="btn btn-outline-primary btm-sm">Edit</button>
                      <button className="btn btn-outline-danger btm-sm" value={contact.id} onClick={this.handleDelete}>Delete</button>
                  </div>
              </div>
          )

      return (
          <div className="row">
              <div className="col-md">
                  <div className="row">
                      <div className="col-sm">
                          <input type="text" name="filter" placeholder="Filter here..." value={this.state.filter} onChange={this.onChangeHandler.bind(this)} />
                      </div>
                  </div>
                  {contents}
              </div>
              <div className="col-md">
                  <AddContact postCallback={this.populateContacts.bind(this)} />
              </div>
       </div>
    );
    }

  async populateContacts() {
    const response = await fetch('contacts');
    const data = await response.json();
    this.setState({ contacts: data.data, loading: false, filter: "" });
    }

    async filterContacts(filter) {
        const response = await fetch('contacts/GetByFilter/' + filter);
        const data = await response.json();
        this.setState({ contacts: data.data, loading: false });
    }

    async deleteContact(id) {
        const settings = {
            method: 'DELETE',
            headers: {
                Accept: 'application/json',
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({ id: parseInt(id) })
        };
        try {
            const response = await fetch('contacts/', settings);
            await response.json();
            this.populateContacts();
        }
        catch (ex) {
            //Do something...
        }
    }

}
