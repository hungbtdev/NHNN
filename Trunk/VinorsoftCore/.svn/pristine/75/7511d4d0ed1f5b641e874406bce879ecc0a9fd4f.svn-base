app.controller('userConfirmCodeCtrl', function ($scope, blockUI, coreService, toaster, $ngBootbox, uuid, $controller) {
    angular.extend(this, $controller('coreCtrl', { $scope, blockUI, coreService, toaster, $ngBootbox, uuid }));

    $scope.newItem.Issued = new Date();

    $scope.onSave = function (newItem) {
        var loginBlock = blockUI.instances.get('uiBlock');
        var postItem = angular.copy(newItem);
        postItem.Users = null;
        loginBlock.start();
        coreService.save(postItem)
            .then(
                function (data) {
                    loginBlock.stop();
                    if (data.Success) {
                        toaster.pop('success', "Thành công", "Cập nhật thành công");
                        backToList();
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

    $scope.findUser = function (username) {
        var loginBlock = blockUI.instances.get('uiBlock');
        loginBlock.start();
        coreService.get(baseUrl + '/FindUser?username=' + username)
            .then(
                function (data) {
                    loginBlock.stop();
                    if (data.Success) {
                        $scope.newItem.Users = data.Data;
                        $scope.newItem.UserId = data.Data.Id;
                    }
                    else {
                        toaster.pop('error', "Lỗi", data.Messages.join(', '));
                    }
                },
                function (errResponse) {
                    loginBlock.stop();
                    toaster.pop('error', "Lỗi", 'Có lỗi xảy ra vui lòng liên hệ quản trị');
                    console.error(errResponse);
                });
    }

    $scope.onRandomCode = function () {
        $scope.newItem.ConfirmCode = Math.floor(100000 + Math.random() * 900000);
    }
});