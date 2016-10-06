var EventController = function ($scope, $uibModal, Api, $route) {
    $scope.data = []
    $scope.courses = []
    $scope.students = []

    function GetData() {
        Api.GetApiCall("Event", "GetEvents", function (event) {
            if (event.hasErrors == true) {
                alert("Error Getting data: " + event.error);
            } else {
                $scope.data = $.parseJSON(event.result);
                //alert("vndkjf"+ $scope.data);
            }
        });
        Api.GetApiCall("Course", "GetCourses", function (event) {
            if (event.hasErrors == true) {
                alert("Error Getting data: " + event.error);
            } else {
                $scope.courses = $.parseJSON(event.result);
                //alert("vndkjf"+ $scope.data);
            }
        });
        Api.GetApiCall("Student", "GetStudents", function (event) {
            if (event.hasErrors == true) {
                alert("Error Getting data: " + event.error);
            } else {
                $scope.students = $.parseJSON(event.result);
                //alert("vndkjf"+ $scope.data);
            }
        });
    }

    GetData();

    
    $scope.FindCourse = function (CourseID) {
        for (i = 0; i < $scope.courses.length; i++) {
            if ($scope.courses[i].CourseID == CourseID)
                return $scope.courses[i].Title;
        }
    }

    $scope.FindStudent = function (StudentID) {
        for (i = 0; i < $scope.students.length; i++) {
            if ($scope.students[i].ID == StudentID) {
                str = $scope.students[i].LastName.concat(' ', $scope.students[i].FirstName);
                return str;
            }
        }
    }

    $scope.FilterDate = function (jsonDate) {

        var date = new Date(parseInt(jsonDate.substr(6)));
        return date;
    };

    $scope.ViewEvent = function (event) {
        var obj = {
            event: event,
            courses: $scope.courses,
            students: $scope.students,
            date: $scope.FilterDate(event.EventDate)
        };
        var modalInstance = $uibModal.open({
            animation: true,
            templateUrl: '/SPA/Views/ViewEventWindow.html',
            controller: 'ViewEventController',
            size: "",
            resolve: {
                data: obj
            }
        });

        modalInstance.result.then(function (event) {

            Api.PostApiCall("Event", "PostEvent", event, function (e) {
                if (e.hasErrors == true) {
                    alert("Error Getting data: " + e.error);
                } else {
                    $route.reload();
                }
            });
        }, function () {
            $log.info('Modal dismissed at: ' + new Date());
        });
    }

    $scope.Delete = function (e) {
        Api.PostApiCall("Event", "DeleteEvent", e, function (event) {
            if (event.hasErrors == true) {
                alert("Error Getting data: " + event.error);
            } else {
                $route.reload();
            }
        });
    }


}

EventController.$inject = ['$scope', '$uibModal', 'Api', '$route'];