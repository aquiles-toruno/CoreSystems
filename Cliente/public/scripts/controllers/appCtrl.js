import APP from '../app';

export default APP.controller('appCtrl', [
    "$scope",
    function (scope) {
        scope.loading = false;
        scope.$on('loading', (event, args) => {
            let {loading} = args;
            scope.loading = loading;
        });
    }
]);