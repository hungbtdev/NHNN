app.controller('loginCtrl', function ($scope, blockUI, authService, coreService, toaster, $timeout, uuid) {
    $scope.loginModel = {
        DepartmentId: "",
        SessionId: uuid.v4()
    }

    $scope.onLogin = function (loginModel) {
        var loginBlock = blockUI.instances.get('loginBlock');
        loginBlock.start();
        authService.login(loginModel)
            .then(
                function (data) {
                    loginBlock.stop();
                    if (data.Success) {
                        var returnUrl = utils.getParameterByName('ReturnUrl');
                        if (returnUrl) {
                            window.location.href = decodeURIComponent(returnUrl);
                        }
                        else {
                            window.location.href = baseHostUrl;
                        }
                    }
                    else {
                        toaster.pop('error', "Lỗi", data.Messages.join(', '));
                        window.location.reload();
                    }
                },
                function (errResponse) {
                    loginBlock.stop();
                    toaster.pop('error', "Lỗi", 'Có lỗi xảy ra vui lòng liên hệ quản trị');
                }
            );
    };

    $scope.onChangePassword = function (changePasswordModel) {
        var loginBlock = blockUI.instances.get('uiBlock');
        loginBlock.start();
        authService.changePassword(changePasswordModel).then(
            function (rs) {
                loginBlock.stop();
                if (rs.Success) {
                    toaster.pop('success', "Thành công", "Cập nhật mật khẩu thành công");
                    $timeout(function () {
                        window.location.href = baseHostUrl;
                    }, 3000);
                }
                else {
                    toaster.pop('error', "Lỗi", rs.Messages.join(', '));
                }
            },
            function (errResponse) {
                loginBlock.stop();
                toaster.pop('error', "Lỗi", 'Có lỗi xảy ra vui lòng liên hệ quản trị');
                console.error(errResponse);
            });
    }

    $scope.onInitDropdown = function () {
        var loginBlock = blockUI.instances.get('uiBlock');
        loginBlock.start();
        coreService.initDropdown()
            .then(
                function (data) {
                    loginBlock.stop();
                    if (data.Success) {
                        $scope.InitData = data.Data;
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

    $scope.onUpdateProfile = function (profileModel) {
        var loginBlock = blockUI.instances.get('uiBlock');
        loginBlock.start();
        authService.updateProfile(profileModel).then(
            function (rs) {
                loginBlock.stop();
                if (rs.Success) {
                    toaster.pop('success', "Thành công", "Cập nhật thành công");
                    $scope.onGetProfile();
                }
                else {
                    toaster.pop('error', "Lỗi", rs.Messages.join(', '));
                }
            },
            function (errResponse) {
                loginBlock.stop();
                toaster.pop('error', "Lỗi", 'Có lỗi xảy ra vui lòng liên hệ quản trị');
                console.error(errResponse);
            });
    }

    $scope.onGetProfile = function () {
        var loginBlock = blockUI.instances.get('uiBlock');
        loginBlock.start();
        authService.getProfile().then(
            function (rs) {
                loginBlock.stop();
                if (rs.Success) {
                    $scope.profileModel = rs.Data;
                }
                else {
                    toaster.pop('error', "Lỗi", rs.Messages.join(', '));
                }
            },
            function (errResponse) {
                loginBlock.stop();
                toaster.pop('error', "Lỗi", 'Có lỗi xảy ra vui lòng liên hệ quản trị');
                console.error(errResponse);
            });

        
    }

    $scope.refreshCaptCha = function () {
        if ($("#img-captcha").length > 0) {
            var cache = new Date();
            var url = $("#img-captcha").attr("src").split('&')[0];
            $("#img-captcha").attr("src", url + '&cache=' + cache.getTime());
            console.log($("#img-captcha").attr("src"));
        }
    }

    $scope.onInit = function () {
        $scope.onInitDropdown();
    }
});