// Factory to call WebApi endpoints
reservationFactory.$inject = ['$http', 'config'];
function reservationFactory($http, config) {
    var factory = {};

    // Function to call Web Api endpoint for retrieving reservation details
    factory.getReservationList = function () {
        return $http.get(config.reservationListApi);
    }

    // Function to call Web Api endpoint for retrieving reservation details
    factory.bookTable = function (reservationDetails) {
        return $http.post(config.bookTableApi, reservationDetails);
    }

    // return factory object
    return factory;
}

// Register Factory
app.factory("reservationFactory", reservationFactory);