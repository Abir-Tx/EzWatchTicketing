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

app.controller("LoginController", function ($scope, $http) {
    $scope.login = function () {
        console.log("Button clicked!"); 
        const credentials = {
            username: $scope.username,
            password: $scope.password
        };

        $http.post("https://localhost:44365/api/employee/login", credentials)
            .then(function (response) {
                // Login successful
                const token = response.data.TokenKey;
                // Store the token in local storage or a cookie
                localStorage.setItem("token", token);
                // Redirect or perform further actions
                console.log("Login successful");
            })
            .catch(function (error) {
                // Login failed
                console.error("Login failed:", error);
            });
    };


    function isTokenValid(expiredAt) {
        if (expiredAt == null) return true
        const currentTimestamp = Math.floor(Date.now() / 1000); // Convert to seconds

        return currentTimestamp < expiredAt;
    }
});