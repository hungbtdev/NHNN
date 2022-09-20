app.controller('uploadCtrl', function ($scope, blockUI, coreService, toaster, $ngBootbox, uuid, $controller ) {
    angular.extend(this, $controller('coreCtrl', { $scope, blockUI, coreService, toaster, $ngBootbox, uuid }));

    $scope.Upload = function () {
        setTimeout(function () {
            var loginBlock = blockUI.instances.get('uiBlock');
            loginBlock.start();
            var formdata = new FormData();
            if ($scope.newItem.File != null && $scope.newItem.File.length > 0) {
                for (var i = 0; i < $scope.newItem.File.length; i++) {
                    formdata.append('file', $scope.newItem.File[i]);
                }
            }
            else {
                toaster.pop('error', "Lỗi", 'Bạn chưa chọn file');
                return;
            }
            coreService.uploadFile(formdata)
                .then(
                    function (data) {
                        loginBlock.stop();
                        if (data.Success) {
                            $scope.newItem.TempName = data.Data[0].TempName;
                            $scope.newItem.FileExtension = data.Data[0].FileExtension;
                            $scope.newItem.Created = data.Data[0].Created;
                            $scope.newItem.Name = data.Data[0].Name;
                            $scope.newItem.CreatedBy = data.Data[0].CreatedBy;
                            $scope.newItem.MimeType = data.Data[0].MimeType;
                            $scope.newItem.RefId = data.Data[0].RefId;
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
        }, 500)
    }

    $scope.onSave = function (newItem) {
        if ($scope.newItem.File == null || $scope.newItem.File.length == 0) {
            toaster.pop('error', "Lỗi", 'Bạn chưa chọn file');
            return;
        }
        var loginBlock = blockUI.instances.get('uiBlock');
        loginBlock.start();
        var postItem = angular.copy(newItem);
        coreService.save(postItem)
            .then(
                function (data) {
                    loginBlock.stop();
                    if (data.Success) {
                        toaster.pop('success', "Thành công", "Cập nhật thành công");
                        setTimeout(function () {
                            backToList();
                        }, 1000)
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