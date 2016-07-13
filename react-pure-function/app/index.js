var React = require('react');
var ReactDOM = require('react-dom');

var ProfilePic = React.createClass({
    render: function() {
        return (
            <img src={'https://photo.fb.com/' + this.props.username}></img>
        );
    }
});

var ProfileLink = React.createClass({
    render: function() {
        return (
            <a href={'https://www.fb.com/' + this.props.username}>
            {this.props.username}
            </a>
        );
    }
});

var Avatar = React.createClass({
    render: function() {
        return (
            <div>
                <ProfilePic username={this.props.username} />
                <ProfileLink username={this.props.username} />
            </div>
        );
    }
});

ReactDOM.render(<Avatar username="kidchenko" />, document.getElementById('avatar'));