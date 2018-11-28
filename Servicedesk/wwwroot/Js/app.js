var App = angular.module('App', []);


App.controller('LoginCtrl', function ($scope, $http) {

    $scope.SendData = function () {
        var userData = {
        userName: $scope.UserName,
        password: $scope.Password
        };
        console.log(userData);
        $http.post("api/Login", userData).then(function (response) {
            if (response.userData) {
                console.log('Ok');
            }
        });
        
    };
});

