var CourseController = function ($scope, $uibModal, Api, $route) {
    $scope.data = []

    function GetData() {
        Api.GetApiCall("Course", "GetCourses", function (event) {
            if (event.hasErrors == true) {
                alert("Error Getting data: " + event.error);
            } else {
                $scope.data = $.parseJSON(event.result);
                //alert("vndkjf"+ $scope.data);
            }
        });
    }

    GetData();

    $scope.ViewCourse = function (course) {
        var modalInstance = $uibModal.open({
            animation: true,
            templateUrl: '/SPA/Views/ViewCourseWindow.html',
            controller: 'ViewCourseController',
            size: "",
            resolve: {
                data: course
            }
        });

        modalInstance.result.then(function (course) {
            Api.PostApiCall("Course", "PostCourse", course, function (event) {
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

    $scope.Delete = function (course) {
        Api.PostApiCall("Course", "DeleteCourse", course, function (event) {
            if (event.hasErrors == true) {
                alert("Error Getting data: " + event.error);
            } else {
                $route.reload();
            }
        });
    }


}

CourseController.$inject = ['$scope', '$uibModal', 'Api', '$route'];