app.controller('coreCtrl', function ($scope, blockUI, coreService, toaster, $ngBootbox, uuid, DTOptionsBuilder, DTColumnBuilder, $compile) {

    $scope.selectedItem = {};
    $scope.InitData = {};
    $scope.newItem = {
        Id: uuid.v4()
    };

    $scope.CultureInfo = {
        UTC: '+0000',
        NumberFormat: 0,
        NumberFormatQuantity:0,
    };
    $scope.RoundToDecimal = function (number)
    {
        return +(Math.round(number + "e+" + $scope.CultureInfo.NumberFormat) + "e-" + $scope.CultureInfo.NumberFormat);
    }
    $scope.RoundToDecimal4Number = function (number) {
        return +(Math.round(number + "e+" + $scope.CultureInfo.NumberFormatQuantity) + "e-" + $scope.CultureInfo.NumberFormatQuantity);
    }
    var vm = this;
    vm.dtInstance = function (dtInstance) {
        vm.dtInstance2 = dtInstance;
    };

    vm.dtOptions = DTOptionsBuilder.newOptions()
        .withBootstrap()
        .withOption('scrollCollapse', true)
        .withOption('stateSave', false)
        .withColReorder()
        .withPaginationType('full_numbers')
        .withOption('lengthMenu', [[15, 20, 25, 30, 50], [15, 20, 25, 30, 50]])
        .withOption('autoWidth', false)
        .withOption('ajax', {
            data: function (d) {
                $scope.search = d;
                return JSON.stringify(d);
            },
            url: baseUrl + '/GetDataTableSource',
            type: 'POST',
            dataType: 'json',
            contentType: "application/json"
        })
        .withDataProp('data')
        //<"row"<"col-sm-2"><"col-sm-6">> 
        .withDOM('<"row"<"col-sm-12"tr>> <"row"<"col-sm-2"l> <"col-sm-5"i><"col-sm-5"p>>')
        .withButtons([
            {
                text: '<i class="fa fa-sync-alt"></i>',
                key: '1',
                titleAttr: 'Làm mới',
                className: 'btn btn-sm btn-primary',
                action: function (e, dt, node, config) {
                    dt.ajax.reload();
                }
            },
            {
                text: '<i class="fa fa-download"></i>',
                key: '1',
                titleAttr: 'Xuất file',
                className: 'btn btn-sm btn-primary',
                action: function (e, dt, node, config) {
                    $scope.export();
                }
            },
            {
                text: '<i class="fa fa-plus"></i>',
                key: '1',
                titleAttr: 'Thêm mới',
                className: 'btn btn-sm btn-primary',
                action: function (e, dt, node, config) {
                    window.location.href = baseUrl + '/NewItem'
                }
            }
        ])// 3 buttom o tren
        .withOption('processing', true)
        .withOption('serverSide', true)
        .withOption('language', {
            paginate: {            // Set up pagination text
                first: "&laquo;",
                last: "&raquo;",
                next: "&rarr;",
                previous: "&larr;"
            },
            searchPlaceholder: "Nhập nội dung tìm kiếm",
            decimal: "",
            emptyTable: "Không có dữ liệu hiển thị",
            info: "Hiển thị _START_ đến _END_ trên tổng _TOTAL_ dòng",
            infoEmpty: "Hiển thị 0 đến 0 trên tổng 0 dòng",
            infoFiltered: "(filtered from _MAX_ total entries)",
            infoPostFix: "",
            thousands: ",",
            loadingRecords: "Đang tải...",
            processing: "Đang xử lý...",
            search: "",
            zeroRecords: "Không tìm thấy dữ liệu",
            aria: {
                sortAscending: ": Sắp xếp tăng dần",
                sortDescending: ": Sắp xếp giảm dần"
            },
            lengthMenu: "_MENU_ dòng trên trang"
        })
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
                    "class": "form-control w-300"
                }
            }
        })
        .withOption('initComplete', function () {
            $('.dataTable').parent().css(
                {
                    'overflow-x': 'auto'
                }
            );
        })
        //.withOption('createdRow', createdRow)
        ;
    vm.dtColumns = [
        DTColumnBuilder.newColumn('Code').withTitle('Mã').withClass('text-nowrap'),
        DTColumnBuilder.newColumn('Name').withTitle('Tên').withClass('text-nowrap'),
        DTColumnBuilder.newColumn('Description').withTitle('Mô tả')
            .withClass('w-300'),
        DTColumnBuilder.newColumn(null, '')
            .withClass('text-nowrap p-10')
            .notSortable()
            .renderWith(function (data, type, full, meta) {
                return $scope.defaultButtonRender(data, type, full, meta)
            })
    ];

    //function createdRow(row, data, dataIndex) {
    //    $compile(row)($scope);
    //}

    $scope.defaultButtonRender = function (data, type, full, meta) {
        $scope.selectedItem[data.Id] = data;
        var url = baseUrl + '/UpdateItem?id=' + data.Id;
        var editBtn = '<a class="btn btn-sm btn-primary" data-toggle="tooltip" title="Chỉnh sửa" href="' + url + '"> <i class="fa fa-pen"></i> </a>';
        var deleteBtn = '<button onclick="angular.element(this).scope().onDelete(angular.element(this).scope().selectedItem[\'' + [data.Id] + '\'])" class="btn btn-sm btn-danger" data-toggle="tooltip" title="Xóa"> <i class="fa fa-trash"></i> </button>';
        return editBtn + '&nbsp;' + deleteBtn;
    }

    $scope.onSave = function (newItem) {
        var loginBlock = blockUI.instances.get('uiBlock');
        loginBlock.start();
        coreService.save(newItem)
            .then(
                function (data) {
                    loginBlock.stop();
                    if (data.Success) {
                        toaster.pop('success', "Thành công", "Cập nhật thành công");
                        setTimeout(function () {
                            backToList();
                        },1000)

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

    $scope.onDelete = function (item) {
        $ngBootbox.confirm('Bạn có chắc muốn xóa?')
            .then(function () {
                var loginBlock = blockUI.instances.get('uiBlock');
                loginBlock.start();
                coreService.delete(item)
                    .then(
                        function (data) {
                            loginBlock.stop();
                            if (data.Success) {
                                toaster.pop('success', "Thành công", 'Xóa thành công');
                                if (vm.dtInstance2 != null)
                                    vm.dtInstance2.DataTable.ajax.reload();
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

            }, function () {
            });
    };

    $scope.onGetbyId = function (onSuccess) {
        var id = utils.getParameterByName("id");
        if (id === null || id.length <= 0)
            return;

        var loginBlock = blockUI.instances.get('uiBlock');
        loginBlock.start();
        coreService.getById(id)
            .then(
                function (data) {
                    loginBlock.stop();
                    if (data.Success) {
                        if (onSuccess && typeof (onSuccess) == "function") {
                            onSuccess()
                        }
                        $scope.newItem = data.Data;
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

    $scope.onChangeAutoGenerateCode = function (value) {
        if (value) {
            $scope.newItem.Code = "Auto";
        }
        else {
            $scope.newItem.Code = "";
        }
    };

    $scope.onInitDropdown = function (onSuccess) {
        var loginBlock = blockUI.instances.get('uiBlock');
        loginBlock.start();
        coreService.initDropdown()
            .then(
                function (data) {
                    loginBlock.stop();
                    if (data.Success) {
                        $scope.InitData = data.Data;
                        if (onSuccess)
                            onSuccess(data.Data);
                    }
                    else {
                        toaster.pop(setTimeout(3000), 'error', "Lỗi", data.Messages.join(', '));
                    }
                },
                function (errResponse) {
                    loginBlock.stop();
                    toaster.pop('error', "Lỗi", 'Có lỗi xảy ra vui lòng liên hệ quản trị');
                    console.error(errResponse);
                });
    }

    $scope.export = function () {
        var loginBlock = blockUI.instances.get('uiBlock');
        loginBlock.start();
        coreService.export($scope.search)
            .then(
                function (data) {
                    loginBlock.stop();
                    if (data.Success) {
                        window.location.href = baseUrl + "/Download?fileName=" + data.Data;
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
    }

    $scope.refreshCaptCha = function () {
        if ($("#img-captcha").length > 0) {
            var cache = new Date();
            var url = $("#img-captcha").attr("src").split('&')[0];
            $("#img-captcha").attr("src", url + '&cache=' + cache.getTime());
        }
    }

    $scope.onInit = function () {
        $scope.onInitDropdown(function (data) {
            $scope.onGetbyId(function () {
                setTimeout(function () {
                    $('select:enabled').trigger('change');
                }, 100)
            });
        });
    }

    $scope.filterItems = function (items, filterId, filterProp) {
        if (items)
            return items.filter(e => e[filterProp] == filterId);
    }
});