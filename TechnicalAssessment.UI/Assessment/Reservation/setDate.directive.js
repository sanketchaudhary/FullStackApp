'use strict'

// Directive to set date to scope object when selected by DatePicker
var setDateDirective = function () {
    return {
        restrict: 'A',
        scope: {
            date:'='
        },
        link: function (scope, elm, attr, ngModel) {
            // When date is selected from date picker set it to scope variable
            elm.on('blur', function () {
                scope.date = elm.val();
                scope.$apply();
            });
        }
    }
};

// Register directive
app.directive("setDate", setDateDirective);