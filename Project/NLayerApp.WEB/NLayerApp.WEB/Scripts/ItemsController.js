var myApp = angular.module('itemApp');
myApp.controller('ItemsController',
    function ItemsController($scope, $http) {
        //$scope.modelItem = {};
        $scope.loaded = false;

        $scope.load = function (val) {
            var params = {               
                id:val
            };
            console.log("id:"+val);
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
   

 
    }
)