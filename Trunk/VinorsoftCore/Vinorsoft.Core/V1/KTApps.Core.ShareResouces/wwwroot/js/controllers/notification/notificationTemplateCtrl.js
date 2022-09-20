app.controller('notificationTemplateCtrl', function ($controller, $scope, blockUI, coreService, toaster, $ngBootbox, uuid, $timeout, DTOptionsBuilder, DTColumnBuilder, $compile, $filter) {
    angular.extend(this, $controller('coreCtrl', { $scope, blockUI, coreService, toaster, $ngBootbox, uuid, DTOptionsBuilder, DTColumnBuilder, $compile }));
    var vm = this;
    vm.dtColumns = [
        DTColumnBuilder.newColumn('CoreNotificationTypes.Name').withTitle('Loại').withClass('text-nowrap')
            .withOption('defaultContent', ''),
        DTColumnBuilder.newColumn('Code').withTitle('Mã').withClass('text-nowrap')
            .withOption('defaultContent', ''),
        DTColumnBuilder.newColumn('Name').withTitle('Tên')
            .withOption('defaultContent', ''),
        DTColumnBuilder.newColumn('Subject').withTitle('Tiêu đề')
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