module.exports = {
    context: __dirname + "/src",
    entry: "./entry",
    output: {
      path: __dirname,
      filename: "bundle.js"
    },
    module: {
      loaders: [{
        test: /\.js$/,
        loader: 'babel-loader',
        query: {
          presets: ['es2015']
        }
      },{
        test: /\.coffee$/,
        loader: 'coffee-loader'
      },{
        test: /\.ts$/,
        loader: 'ts-loader'
      }]
    }
  }