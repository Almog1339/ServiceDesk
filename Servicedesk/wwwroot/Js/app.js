var App = angular.module('App', []);


App.controller('LoginCtrl', function ($scope, $http) {

    $scope.SendData = function () {
        var userData = {
            LoginID: $scope.UserName,
            Password: $scope.Password
        };
        console.log(userData);
        $http.post("api/Login", JSON.stringify(userData)).then(function (response) {
            if (Response.toString()) {
                console.log('ok');
            }
            else {
                console.log('Please check your code');
            }
        });
        
    };
});

