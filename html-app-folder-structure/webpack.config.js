var HtmlWebpackPlugin = require('html-webpack-plugin');
var HtmlWebpackPluginConfig = new HtmlWebpackPlugin({
    template: 'app/index.html',
    filename: 'index.html',
    inject: 'body'
});

module.exports = {
    entry: './app/index.js',
    output: {
        filename : 'bundle.js',
        path: 'dist/'
    },
    module: {
        loaders: [
            { test: /\.js$/, exclude: /node_modules/, loader: "babel-loader" }
        ]
    },
    plugins : [HtmlWebpackPluginConfig]
};