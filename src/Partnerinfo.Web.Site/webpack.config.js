﻿// Copyright (c) János Janka. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

const config = require("./comm.config");

const path = require("path");
const webpack = require("webpack");
const WebpackTextPlugin = require("extract-text-webpack-plugin");
const webpackExtractCss = new WebpackTextPlugin("[name].css");

module.exports = {
    output: {
        path: path.join(__dirname, config.dstRelativePath),
        filename: `[name].js`,
        publicPath: `/${config.dstFolderName}/`
    },
    entry: {
        main: [`./${config.srcFolderName}/main.ts`]
    },
    resolve: {
        extensions: ["", ".js", ".ts"]
    },
    module: {
        loaders: [
            { test: /\.ts$/, include: new RegExp(config.srcFolderName), loader: "ts", query: { silent: true } },
            { test: /\.html$/, loader: "raw" },
            { test: /\.less$/, loader: config.isDevBuild ? "style!css!less" : webpackExtractCss.extract(["css", "less"]) },
            { test: /\.css$/, loader: config.isDevBuild ? "style!css" : webpackExtractCss.extract(["css"]) },
            { test: /\.json$/, loader: "json-loader" },
            { test: /\.(png|jpg|jpeg|gif|svg)$/, loader: "url", query: { limit: 25000 } }
        ]
    },
    plugins: [
        new webpack.DllReferencePlugin({
            context: __dirname,
            manifest: require(`./${config.dstRelativePath}/corefx-manifest.json`)
        })
    ].concat(config.isDevBuild ? [
        // Plugins that apply in development builds only.
        new webpack.SourceMapDevToolPlugin({
            filename: "[file].map",
            moduleFilenameTemplate: path.relative(config.dstRelativePath, "[resourcePath]")
        })
    ] : [
        // Plugins that apply in production builds only.
        webpackExtractCss,
        new webpack.optimize.OccurenceOrderPlugin(),
        new webpack.optimize.UglifyJsPlugin({
            compress: { warnings: false },
            comments: false,
            minimize: true,
            mangle: true
        })
    ])
};