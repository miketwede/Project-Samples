var http = require('http');

console.log("This script will create a local server on port 8080, listen for connections and display 'Hello World' when a connection happens.");
console.log("To connect, open a browser and enter 'localhost:8080' for the url, and hit enter.");

http.createServer(function (req, res) {
    res.writeHead(200, {'Content-Type': 'text/html'});
    res.end('Hello World!');
}).listen(8080);