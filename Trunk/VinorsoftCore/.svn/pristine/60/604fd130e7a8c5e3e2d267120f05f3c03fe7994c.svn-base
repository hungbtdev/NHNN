app.controller('emailPendingCtrl', function ($controller, $scope, blockUI, coreService, toaster, $ngBootbox, uuid, $timeout, DTOptionsBuilder, DTColumnBuilder, $compile, $filter) {
    angular.extend(this, $controller('coreCtrl', { $scope, blockUI, coreService, toaster, $ngBootbox, uuid, DTOptionsBuilder, DTColumnBuilder, $compile }));
    var vm = this;
    vm.dtColumns = [
        DTColumnBuilder.newColumn('Created').withTitle('Ngày tạo &emsp;&emsp; &emsp; &emsp; &emsp;  &emsp; &emsp; &emsp; &emsp; &emsp; &emsp;  ').withClass('text-nowrap')
            .renderWith(function (data, type, full) {
                return $filter('date')(data, 'dd/MM/yyyy HH:mm:ss');
            }).withOption('defaultContent', ''),

        DTColumnBuilder.newColumn('Subject').withTitle('Tiêu đề').withClass('text-nowrap')
            .withOption('defaultContent', ''),
        DTColumnBuilder.newColumn('EmailTo').withTitle('To').withClass('text-nowrap')
            .withOption('defaultContent', ''),
        DTColumnBuilder.newColumn('CC').withTitle('CC')
            .withOption('defaultContent', ''),
        DTColumnBuilder.newColumn('BCC').withTitle('BCC')
            .withOption('defaultContent', ''),
       
        DTColumnBuilder.newColumn('CoreNotificationStatus.Name').withTitle('Trạng thái')
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
        .withOption('order', [[0, 'desc']])
        .withLightColumnFilter({
            '0': {
                html: 'range',
                width: '50%',
                type: 'date',
                attr: {
                    "class": "form-control",

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
            },
            '4': {
                html: 'input',
                type: 'text',
                attr: {
                    "class": "form-control"
                }
            },
            '5': {
                html: 'input',
                type: 'text',
                attr: {
                    "class": "form-control"
                }
            },
           
        });
});