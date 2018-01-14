
'use strict'
// Configure routes for App
app.config(function ($routeProvider, $locationProvider) {
    // Added line to remove ! mark from url
    $locationProvider.hashPrefix('');
    $routeProvider

        // Routes
        .when('/', {
            templateUrl: 'Assessment/IsNullOrEmpty/isNullOrEmpty.html',
            controller: 'nullEmptyController'
        })
        .when('/positiveDivisor', {
            templateUrl: 'Assessment/PositiveDivisor/positiveDivisor.html',
            controller: 'positiveDivisorController'
        })
        .when('/triangleCheck', {
            templateUrl: 'Assessment/Triangle/triangle.html',
            controller: 'triangleController'
        })
        .when('/commonNumber', {
            templateUrl: 'Assessment/CommonNumber/commonNumber.html',
            controller: 'commonNumberController'
        })
        .when('/reservation', {
            templateUrl: 'Assessment/Reservation/reservation.html',
            controller: 'reservationController',
            resolve: {
                reservationList: function (reservationFactory) {
                    return reservationFactory.getReservationList();
                }
            }
        })
});