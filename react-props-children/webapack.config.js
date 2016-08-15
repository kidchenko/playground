module.exports = {
    entry: './app/index.js',
    output: {
        filename: 'bundle.js',
        path: './dist/'
    },
    module: {
        loaaders: [
            { test: /\.js$/, exclude: 'node_modules', loader: 'babel-loader' }
        ]
    }
}