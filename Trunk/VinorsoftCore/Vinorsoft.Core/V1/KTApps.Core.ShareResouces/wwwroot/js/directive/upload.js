app.directive('fileModel', ['$parse', function ($parse) {
    return {
        restrict: 'A',
        link: function (scope, element, attrs) {
            var model = $parse(attrs.fileModel);
            var multiple = $parse(attrs.multiple);
            var modelSetter = model.assign;

            element.bind('change', function () {
                scope.$apply(function () {
                    if (multiple) {
                        modelSetter(scope, element[0].files);
                    } else {
                        modelSetter(scope, element[0].files[0]);
                    }
                });
            });
        }
    };
}]);

app.directive('inputEnter', function () {
    return function (scope, element, attrs) {
        element.bind("keydown keypress", function (event) {
            if (event.which === 13) {
                scope.$apply(function () {
                    scope.$eval(attrs.inputEnter);
                });

                event.preventDefault();
            }
        });
    };
});