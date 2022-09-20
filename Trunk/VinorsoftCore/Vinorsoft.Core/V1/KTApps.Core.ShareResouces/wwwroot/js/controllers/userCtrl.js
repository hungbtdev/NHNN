app.controller('userCtrl', function ($controller, $scope, blockUI, coreService, toaster, $ngBootbox, uuid, $timeout, DTOptionsBuilder, DTColumnBuilder, $compile, $filter) {
    angular.extend(this, $controller('coreCtrl', { $scope, blockUI, coreService, toaster, $ngBootbox, uuid, DTOptionsBuilder, DTColumnBuilder, $compile }));
    var vm = this;
    vm.dtColumns = [
        DTColumnBuilder.newColumn('Username').withTitle('Tên đăng nhập').withClass('text-nowrap')
            .withOption('defaultContent', ''),
        DTColumnBuilder.newColumn('FirstName').withTitle('Họ').withClass('text-nowrap')
            .withOption('defaultContent', ''),
        DTColumnBuilder.newColumn('LastName').withTitle('Tên').withClass('text-nowrap')
            .withOption('defaultContent', ''),
        DTColumnBuilder.newColumn('Locked').withTitle('Khóa').withClass('text-nowrap')
            .withOption('defaultContent', '')
            .renderWith(function (data, type, full, meta) {
                if (data)
                    return `<div class= "icheck-primary" >
                        <input type="checkbox"
                            ng-disabled="true"
                            checked
                            id="`+ data.Id + `"
                            name="Locked" />
                            <label for="`+ data.Id + `">&nbsp; </label>
                        </div>`;
            }),
        DTColumnBuilder.newColumn('LockedEnd').withTitle('Thời gian mở khóa').withClass('text-nowrap')
            .renderWith(function (data, type, full, meta) {
                return $filter('date')(data, 'dd/MM/yyyy HH:mm')
            })
            .withOption('defaultContent', ''),
        DTColumnBuilder.newColumn('FailedCount').withTitle('Số lần đăng nhập sai').withClass('text-nowrap')
            .withOption('defaultContent', ''),
        DTColumnBuilder.newColumn('Created').withTitle('Ngày tạo').withClass('text-nowrap')
            .renderWith(function (data, type, full, meta) {
                return $filter('date')(data, 'dd/MM/yyyy HH:mm')
            })
            .withOption('defaultContent', ''),
        DTColumnBuilder.newColumn('UserInGroups').withTitle('Nhóm')
            .withClass('text-nowrap')
            .withOption('defaultContent', '')
            .renderWith(function (data, type, full, meta) {
                if (data) {
                    var result = '';
                    for (var i = 0; i < data.length; i++) {
                        if (data[i].UserGroups)
                            result += data[i].UserGroups.Name + '<br/>';
                    }
                    return result;
                }
            }),
        DTColumnBuilder.newColumn(null, '')
            .notSortable()
            .withClass('text-nowrap p-10')
            .renderWith(function (data, type, full, meta) {
                $scope.selectedItem[data.Id] = data;
                var url = baseUrl + '/UpdateUser?id=' + data.Id;
                var editBtn = '<a class="btn btn-sm btn-primary" href="' + url + '"> <i class="fa fa-pen"></i> </a>';
                var deleteBtn = '<button onclick="angular.element(this).scope().onDelete(angular.element(this).scope().selectedItem[\'' + [data.Id] + '\'])" class="btn btn-sm btn-danger"> <i class="fa fa-trash"></i> </button>';
                return editBtn + '&nbsp;' + deleteBtn;
            })
    ];
    vm.dtOptions
        .withLightColumnFilter({
            '0': {
                html: 'input',
                type: 'text',
                attr: {
                    "class": "form-control"
                }
            },
            '1': {
                html: 'input',
                type: 'text',
                attr: {
                    "class": "form-control"
                }
            },
            '2': {
                html: 'input',
                type: 'text',
                attr: {
                    "class": "form-control"
                }
            },
            '4': {
                html: 'range',
                type: 'date',
                width: '100%',
                attr: {
                    "class": "form-control"
                }
            }
            ,
            '5': {
                html: 'input',
                type: 'number',
                attr: {
                    "class": "form-control"
                }
            },
            '6': {
                html: 'range',
                width: '100%',
                type: 'date',
                attr: {
                    "class": "form-control"
                }
            }
        });

    $scope.newItem = {
        Id: uuid.v4(),
        Deleted: false,
        Created: new Date(),
        UserDepartments: [],
        IsNew: true,
    };
    $scope.passwordCache = "";

    $scope.onAddUserDepartment = function () {
        if ($scope.newItem.UserDepartments == null) {
            $scope.newItem.UserDepartments = [];
        }
        $scope.newItem.UserDepartments.push({
            Id: uuid.v4(),
            Deleted: false,
            Created: new Date(),
            DepartmentId: '',
            JobTitleId: '',
            UserId: $scope.newItem.Id,
            IsNew: true,
        })
    }

    $scope.onSave = function (newItem) {
        var postItem = angular.copy(newItem);
        if (postItem.UserDepartments && postItem.UserDepartments.length > 0) {
            postItem.UserDepartments = postItem.UserDepartments.filter(e => !(e.Deleted && e.IsNew));

            for (var i = 0; i < postItem.UserDepartments.length; i++) {
                if (postItem.UserDepartments[0].Deleted)
                    continue;

                if (!postItem.UserDepartments[0].DepartmentId || postItem.UserDepartments[0].DepartmentId === null || postItem.UserDepartments[0].DepartmentId === "") {
                    toaster.pop('error', "Lỗi", "Vui lòng chọn chi nhánh cấp 1");
                    return;
                }
                if (!postItem.UserDepartments[0].JobTitleId || postItem.UserDepartments[0].JobTitleId === null || postItem.UserDepartments[0].JobTitleId === "") {
                    toaster.pop('error', "Lỗi", "Vui lòng chọn chức danh");
                    return;
                }
            }
        }

        var loginBlock = blockUI.instances.get('uiBlock');
        loginBlock.start();
        coreService.save(postItem)
            .then(
                function (data) {
                    loginBlock.stop();
                    if (data.Success) {
                        toaster.pop('success', "Thành công", data.Messages.join(', '));
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
        var departmentId = utils.getParameterByName("departmentId");
        if (departmentId != null) {
            $scope.newItem.UserDepartments.push(
                {
                    Id: uuid.v4(),
                    DepartmentId: departmentId,
                    Created: new Date(),
                    Deleted: false,
                    UserId: $scope.newItem.Id,
                    IsNew: true,
                })
        }

        var id = utils.getParameterByName("id");
        if (id === null || id.length <= 0) {
            $scope.onInitDropdown();
            return;
        }

        var loginBlock = blockUI.instances.get('uiBlock');
        loginBlock.start();
        coreService.getById(id)
            .then(
                function (data) {

                    loginBlock.stop();
                    if (data.Success) {
                        $scope.newItem = data.Data;
                        $scope.passwordCache = $scope.newItem.Password;
                        if ($scope.newItem.LockedEnd != null) {
                            $scope.newItem.LockedEnd = moment(data.Data.LockedEnd, 'YYYY-MM-DD HH:mm:ss Z');
                        }
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

    $scope.onDeleteItem = function (deleteItem) {
        deleteItem.Deleted = true;
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
                        if ($scope.newItem.UserDepartments && $scope.newItem.UserDepartments.length > 0) {
                            for (var i = 0; i < $scope.newItem.UserDepartments.length; i++) {
                                if ($scope.newItem.UserDepartments[i].DepartmentId !== null && $scope.newItem.UserDepartments[i].DepartmentId !== "") {
                                    $scope.newItem.UserDepartments[i].department2s = $scope.InitData.Departments.filter(x => x.ParentId === $scope.newItem.UserDepartments[i].DepartmentId);
                                }
                                if ($scope.newItem.UserDepartments[i].Department2Id !== null && $scope.newItem.UserDepartments[i].Department2Id !== "") {
                                    $scope.newItem.UserDepartments[i].department3s = $scope.InitData.Departments.filter(x => x.ParentId === $scope.newItem.UserDepartments[i].Department2Id);
                                }
                                if ($scope.newItem.UserDepartments[i].Department3Id !== null && $scope.newItem.UserDepartments[i].Department3Id !== "") {
                                    $scope.newItem.UserDepartments[i].department4s = $scope.InitData.Departments.filter(x => x.ParentId === $scope.newItem.UserDepartments[i].Department3Id);
                                }
                                if ($scope.newItem.UserDepartments[i].Department4Id !== null && $scope.newItem.UserDepartments[i].Department4Id !== "") {
                                    $scope.newItem.UserDepartments[i].department5s = $scope.InitData.Departments.filter(x => x.ParentId === $scope.newItem.UserDepartments[i].Department4Id);
                                }
                            }
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
                });
    }
    
    $scope.changeDepartment = function (item) {
        item.department2s = [];
        item.department3s = [];
        item.department4s = [];
        item.department5s = [];
        item.department2s = $scope.InitData.Departments.filter(x => x.ParentId === item.DepartmentId);
    }

    $scope.changeDepartment2 = function (item) {
        item.department3s = [];
        item.department4s = [];
        item.department5s = [];
        item.department3s = $scope.InitData.Departments.filter(x => x.ParentId === item.Department2Id);
    }

    $scope.changeDepartment3 = function (item) {
        item.department4s = [];
        item.department5s = [];
        item.department4s = $scope.InitData.Departments.filter(x => x.ParentId === item.Department3Id);
    }

    $scope.changeDepartment4 = function (item) {
        item.department5s = [];
        item.department5s = $scope.InitData.Departments.filter(x => x.ParentId === item.Department4Id);
    }

    $scope.resetPassword = function () {
        if ($scope.newItem.IsResetPassword) {
            $scope.newItem.Password = "";
        }
        else {
            $scope.newItem.Password = $scope.passwordCache;
        }
    }

    $scope.onInit = function () {
        //$scope.onInitDropdown();
        $scope.onGetbyId();
    }
});