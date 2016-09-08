var HtmlWebpackPlugin = require('html-webpack-plugin');
var HtmlWebpackPluginConfig = new HtmlWebpackPlugin({
    template: './app/index.html',
    filename: 'index.html',
    inject: 'body'
});

module.exports = {
    entry : './app/index.js',
    output:  {
        path: 'dist/',
        filename: 'bundle.js'
    },
    module : {
        loaders : [
            { test : /\.js$/, exclude : 'node_modules', loader: 'babel-loader' }
        ]
    },
    plugins: [HtmlWebpackPluginConfig]
}