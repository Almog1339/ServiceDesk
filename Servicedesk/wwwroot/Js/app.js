﻿var App = angular.module('App', ['ngAnimate']);


App.controller('LoginCtrl', function ($scope, $http) {

    $scope.SendData = function () {
        var userData = {
            LoginID: $scope.UserName,
            Password: $scope.Password
        };
        $http.post("api/Login", JSON.stringify(userData));
    };

});

