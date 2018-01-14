'use strict'

// Controller for Traingle Categorisation
var triangleController = function ($scope, assessmentFactory) {

    // Scope variables
    $scope.triangle = {
        sideOne: "",
        sideTwo: "",
        sideThree: ""
    }
    $scope.showSpinner = false;

    // Error scope details
    $scope.error = {
        hasError: "",
        errorMessage: ""
    }

    // Scope to hold response   
    $scope.response = {
        result: "",
        showResponse: false
    }

    // Function to retrieve Triangle Type 			
    $scope.getTriangleArea = function (isValid) {


        // Check whether the form is valid, if yes do service call and retrieve the triangle area
        if (isValid) {

            // Show Spinner
            showHideSpinner(true);

            // Call service to get traingle area
            assessmentFactory.calculateTriangleArea($scope.triangle)
                .then(successCallback, errorCallback);
        }
        else {
            setErrorDetails(true, "Please enter all triangle sides.");
        }
    };

    // Success Callback
    var successCallback = function (response) {

        // Set success and error flag to false
        setErrorDetails(false, "");

        // Set Response object
        if (response != null || response != "") {
            setResponseDetails(response.data, true);
        }

        // Hide Spinner
        showHideSpinner(false);
    }

    // Error Callback
    var errorCallback = function (response) {

        // Set error details
        if(response.data.ExceptionMessage != undefined)
            setErrorDetails(true, response.data.ExceptionMessage + " occurred. Please enter proper sides and try again.");
        else
            setErrorDetails(true, "Oops!! Exception occurred while calculating triangle area.");
        setResponseDetails("", false);

        // Hide Spinner
        showHideSpinner(false);
    }

    // Function to handle spinner functionality
    var showHideSpinner = function (flag) {
        $scope.showSpinner = flag;
    };

    // Function to set Error details
    var setErrorDetails = function (flag, message) {
        $scope.error.hasError = flag;
        $scope.error.errorMessage = message;
    }

    // Function to set Response details object
    var setResponseDetails = function (data, showResponse) {
        $scope.response.result = data;
        $scope.response.showResponse = showResponse;
    }
}

// Register Controller
triangleController.$inject = ['$scope', 'assessmentFactory'];
app.controller('triangleController', triangleController);