app.controller('userConfirmCtrl', function ($controller, $scope, blockUI, coreService, toaster, $ngBootbox, uuid, $timeout, DTOptionsBuilder, DTColumnBuilder, $compile, $filter) {
    angular.extend(this, $controller('coreCtrl', { $scope, blockUI, coreService, toaster, $ngBootbox, uuid, DTOptionsBuilder, DTColumnBuilder, $compile }));
    var vm = this;
    vm.dtColumns = [
        DTColumnBuilder.newColumn('UserConfirmTypes.Name').withTitle('Loại mã').withClass('text-nowrap')
            .withOption('defaultContent', ''),
        DTColumnBuilder.newColumn('Users.Username').withTitle('Tên đăng nhập').withClass('text-nowrap')
            .withOption('defaultContent', ''),
        DTColumnBuilder.newColumn('Users.FirstName').withTitle('Họ').withClass('text-nowrap')
            .withOption('defaultContent', ''),
        DTColumnBuilder.newColumn('Users.LastName').withTitle('Tên').withClass('text-nowrap')
            .withOption('defaultContent', ''),
        DTColumnBuilder.newColumn('ConfirmCode').withTitle('Mã xác nhận').withClass('text-nowrap')
            .withOption('defaultContent', ''),
        DTColumnBuilder.newColumn('Issued').withTitle('Ngày cấp').withClass('text-nowrap')
            .renderWith(function (data, type, full, meta) {
                return $filter('date')(data, 'dd/MM/yyyy HH:mm');
            })
            .withOption('defaultContent', ''),
        DTColumnBuilder.newColumn('Expired').withTitle('Ngày hết hạn').withClass('text-nowrap')
            .renderWith(function (data, type, full, meta) {
                return $filter('date')(data, 'dd/MM/yyyy HH:mm');
            })
            .withOption('defaultContent', ''),
        DTColumnBuilder.newColumn('UserConfirmStatus.Name').withTitle('Trạng thái')
            .withClass('text-nowrap')
            .withOption('defaultContent', ''),

        DTColumnBuilder.newColumn(null, '')
            .notSortable()
            .withClass('text-nowrap p-10')
            .renderWith(function (data, type, full, meta) {
                $scope.selectedItem[data.Id] = data;
                var url = baseUrl + '/UpdateItem?id=' + data.Id;
                var deleteBtn = '<button onclick="angular.element(this).scope().onDelete(angular.element(this).scope().selectedItem[\'' + [data.Id] + '\'])" class="btn btn-sm btn-danger"> <i class="fa fa-trash"></i> </button>';
                return deleteBtn;
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
            '3': {
                html: 'input',
                type: 'text',
                attr: {
                    "class": "form-control"
                }
            }
            ,
            '4': {
                html: 'input',
                type: 'text',
                attr: {
                    "class": "form-control"
                }
            },
            '5': {
                html: 'range',
                width: '100%',
                type: 'date',
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
            },
            '7': {
                html: 'input',
                type: 'text',
                attr: {
                    "class": "form-control"
                }
            }
        });
});