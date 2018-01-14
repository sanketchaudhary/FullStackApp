'use strict'

var commonNumberController = function ($scope, assessmentFactory) {
    $scope.numberList = [];
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

    // Function to push new item in numbers array
    $scope.addNumber = function () {

        // Set the flags to false
        $scope.hasError = false;

        // Push new element in numberList array
        $scope.numberList.push({ number: "" });
    }

    // Function to get common number from list
    $scope.getCommonNumber = function (isValid) {

        // Remove error details and response obj
        setErrorDetails(false, "");
        setResponseDetails("", "", false);

        // Check whether html form is valid
        if (isValid) {

            if ($scope.numberList.length == 0)
                setErrorDetails(true, "Add numbers to calculate common number");
            else {
                // Show Spinner
                showHideSpinner(true);

                // Iterate through the numberList array and get numbers
                var numberArray = [];
                angular.forEach($scope.numberList, function (value, key) {
                    this.push(value.number);
                }, numberArray);

                // Call service to get common number from the list
                assessmentFactory.getCommonNumber(numberArray)
                    .then(successCallback, errorCallback);
                }
            }
        else {
            if ($scope.numberList.length == 0)
                setErrorDetails(true, "Add numbers to calculate common number");
            else
                setErrorDetails(true, "Please enter numbers in all the text boxes");
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
        setErrorDetails(true, "Oops!! Exception occurred while retrieving common number.");
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
commonNumberController.$inject = ['$scope', 'assessmentFactory'];
app.controller('commonNumberController', commonNumberController);