import React, { Component } from 'react';

export class AddContact extends Component {

    constructor(props) {
        super(props);
        this.state = { firstName: '', lastName: '', email: '', postCallback: props.postCallback };
    }

    componentDidMount() {

    }

    onChangeHandler = (e) => {
        this.setState({
            [e.target.name]: e.target.value
        });
    }

    render() {
        return (
            <div>
                <h4>New Contact</h4>
                <form onSubmit={this.postContact.bind(this)}>
                    <div className="form-group">
                        <label htmlFor="firstName">First Name</label>
                        <input type="text" className="form-control" name="firstName" value={this.state.firstName} onChange={this.onChangeHandler}></input>
                    </div>
                    <div className="form-group">
                        <label>Last Name</label>
                        <input type="text" className="form-control" name="lastName" value={this.state.lastName} onChange={this.onChangeHandler} />
                    </div>
                    <div className="form-group">
                        <label>Email</label>
                        <input type="email" className="form-control" name="email" value={this.state.email} onChange={this.onChangeHandler} />
                    </div>
                    <button type="submit" className="btn btn-primary">Save</button>
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
            body: JSON.stringify({ firstName: this.state.firstName, lastName: this.state.lastName, email: this.state.email })
        };
        try {
            const response = await fetch('contacts/add', settings);
            await response.json();
            this.setState({ firstName: '', lastName: '', email: '' });
            this.state.postCallback();
        }
        catch (ex) {
            //Do something...
        }
    }

}
