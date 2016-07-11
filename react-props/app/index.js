var React = require('react');
var ReactDOM = require('react-dom');


var Hi = React.createClass({
    render : function() {
        return (
            <div>Hi {this.props.name}.</div>
        );
    }
});
ReactDOM.render(
    <Hi name="kidchenko"/>, 
    document.getElementById('app')
);