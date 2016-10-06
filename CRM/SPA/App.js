var App = angular.module('App', ['ngRoute', 'ui.bootstrap']);

App.service('Api', ['$http', ApiService]);

App.controller('StudentController', StudentController);
App.controller('ViewStudentController', ViewStudentController);
App.controller('CourseController', CourseController);
App.controller('ViewCourseController', ViewCourseController);
App.controller('EventController', EventController);
App.controller('ViewEventController', ViewEventController);


var configFunction = function ($routeProvider, $httpProvider) {
    $routeProvider.
        when('/students', {
            templateUrl: '../SPA/Views/Students.html',
            controller: StudentController
        })
        .when('/courses', {
            templateUrl: '../SPA/Views/Courses.html',
            controller: CourseController
        })
        .when('/events', {
            templateUrl: '../SPA/Views/Events.html',
            controller: EventController
        })
       .otherwise({
           redirectTo: function () {
               return '/students';
           }
       });
}
configFunction.$inject = ['$routeProvider', '$httpProvider'];

App.config(configFunction);