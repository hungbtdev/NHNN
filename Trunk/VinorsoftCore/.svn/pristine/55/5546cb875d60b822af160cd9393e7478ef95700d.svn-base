app.controller('smtpConfigCtrl', function ($controller, $scope, blockUI, coreService, toaster, $ngBootbox, uuid, $timeout, DTOptionsBuilder, DTColumnBuilder, $compile, $filter) {
    angular.extend(this, $controller('coreCtrl', { $scope, blockUI, coreService, toaster, $ngBootbox, uuid, DTOptionsBuilder, DTColumnBuilder, $compile }));
    var vm = this;
    vm.dtColumns = [
        DTColumnBuilder.newColumn('SmtpServer').withTitle('SMTP Server').withClass('text-nowrap')
            .withOption('defaultContent', ''),
        DTColumnBuilder.newColumn('Port').withTitle('Port').withClass('text-nowrap')
            .withOption('defaultContent', ''),
        DTColumnBuilder.newColumn('DisplayName').withTitle('Tên hiển thị')
            .withOption('defaultContent', ''),
        DTColumnBuilder.newColumn('UserName').withTitle('Tên đăng nhập')
            .withOption('defaultContent', ''),
        
        DTColumnBuilder.newColumn(null, '')
            .notSortable()
            .withClass('text-nowrap p-10')
            .renderWith($scope.defaultButtonRender)
    ];
    vm.dtOptions
        .withOption('initComplete', function () {
            $('.dataTable').parent().css(
                {
                    'overflow-x': 'auto'
                }
            );
        })
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
                text: '<i class="fa fa-plus"></i>',
                key: '1',
                titleAttr: 'Thêm mới',
                className: 'btn btn-sm btn-primary',
                action: function (e, dt, node, config) {
                    window.location.href = baseUrl + '/NewItem'
                }
            }
        ])
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
        });
});