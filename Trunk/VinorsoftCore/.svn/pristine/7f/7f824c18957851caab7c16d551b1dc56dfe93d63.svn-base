'use strict';

app.factory('roleService', ['$http', '$q', function ($http, $q) {
    var baseUrl = baseHostUrl;
    return {
        getPermissions: function () {
            return $http.get(baseUrl + '/Role/GetPermissions')
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
        getRoles: function (data) {
            return $http.post(baseUrl + '/Role/GetRoles',
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
        saveRoles: function (data) {
            return $http.post(baseUrl + '/Role/SaveRole',
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
    }
}]);