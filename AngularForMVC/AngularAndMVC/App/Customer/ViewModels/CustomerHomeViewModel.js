customerModule.controller("customerHomeViewModel", function ($scope, customerService, $http, $q, $routeParams, $window, $location, viewModelHelper) {

    $scope.viewModelHelper = viewModelHelper;
    $scope.customerService = customerService;


    var initialize = function () {

    }

    initialize();
});
