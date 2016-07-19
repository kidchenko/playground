var React = require('react');
var ReactDOM = require('react-dom');

var ShowList = React.createClass({
    render: function() {
        var listItems = this.props.friends.map(function(friend) {
            return <li> {friend} </li>
        });
        return (
            <div>
                <h3>Friends</h3>
                <ul>
                    {listItems}
                </ul>
            </div>
        );
    }
});

var FriendsContainer = React.createClass({
    render : function() {
        var name = 'kidchenko';
        var friendList = ['japa', 'react', 'baltieri']
        return (
            <div>
                Hi {name}.
                <ShowList friends={friendList} />
            </div>
        );
    }
});


ReactDOM.render(
    <FriendsContainer />,
    document.getElementById('app')
);