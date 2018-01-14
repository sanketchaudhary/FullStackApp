/// <reference path="E:\Research\Interview\TechnicalAssessment\TechnicalAssessment\Scripts/angular.js" />
'use strict';

// App module
var app = angular.module('assessmentApp', ['ngRoute', 'ngMessages']);

// Constant to hold Api endpoint urls
app.constant('config', function () {
    var apiEnpoint = "http://localhost:57900/";

    return {
        checkStringApi: apiEnpoint + 'api/Assessment/CheckString?inputVal=',
        positiveDivisorApi: apiEnpoint + 'api/Assessment/GetPositiveDivisors?number=',
        commonNumberApi: apiEnpoint + 'api/Assessment/GetCommonNumber',
        triangleAreaApi: apiEnpoint + 'api/GetTriangleArea',
        reservationListApi: apiEnpoint + 'api/Reservation/GetReservationList',
        bookTableApi: apiEnpoint + 'api/Reservation/BookTable'
    }
}());