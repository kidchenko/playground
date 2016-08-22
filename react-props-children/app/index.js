var React = require('react');
var ReactDOM = require('react-dom');

var someStyle = {
  color: 'red',
};

var Clock = React.createClass({
    render: function() {
        return (
            <p style={someStyle}>{this.props.children}</p>
        )
    }
});

ReactDOM.render(
    <Clock>20:48</Clock>,
    document.getElementById('clock')
);