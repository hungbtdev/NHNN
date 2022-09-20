app.controller('userGroupCtrl', function ($controller, $scope, blockUI, coreService, toaster, $ngBootbox, uuid) {
    angular.extend(this, $controller('coreCtrl', { $scope, blockUI, coreService, toaster, $ngBootbox, uuid }));

    $scope.onInit = function () {
        $scope.onGetbyId();
        $scope.onInitDropdown();
    };

    $scope.onSave = function (newItem) {
        var postItem = angular.copy(newItem);
        if (postItem.UserGroupRoles != null) {
            for (var i = 0; i < postItem.UserGroupRoles.length; i++) {
                postItem.UserGroupRoles[i].Roles = null;
            }
        }
        if (postItem.UserInGroups != null) {
            for (var i = 0; i < postItem.UserInGroups.length; i++) {
                postItem.UserInGroups[i].Users = null;
            }
        }
        

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

    $scope.onDeleteItem = function (deleteItem) {
        deleteItem.Deleted = true;
    };
    
    $scope.onPermitObjectChange = function (item) {
        var exists = $scope.newItem.PermitObjectGroups.filter(e => e.Id != item.Id && e.PermitObjectId == item.PermitObjectId);
        if (exists.length > 0) {
            item.PermitObjectId = '';
        }
    }

    $scope.onAddPermitObject = function () {
        if ($scope.newItem.PermitObjectGroups == null) {
            $scope.newItem.PermitObjectGroups = [];
        }
        $scope.newItem.PermitObjectGroups.push(
            {
                Id: uuid.v4(),
                GroupId: $scope.newItem.Id,
                Deleted: false
            });
    }

    $scope.autoCompleteUsers = {
        minimumChars: 1,
        data: function (query) {
            return coreService.autoComplete(baseHostUrl + '/Auth/GetData?query=' + query)
                .then(function (response) {
                    return response.Data;
                });
        },
        renderItem: function (item) {
            return {
                value: '',
                label: "<span class='auto-complete' ng-bind-html='entry.item.Username + \" - \" + entry.item.UserProfiles.FirstName + \" \" + entry.item.UserProfiles.LastName'></span>"
            }
        },
        itemSelected: function (e) {
            if ($scope.newItem.UserInGroups == null)
                $scope.newItem.UserInGroups = [];
            var filterResult = $scope.newItem.UserInGroups.filter(user => user.Deleted == false && user.UserId == e.item.Id);

            if (filterResult.length <= 0) {
                $scope.newItem.UserInGroups.push(
                    {
                        GroupId: $scope.newItem.Id,
                        UserId: e.item.Id,
                        Users: e.item,
                        Deleted: false,
                        Id: uuid.v4()
                    });
            }

        }
    };
});