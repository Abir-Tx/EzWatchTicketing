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

app.controller("LoginController", function ($scope, $http, $window) {
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
                    
                console.log("Login successful");

                // Redirect to a new page if token in available
                // Check if token is valid before redirection
                if (isTokenValid(response.data.ExpiredAt)) {
                    $window.location.href = "https://localhost:44365/EmpDashboard/Dashboard";
                }
                else {
                    console.log("Token Expired. Expired token: " + token)
                }

            })
            .catch(function (error) {
                // Login failed
                console.error("Login failed:", error);
            });
    };

    app.controller("EmpDashboardController", function ($scope, $http) {
        const token = "e61f74eb-210a-43be-ac5c-6d0206a9acbc"; // Replace with your actual token
        const apiUrl = "https://localhost:44365/api/employee/all";

        const config = {
            headers: {
                "Authorization": token
            }
        };

        $http.get(apiUrl, config)
            .then(function (response) {
                console.log("Executed");
                $scope.employees = response.data;
            })
            .catch(function (error) {
                console.error("Error fetching data:", error);
            });
    });


    function isTokenValid(expiredAt) {
        if (expiredAt == null) return true
        const currentTimestamp = Math.floor(Date.now() / 1000); // Convert to seconds

        return currentTimestamp < expiredAt;
    }
});