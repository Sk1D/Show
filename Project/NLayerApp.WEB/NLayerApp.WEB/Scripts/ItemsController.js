var myApp = angular.module('itemApp');
myApp.controller('ItemsController',
    function ItemsController($scope, $http) {
        //$scope.modelItem = {};
        $scope.loaded = false;

        $scope.load = function (val) {
            var params = {
                id: val
            };
            console.log("id:" + val);
            $http.get('/Home/Find/', { params: params }).then(
                function (successResponse) {
                    $scope.modelItems = successResponse.data;
                    console.log('success');
                    $scope.loaded = true;

                },
                function (errorResponse) {

                    $scope.Message = "Call failed" + err.status + "  " + err.statusText;
                });
        };
        $scope.delete = function (val) {
            $http({
                url: '/Home/DeleteItem/',//+val,
                method: "POST",
                data: { id: val },
                headers: { 'Content-Type': 'application/json' }
            }).then(function successCallback(response) {
                console.log(response.data);
                $scope.modelItems = response.data;
                $scope.loaded = true;
            }, function errorCallback() {
                alert("Ошибка");
            });
        }

    }
)