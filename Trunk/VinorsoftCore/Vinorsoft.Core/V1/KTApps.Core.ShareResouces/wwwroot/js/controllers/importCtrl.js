app.controller('importCtrl', function ($scope, blockUI, importService, toaster, $localstorage) {
    $scope.onInitData = function () {
        var key = window.location.href;
        $scope.initDatas = $localstorage.getObject(key, null);
        if (!$scope.initDatas) {
            $scope.initDatas = {
                File: null,
                Mappings: [],
                StartRowIndex: 1,
                LogColumnIndex: 5,
                IsUsingTemplate:true
            };
        }
        else {
            return;
        }
        $scope.initDatas.IsUsingTemplate = true;
        var loginBlock = blockUI.instances.get('uiBlock');
        loginBlock.start();
        importService.prepareImport()
            .then(
                function (data) {
                    loginBlock.stop();
                    if (data.Success) {
                        $scope.initDatas.Mappings = data.Data;
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

    $scope.onImport = function () {
        var loginBlock = blockUI.instances.get('uiBlock');
        loginBlock.start();
        var formdata = new FormData();
        
        if ($scope.initDatas.File.length > 0) {
            for (var i = 0; i < $scope.initDatas.File.length; i++) {
                formdata.append('file', $scope.initDatas.File[i]);
            }
        }

        if ($scope.initDatas.IsUsingTemplate) {
            $scope.initDatas.SheetName = "Sheet1";
        }

        
        formdata.append('importData.StartRowIndex', $scope.initDatas.StartRowIndex);
        formdata.append('importData.LogColumnIndex', $scope.initDatas.LogColumnIndex);
        formdata.append('importData.SheetName', $scope.initDatas.SheetName);
        formdata.append('importData.IsUsingTemplate', $scope.initDatas.IsUsingTemplate);
        formdata.append('importData.CampaignId', $scope.initDatas.CampaignId);
        for (var i = 0; i < $scope.initDatas.Mappings.length; i++) {
            var mapping = $scope.initDatas.Mappings[i];
            formdata.append('importData.ImportMappings[' + i + '].PropertyDescription', mapping.PropertyDescription);
            formdata.append('importData.ImportMappings[' + i + '].AutoGenerateIfNull', mapping.AutoGenerateIfNull);
            formdata.append('importData.ImportMappings[' + i + '].Required', mapping.Required);
            formdata.append('importData.ImportMappings[' + i + '].MappingWithColumn', mapping.MappingWithColumn);
            formdata.append('importData.ImportMappings[' + i + '].PropertyName', mapping.PropertyName);
            formdata.append('importData.ImportMappings[' + i + '].AutoGenerateColumn', mapping.AutoGenerateColumn);
        }

        var key = window.location.href;
        $localstorage.setObject(key, $scope.initDatas);

        importService.import(formdata).then(
            function (data) {
                loginBlock.stop();
                if (data.Success) {
                    $('#fileImport').val('');
                    toaster.pop('success', "Thành công", "Import thàng công");
                    window.location.href = baseUrl + "/Download?fileName=" + data.DownloadFileName;
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

});