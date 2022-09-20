app.controller('uploadTemplateCtrl', function ($controller, $scope, blockUI, coreService, toaster, $ngBootbox, uuid, $timeout, DTOptionsBuilder, DTColumnBuilder, $compile) {
    angular.extend(this, $controller('coreCtrl', { $scope, blockUI, coreService, toaster, $ngBootbox, uuid, DTOptionsBuilder, DTColumnBuilder, $compile }));

    var vm = this;
    vm.dtColumns = [
        DTColumnBuilder.newColumn('Code').withTitle('Mã').withClass('text-nowrap'),
        DTColumnBuilder.newColumn('Name').withTitle('Tên').withClass('text-nowrap'),
        DTColumnBuilder.newColumn('Description').withTitle('Mô tả').withClass('text-nowrap'),
        DTColumnBuilder.newColumn(null, '')
            .withClass('text-nowrap p-10')
            .notSortable()
            .renderWith(function (data, type, full, meta) {
                $scope.selectedItem[data.Id] = data;
                var url = baseUrl + '/UpdateItem?id=' + data.Id;
                var editBtn = '<a class="btn btn-sm btn-primary" href="' + url + '"> <i class="fa fa-pen"></i> </a>';
                var deleteBtn = '<button onclick="angular.element(this).scope().onDelete(angular.element(this).scope().selectedItem[\'' + [data.Id] + '\'])" class="btn btn-sm btn-danger"> <i class="fa fa-trash"></i> </button>';
                var url = baseUrl + '/DownloadFile?fileId=' + data.Id;
                var downloadBtn = '<a class="btn btn-sm btn-primary" href="' + url + '"> <i class="fa fa-download"></i> </a>';
                return editBtn + '&nbsp;' + deleteBtn + '&nbsp;' + downloadBtn;
            })
    ];
    vm.dtOptions.withLightColumnFilter({
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
        }
    });

})