app.controller('registerCtrl', function ($scope, $locale, blockUI, authService, toaster, uuid) {
    $scope.newItem = {
        Id: uuid.v4(),
        Deleted: false,
        Created: new Date()
    }

    $scope.onRegister = function (newItem) {
        var loginBlock = blockUI.instances.get('uiBlock');
        loginBlock.start();
        authService.register(newItem)
            .then(
                function (data) {
                    loginBlock.stop();
                    if (data.Success) {
                        toaster.pop('success', "Thành công", data.Messages.join(', '));
                        var returnUrl = utils.getParameterByName('ReturnUrl');
                        if (returnUrl) {
                            window.location.href = decodeURIComponent(returnUrl);
                        }
                        else {
                            window.location.href = baseHostUrl + "/Auth/Login";
                        }
                    }
                    else {
                        toaster.pop('error', "Lỗi", data.Messages.join(', '));
                    }
                },
                function (errResponse) {
                    loginBlock.stop();
                    toaster.pop('error', "Lỗi", 'Có lỗi xảy ra vui lòng liên hệ quản trị');
                    console.error(errResponse);
                }
            );
    };
});