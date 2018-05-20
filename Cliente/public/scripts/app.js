import angular from 'angular';
import ngRoute from 'angular-route';

const APP = angular.module('CoreApp', [ngRoute]);

APP.config(($routeProvider) => {
    $routeProvider.when('/', {
        templateUrl: 'views/facturas.html',
        controller: 'facturasCtrl',
        resolve: {
            facturas: function (apifactory) {
                return apifactory.getFacturas();
            }
        }
    }).when('/factura/:id', {
        templateUrl: 'views/factura.html',
        controller: 'facturaCtrl',
        resolve: {
            factura: function (apifactory, $route) {
                return apifactory.getFactura($route.current.params.id);
            }
        }
    }).otherwise({redirectTo: '/'});
});

APP.run(function ($rootScope) {
    $rootScope
        .$on('$routeChangeStart', function () {
            $rootScope.$broadcast('loading', {loading: true});
        });

    $rootScope.$on('$routeChangeSuccess', function () {
        $rootScope.$broadcast('loading', {loading: false});
    });
});

export default APP;