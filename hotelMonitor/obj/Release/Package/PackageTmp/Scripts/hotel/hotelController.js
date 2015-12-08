var hotelApp = angular.module('hotelApp', []);

hotelApp.controller('TaskMonitorController', function ($scope, $http) {

    $scope.GetTasks = function (index , rowCount) {
        $http({
            method: 'GET',
            url: '/hotel/gettasks',
            params: {
                index: index,
                rowCount: rowCount
            }
        }).success(function (data) {
            $scope.data = data;
        });
    };

    $scope.AddTask = function() {
        alert("Add!");
    };

    // get data in initial
    $scope.GetTasks(0, 5);
});