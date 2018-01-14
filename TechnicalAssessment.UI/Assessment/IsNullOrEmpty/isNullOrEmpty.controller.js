'use strict'

// Controller for null/empty operations
var nullEmptyController = function ($scope, assessmentFactory) {

    // Scope variables
    $scope.inputStr = "";
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
    
    // Function to check string		
    $scope.checkString = function () {

        // Remove error details and response obj
        setErrorDetails(false, "");
        setResponseDetails("", "", false);

        // Show Spinner
        showHideSpinner(true);

        // Call service to check string
        assessmentFactory.checkString($scope.inputStr)
            .then(successCallback, errorCallback);
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
        setErrorDetails(true, "Oops!! Exception occurred while checking string.");
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
nullEmptyController.$inject = ['$scope', 'assessmentFactory'];
app.controller('nullEmptyController', nullEmptyController);