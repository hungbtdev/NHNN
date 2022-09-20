
app.controller('permitObjectCtrl', function ($controller, $scope, blockUI, coreService, toaster, $ngBootbox, uuid, $timeout) {
    angular.extend(this, $controller('coreCtrl', { $scope, blockUI, coreService, toaster, $ngBootbox, uuid }));

    $scope.onInit = function () {
        //$scope.onInitDropdown();
        $scope.onGetbyId();
    }

    $scope.selectedAllItem = function (permitObjectSidebars) {
        if (permitObjectSidebars.SidebarIds == null) {
            permitObjectSidebars.SidebarIds = [];
        }

        var sideBarItems = $scope.InitData.SidebarItems.filter(e => e.ModuleId == permitObjectSidebars.ModuleId);
        for (var i = 0; i < sideBarItems.length; i++) {
            if (!permitObjectSidebars.SidebarIds.includes(sideBarItems[i].Id)) {
                permitObjectSidebars.SidebarIds.push(sideBarItems[i].Id);
            }
        }

        $timeout(function () {
            $('select').trigger('change');
        }, 100);
    }

    $scope.getModuleName = function (item) {
        if ($scope.InitData.Modules != null) {
            var exist = $scope.InitData.Modules.filter(e => e.Id == item.ModuleId);
            if (exist.length > 0) {
                return exist[0].Name;
            }
        }
        return '';
    }

    $scope.onSave = function (newItem) {
        var postItem = angular.copy(newItem);
        var loginBlock = blockUI.instances.get('uiBlock');
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

    $scope.onGetbyId = function () {
        var id = utils.getParameterByName("id");
        var loginBlock = blockUI.instances.get('uiBlock');
        loginBlock.start();
        coreService.getById(id)
            .then(
                function (data) {
                    
                    loginBlock.stop();
                    if (data.Success) {
                        $scope.newItem = data.Data;
                        $scope.onInitDropdown();
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
    };

    $scope.onInitDropdown = function () {
        var loginBlock = blockUI.instances.get('uiBlock');
        loginBlock.start();
        coreService.initDropdown()
            .then(
                function (data) {
                    loginBlock.stop();
                    if (data.Success) {
                        $scope.InitData = data.Data;
                        //$scope.onGetbyId();
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
});