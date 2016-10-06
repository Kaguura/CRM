var ViewCourseController = function ($scope, $uibModalInstance, data) {
    $scope.data = data;
    $scope.Save = function () {
        $uibModalInstance.close($scope.data);
    }
}