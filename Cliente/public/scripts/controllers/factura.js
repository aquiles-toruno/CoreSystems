import APP from '../app';
import '../services/apifactory';

export default APP.controller('facturaCtrl', [
    "$scope",
    "factura",
    "apifactory",
    function (scope, factura, api) {
        scope.factura = factura.data;
    }
]);