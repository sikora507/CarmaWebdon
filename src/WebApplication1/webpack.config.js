var path = require('path');

module.exports = {
    entry: __dirname + '/App/main.js',
    devtool: 'eval-source-map',
    output: {
        path: __dirname + '/wwwroot/Built',
        filename: 'main.bundle.js'
    },
    module: {
        loaders: [{
            test: /\.jsx?$/,
            exclude: /node_modules/,
            loader: 'babel',
            query: {
                presets: ['es2015', 'react']
            }
        }]
    }
};