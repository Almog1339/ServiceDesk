var Login = angular.module('Login', ["ngRoute"]);
Login.controller('LoginCtrl', function ($scope, $http)
{
    $scope.SendData = function () {
        $scope.data = {
            userName: $scope.UserName,
            password: $scope.Password,
            departmentID: $scope.DepartmentID
        };

        $http.post("api/Login", JSON.stringify($scope.data)).then(function (response) {
            switch (DepartmentID) {
                case 1, 2, 6:
                    $http.get("api/")
                    break;
                case 3, 4:
                    $http.get("api/")
                    break;
                case 5, 7, 8, 12, 13, 15:
                    $http.get("api/")
                    break;
                case 9:
                    $http.get("api/HR",);
                    break;
                case 10, 11, 16, 14:
                    $http.get("api/")
                    break;
                case 17:
                    $http.get("api/")
                    break;
                
            }
        });
    };
});