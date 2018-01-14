// Factory to call WebApi endpoints
assessmentFactory.$inject = ['$http', 'config'];
function assessmentFactory($http, config)
{
    var factory = {};

    // Function to call Web Api endpoint for checking string
    factory.checkString = function (inputStr) {
        return $http.get(config.checkStringApi + inputStr);
    }

    // Function to call Web Api endpoint for calculating positive divisors
    factory.calculatePositiveDivisors = function (number) {
        return $http.get(config.positiveDivisorApi + number);
    }

    // Function to call Web Api endpoint for getting common number from list of numbers
    factory.getCommonNumber = function (numberList) {
        return $http.post(config.commonNumberApi, numberList);
    }

    // Function to call Web Api endpoint for calculating triangle area
    factory.calculateTriangleArea = function (triangle) {
        return $http.post(config.triangleAreaApi, triangle);
    }

    // return factory object
    return factory;
}

// Register Factory
app.factory("assessmentFactory", assessmentFactory);