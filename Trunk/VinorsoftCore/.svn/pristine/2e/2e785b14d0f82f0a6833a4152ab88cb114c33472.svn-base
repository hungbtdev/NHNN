'use strict';

app.factory('navService', ['$http', '$q', function ($http, $q) {
    var baseUrl = baseHostUrl;
    return {
        getNavByPermission: function () {
            return $http.get(baseUrl + '/Nav/GetNavByPermission')
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
        getNavigations: function () {
            return $http.get(baseUrl + '/Nav/GetNavigations')
                .then(
                    function (response) {
                        return response.data;
                    },
                    function (errResponse) {
                        console.log(errResponse);
                        return $q.reject(errResponse);
                    }
                );
        }
    }

}]);