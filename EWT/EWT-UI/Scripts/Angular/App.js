var app = angular.module("EWT", []);

app.controller("HomeController", function ($scope) {
    $scope.welcomeMessage = "Welcome to EasyWatchTicketing!";
});

app.controller("MovieController", function ($scope, $http) {
    $scope.welcomeMessage = "Welcome to EasyWatchTicketing!";

    $http.get("https://localhost:44365/api/movie/all")
        .then(function (response) {
            $scope.movies = response.data;
            console.log("Data Fetching Successfull");
        })
        .catch(function (error) {
            console.error("Error fetching data:", error);
        });
});