const PATH = require('path');
var webpack = require('webpack');

module.exports = {
    entry: [
        'script-loader!jquery/dist/jquery.min.js', 'script-loader!bootstrap/dist/js/bootstrap.min.js', './public/scripts/index.js'
    ],
    externals: {
        jquery: 'jQuery'
    },
    plugins: [new webpack.ProvidePlugin({'$': 'jquery', 'jQuery': 'jquery'})],
    output: {
        path: __dirname,
        filename: 'public/scripts/bundle.js'
    },
    resolve: {
        modules: [
            __dirname, 'node_modules'
        ],
        extensions: ['.js']
    },
    module: {
        loaders: [
            {
                loader: 'babel-loader',
                query: {
                    presets: ['env', 'stage-0']
                },
                test: /\.js?$/,
                exclude: /(node_modules|bower_components)/
            }, {
                test: /\.css$/,
                use: ['style-loader', 'css-loader']
            }, {
                test: /\.(woff|woff2|eot|ttf|svg)$/,
                loader: 'url-loader?limit=100000'
            }, {
                test: /\.(jpg|png)$/,
                loader: 'file-loader',
                options: {
                    name: '[path][name].[hash].[ext]'
                },
                exclude: /(node_modules|bower_components)/
            }
        ]
    }
};