var express = require('express');
var server = require('http').createServer(app);

var app = express();

app.use(express.static(__dirname + '/public'));

app.listen(59713, function () {
    console.log('Express server está corriendo en el puerto ' + 59713);
    console.log('Abrir app -> http://localhost:59713/');
});