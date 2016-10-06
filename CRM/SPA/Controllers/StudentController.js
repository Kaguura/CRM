var StudentController = function ($scope, $uibModal, Api, $route) {
    $scope.data = []

    function GetData() {
        Api.GetApiCall("Student", "GetStudents", function (event) {
            if (event.hasErrors == true) {
                alert("Error Getting data: " + event.error);
            } else {
                $scope.data = $.parseJSON(event.result);
                //alert("vndkjf"+ $scope.data);
            }
        });
    }

    GetData();

    $scope.ViewStudent = function (student) {
        var modalInstance = $uibModal.open({
            animation: true,
            templateUrl: '/SPA/Views/ViewStudentWindow.html',
            controller: 'ViewStudentController',
            size: "",
            resolve: {
                data: student
            }
        });

        modalInstance.result.then(function (student) {
            Api.PostApiCall("Student", "PostStudent", student, function (event) {
                if (event.hasErrors == true) {
                    alert("Error Getting data: " + event.error);
                } else {
                    $route.reload();
                }
            });
        }, function () {
            $log.info('Modal dismissed at: ' + new Date());
        });
    }

    $scope.Delete = function (student) {
        Api.PostApiCall("Student", "DeleteStudent", student, function (event) {
            if (event.hasErrors == true) {
                alert("Error Getting data: " + event.error);
            } else {
                $route.reload();
            }
        });
    }


}

StudentController.$inject = ['$scope', '$uibModal', 'Api', '$route'];