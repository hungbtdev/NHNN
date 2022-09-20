'use strict';
app.controller('navAdminCtrl', function ($controller, $scope, blockUI, coreService, toaster, $ngBootbox, uuid, $timeout, DTOptionsBuilder, DTColumnBuilder, $compile) {
    angular.extend(this, $controller('coreCtrl', { $scope, blockUI, coreService, toaster, $ngBootbox, uuid, DTOptionsBuilder, DTColumnBuilder, $compile }));
    var vm = this;
    $scope.selectedItem = {};
    vm.dtColumns = [
        DTColumnBuilder.newColumn('CoreModules.Name').withTitle('Module'),
        DTColumnBuilder.newColumn('Code').withTitle('Mã'),
        DTColumnBuilder.newColumn('Name').withTitle('Tên'),
        DTColumnBuilder.newColumn('Position').withTitle('Vị trí'),
        DTColumnBuilder.newColumn('Url').withTitle('Url'),
        DTColumnBuilder.newColumn('Description').withTitle('Mô tả'),
        DTColumnBuilder.newColumn(null, '')
            .notSortable()
            .renderWith(function (data, type, full, meta) {
                $scope.selectedItem[data.Id] = data;
                var url = baseUrl + '/UpdateItem?id=' + data.Id;
                var editBtn = '<a class="btn btn-sm btn-primary" href="' + url + '"> <i class="fa fa-pen"></i> </a>';
                var deleteBtn = '<button type="button" onClick="angular.element(this).scope().onDelete(angular.element(this).scope().selectedItem[\'' + data.Id + '\'])" class="btn btn-sm btn-danger"> <i class="fa fa-trash"></i> </button>';
                return editBtn + '&nbsp;' + deleteBtn;
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
        }
    });
});

