var React = require('react');
var ReactDOM = require('react-dom');

var ProfilePic = function(props) {
    return <img src={'https://twitter.com/' + this.props.username + '/profile_image?size=original'}></img>
}

// var ProfilePic = React.createClass({
//     render: function() {
//         return (
//             <img src={'https://twitter.com/' + this.props.username + '/profile_image?size=original'}></img>
//         );
//     }
// });


var ProfileLink = function(props) {
    return (
        <a href={'https://www.twitter.com/' + this.props.username}>
        {this.props.username}
        </a>
    );
}

// var ProfileLink = React.createClass({
//     render: function() {
//         return (
//             <a href={'https://www.twitter.com/' + this.props.username}>
//             {this.props.username}
//             </a>
//         );
//     }
// });

var Avatar = function(props) {
    return (
        <a href={'https://www.twitter.com/' + this.props.username}>
        {this.props.username}
        </a>
    );
}

// var Avatar = React.createClass({
//     render: function() {
//         return (
//             <div>
//                 <ProfilePic username={this.props.username} />
//                 <ProfileLink username={this.props.username} />
//             </div>
//         );
//     }
// });

ReactDOM.render(<Avatar username="kidchenko" />, document.getElementById('avatar'));