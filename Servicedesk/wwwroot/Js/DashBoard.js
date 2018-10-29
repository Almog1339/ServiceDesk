var Dashboard = angular.module("Dashboard", []);

Dashboard.controller('list', ['$scope', function ($scope) {
    $scope.Buttons = ['New Request', 'New Incident', 'Inventory', 'Contact list', 'Knowledge base'];
    }]);

Dashboard.controller('ContactList', ['$scope', function ($scope) {
    $scope.info = ['First Name ','Last Name ','Email ','Title '];
}]);

Dashboard.controller('TicketsTable', ['$scope','$http', function ($scope , $http) {
    $scope.Ticket = ['Ticket Number', 'Type', 'Short Description', 'Open By', 'Handled by', 'priority'];

    $scope.GetTicketData = function () {
        $http.get('api/ticket').then(function (response) {
            $scope.ticketsData = response.data;
        });
    };
    $scope.GetTicketData();
}]);


