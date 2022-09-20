'use strict';

app.factory('coreService', ['$http', '$q', function ($http, $q) {
    return {
        get: function (url) {
            return $http.get(
                url)
                .then(
                    function (response) {
                        return response.data;
                    },
                    function (errResponse) {
                        console.log(errResponse);
                        return $q.reject(errResponse);
                    }
                );
        },
        post: function (url, data) {
            return $http.post(
                url,
                JSON.stringify(data),
                { headers: { 'Content-Type': 'application/json' } })
                .then(
                    function (response) {
                        return response.data;
                    },
                    function (errResponse) {
                        console.log(errResponse);
                        return $q.reject(errResponse);
                    }
                );
        },

        getData: function (data) {
            return this.post(baseUrl + '/GetData', data);
        },
        export: function (data) {
            return this.post(baseUrl + '/Export', data);
        },
        


        delete: function (data) {
            return this.post(baseUrl + '/Delete', data);
        },
        save: function (data) {
            return this.post(baseUrl + '/Save', data);
        },
        saveImport: function (data) {
            return this.post(baseUrl + '/SaveForImport', data);
        },
        getById: function (data) {
            return this.get(baseUrl + '/GetById?id=' + data);
        },
        initDropdown: function () {
            return this.get(baseUrl + '/InitDropdown');
        },
        autoComplete: function (url) {
            return this.get(url);
        },
        saveWithUrl: function (_baseUrl,data) {
            return this.post(_baseUrl + '/Save', data);
        },
        uploadFile: function (formdata) {
            return $http.post(
                baseUrl + "/Upload"
                , formdata, {
                    transformRequest: angular.identity,
                    headers: { 'Content-Type': undefined }
                }).then(
                    function (response) {
                        return response.data;
                    },
                    function (errResponse) {
                        return $q.reject(errResponse);
                    }
                );
        },
    };
}]);