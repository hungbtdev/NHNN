'use strict';
app.controller('navCtrl', function ($scope,navService, toaster) {
    $scope.navItems = [];

    $scope.getNavigations = function () {
        navService.getNavigations()
            .then(
                function (data) {
                    if (data.Success) {
                        $scope.navItems = data.Data;
                    }
                    else {
                        toaster.pop('error', "Lỗi", data.Messages.join(', '));
                    }
                },
                function (errResponse) {
                    toaster.pop('error', "Lỗi", 'Có lỗi xảy ra vui lòng liên hệ quản trị');
                    console.error(errResponse);
                }
            );
    };
    $scope.getNavigations();
});

