'use strict'

// Controller for reservation
var reservationController = function ($scope, reservationFactory, reservationList) {
    // Scope variables
    $scope.reservationList = JSON.parse(reservationList.data);
    console.log(reservationList);
    // Scope
    $scope.reservation = {
        customerName: "",
        peopleCount: "",
        time: ""
    }
    
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

    // Function to calculate positive divisors of number		
    $scope.bookTable = function (isValid) {

        // Remove error details and response obj
        setErrorDetails(false, "");
        setResponseDetails("", "", false);

        // Check whether the form is valid, if yes do service call and calculate positive divisors
        if (isValid) {
            // Show Spinner
            showHideSpinner(true);

            // Call service to check string
            reservationFactory.bookTable($scope.reservation)
                .then(successCallback, errorCallback);
        }
        else {
            setErrorDetails(true, "Please input number and correct validation errors if any.");
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
        setErrorDetails(true, "Oops!! Exception occurred while bookng table.");
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
reservationController.$inject = ['$scope', 'reservationFactory', 'reservationList'];
app.controller('reservationController', reservationController);