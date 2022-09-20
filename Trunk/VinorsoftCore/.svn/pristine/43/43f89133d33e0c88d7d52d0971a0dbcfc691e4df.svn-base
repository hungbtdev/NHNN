app.controller('orgChartCtrl', function ($controller, $scope, blockUI, coreService, toaster, $ngBootbox, uuid, $timeout) {
    $scope.search = {
        PageIndex: 1,
        PageSize: 20,
        OrderBy: "UserName",
        DepartmentId: ''
    }
    $scope.data = [];
    $scope.toggle = function (node, event) {
        event.preventDefault();
        node.Collapsed = !node.Collapsed | false;
        if (node.Nodes != null && node.Nodes.length > 0) {
            $('#collapse-' + node.Id).collapse('toggle')
        }
        else {
            $scope.onGetNodeByParent(node);
        }
    };

    $scope.onInit = function () {
        $scope.onGetNodeByParent({
            Id: ''
        })
    }

    $scope.onGetData = function () {
        var loginBlock = blockUI.instances.get('uiBlock');
        loginBlock.start();
        coreService.post(baseUrl + '/GetUserByDepartment', $scope.search)
            .then(
                function (data) {
                    loginBlock.stop();
                    if (data.Success) {
                        $scope.users = data.Data;
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

    $scope.onGetUserByNode = function (node, event) {
        event.preventDefault();
        $scope.search.DepartmentId = node.Id;
        $scope.search.Node = node;
        $scope.onGetData();
    }

    $scope.onGetNodeByParent = function (parentNode) {
        var loginBlock = blockUI.instances.get('uiBlock');
        loginBlock.start();
        coreService.get(baseUrl + '/GetNodeByParentId?parentId=' + parentNode.Id)
            .then(
                function (data) {
                    loginBlock.stop();
                    if (data.Success) {
                        if ($scope.data.length == 0)
                            $scope.data = data.Data;
                        else {
                            parentNode.Nodes = data.Data;
                            parentNode.EndNode = data.Data.length <= 0
                            $('#collapse-' + parentNode.Id).collapse('toggle')
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

});