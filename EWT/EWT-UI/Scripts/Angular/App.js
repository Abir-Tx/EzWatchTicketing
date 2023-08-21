var app = angular.module("EWT", ["rzModule"]);

app.controller("HomeController", function ($scope) {
    $scope.welcomeMessage = "Welcome to EasyWatchTicketing!";

          // Sample data for sliders
      $scope.movieSlider = {
        minValue: 0,
        maxValue: 100,
        options: {
          floor: 0,
          ceil: 100,
          step: 1,
          showTicks: true
        }
      };
      
      $scope.ticketSlider = {
        minValue: 0,
        maxValue: 50,
        options: {
          floor: 0,
          ceil: 50,
          step: 1,
          showTicks: true
        }
      };
      
      $scope.hallSlider = {
        minValue: 0,
        maxValue: 10,
        options: {
          floor: 0,
          ceil: 10,
          step: 1,
          showTicks: true
        }
      };
    });