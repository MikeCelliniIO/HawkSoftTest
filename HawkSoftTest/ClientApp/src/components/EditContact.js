import React, { Component } from 'react';

export class EditContact extends Component {

    constructor(props) {
        super(props);
        this.state = { contact: props.contact, firstName: props.contact.firstName, postCallback: props.postCallback, cancelCallback: props.cancelCallback };
    }

    componentDidMount() {

    }

    onChangeHandler = (e) => {
        const contact = this.state.contact;
        contact[e.target.name] = e.target.value;
        this.setState({ contact: contact });
    }

    render() {
        return (
            <div>
                <h4>Edit Contact</h4>
                <form onSubmit={this.postContact.bind(this)}>
                    <div className="form-group">
                        <label htmlFor="firstName">First Name</label>
                        <input type="text" className="form-control" name="firstName" value={this.state.contact.firstName} onChange={this.onChangeHandler}></input>
                    </div>
                    <div className="form-group">
                        <label>Last Name</label>
                        <input type="text" className="form-control" name="lastName" value={this.state.contact.lastName} onChange={this.onChangeHandler} />
                    </div>
                    <div className="form-group">
                        <label>Email</label>
                        <input type="email" className="form-control" name="email" value={this.state.contact.email} onChange={this.onChangeHandler} />
                    </div>
                    <button type="submit" className="btn btn-primary">Save</button>
                    <button type="button" className="btn btn-light" onClick={this.state.cancelCallback}>Cancel</button>
                </form>
            </div>
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
            body: JSON.stringify(this.state.contact)
        };
        try {
            const response = await fetch('contacts/edit', settings);
            await response.json();
            this.state.postCallback();
        }
        catch (ex) {
            //Do something...
        }
    }

}
