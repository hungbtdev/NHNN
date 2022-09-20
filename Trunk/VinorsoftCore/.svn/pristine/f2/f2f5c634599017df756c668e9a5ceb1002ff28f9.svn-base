app.controller('tenantCtrl', function ($controller, $scope, blockUI, coreService, toaster, uuid, $ngBootbox) {
    angular.extend(this, $controller('coreCtrl', { $scope, blockUI, coreService, toaster, $ngBootbox, uuid }));

    $scope.onAddNewConnection = function () {
        if ($scope.newItem.CoreTenantConnections == null)
            $scope.newItem.CoreTenantConnections = [];
        $scope.newItem.CoreTenantConnections.push(
            {
                Id: uuid.v4(),
                Deleted: false,
                TenantId: $scope.newItem.Id
            })
    }
    $scope.onDelete = function (item) {
        item.Deleted = true;
    }
});