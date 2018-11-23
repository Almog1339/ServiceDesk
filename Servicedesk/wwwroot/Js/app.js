var ServiceDesk = angular.module('ServiceDeskCtrl', ['ngRoute']);

ServiceDesk.config(['$routeProvider', function ($routeProvider) {
    $routeProvider
        .when('/index.html', {
            templateUrl: '/Login.html',
            controller: 'LoginCtrl'
        })
        .otherwise({
            redirectTo: '/index.html'
        });
}]);

ServiceDesk.controller('LoginCtrl', function ($scope) {
    $scope.SendData = function () {
        $scope.data = {
            userName: $scope.UserName,
            password: $scope.Password,
            departmentID: $scope.DepartmentID
        };

        $http.post("api/Login", JSON.stringify($scope.data)).then(function (response) {
        });
    };
});