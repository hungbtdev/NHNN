'use strict';

app.factory('importService', ['$http', '$q', function ($http, $q) {
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
        prepareImport: function () {
            return this.get(baseUrl + '/PrepareImport');
        },
        import: function (formdata) {
            return $http.post(
                baseUrl + "/Import"
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
        }
    };
}]);