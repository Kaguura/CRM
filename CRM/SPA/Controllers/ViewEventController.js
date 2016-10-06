var ViewEventController = function ($scope, $uibModalInstance, data) {
    $scope.data = data;
    
    $scope.Save = function () {
        $scope.data.event.EventDate = $scope.data.date.toJSON();
        $uibModalInstance.close($scope.data.event);
    }
}