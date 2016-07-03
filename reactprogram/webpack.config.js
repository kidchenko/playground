var HtmlWebpackPlugin = require('html-webpack-plugin');
var HtmlWebpackPluginConfig = new HtmlWebpackPlugin({
    template: __dirname + '/app/index.html',
    filename: 'index.html',
    inject: 'body'
});

console.log(__dirname)
module.exports = {
    entry : './app/index.js',
    output: {
        path : __dirname + '/dist',
        filename : 'bundle.js'
    },
    module : {
        loaders: [
            { test : /\.css$/, exclude: /node_modules/, loader : 'style!css' },
            { test : /\.js$/, exclude: /node_modules/, loader : 'babel-loader' },
        ]
    },
    plugins: [HtmlWebpackPluginConfig]
};