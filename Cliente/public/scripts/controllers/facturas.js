import APP from '../app';
import '../services/apifactory';

export default APP.controller('facturasCtrl', [
    "$scope",
    "facturas",
    "apifactory",
    "$rootScope",
    function (scope, facturas, api, rootScope) {
        scope.facturas = facturas.data;
        scope.getFacturas = function () {
            rootScope.$broadcast('loading', {loading: true});
            api
                .getFacturas()
                .then(response => {
                    scope.facturas = response.data;
                    rootScope.$broadcast('loading', {loading: false});
                }, err => {
                    console.error(err);
                });
        };
    }
]);