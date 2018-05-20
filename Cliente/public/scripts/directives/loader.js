import APP from '../app.js';

export default APP.directive('loader', function () {
    return {restrict: 'E', templateUrl: '../templates/loading.html'}
});