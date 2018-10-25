var Dashboard = angular.module("Dashboard", []);

Dashboard.controller('list', ['$scope', function ($scope) {
    $scope.Buttons = ['New Request ','New Incident ','Inventory ','Contact list '];
}]);

Dashboard.controller('ContactList', ['$scope', function ($scope) {
    $scope.info = ['First Name ','Last Name ','Email ','Title '];
}]);

Dashboard.controller('TicketsTable', ['$scope', function ($scope) {
    $scope.Ticket = ['Ticket Number', 'Type', 'Short Discription', 'Open By', 'Handled by'];
}]);

Dashboard.controller('TicketData', ['$scope', function ($scoe) {
    $scoe.Ticket = [];
}]);

