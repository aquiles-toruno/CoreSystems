import APP from '../app.js';

export default APP.factory('apifactory', function ($http) {
    const URL_API = 'http://localhost:59712/api/'
    var self = {};

    self.getFacturas = function () {
        return $http.get(`${URL_API}factura`);
    }

    self.getFactura = function (facturaId) {
        return $http.get(`${URL_API}factura/${facturaId}`);
    }

    return self;
});