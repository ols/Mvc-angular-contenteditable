app.controller("HomeController", ["$scope", "$http", function ($scope, $http) {
    $scope.getTexts = function () {
        $http.get("/Home/GetTexts")
            .success(function (data) {
                $scope.textData = data;
            })
            .error(function () {
                $scope.error = true;
            });
    };
}]);