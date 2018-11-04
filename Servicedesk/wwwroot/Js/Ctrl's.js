Dashboard.controller('TicketsTable', ['$scope', '$http', function ($scope, $http) {
    $scope.Ticket = ['Ticket Number', 'Type', 'Short Description', 'Open By', 'Handled by'];

    $scope.GetTicketData = function () {
        $http.get('api/ticket').then(function (response) {
            $scope.ticketsData = response.data;
        });
    };
    $scope.GetTicketData();
}]);