var App = angular.module('App', []);


App.controller('LoginCtrl', function ($scope, $http) {
    $scope.data = {
        userName: $scope.UserName,
        password: $scope.Password,
        departmentID: DepartmentID
    };
    $scope.SendData = function () {
        $http.post("api/Login", $scope.data).then(function (response) {
            console.log(response.data);
        });
        
    };
});

