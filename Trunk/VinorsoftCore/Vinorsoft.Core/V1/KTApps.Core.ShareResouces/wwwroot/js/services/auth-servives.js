'use strict';

app.factory('authService', ['$http', '$q', function ($http, $q) {
    var baseUrl = baseHostUrl;
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
        getById: function (data) {
            return this.get(baseUrl + '/Auth/GetById?userId=' + data);
        },
        updateUserRoles: function (data) {
            return $http.post(baseUrl + '/Auth/UpdateUserRoles',
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
        getRoles: function () {
            return $http.get(baseUrl + '/Auth/GetRoles',
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
        login: function (loginData) {
            return $http.post(baseUrl + '/Auth/Login',
                JSON.stringify(loginData),
                { headers: { 'Content-Type': 'application/json' } })
                .then(
                    function (response) {
                        return response.data;
                    },
                    function (errResponse) {
                        return $q.reject(errResponse);
                    }
                );
        },
        register: function (regData) {
            return $http.post(baseUrl + '/Auth/Register',
                JSON.stringify(regData),
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
        changePassword: function (data) {
            return $http.post(baseUrl + '/Auth/ChangePassword',
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
        getProfile: function (data) {
            return $http.get(baseUrl + '/Auth/GetProfileInfo')
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
        updateProfile: function (data) {
            return $http.post(baseUrl + '/Auth/UpdateProfile',
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
        getUsers: function (data) {
            return $http.post(baseUrl + '/Auth/GetUsers',
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
        deleteUser: function (userId) {
            return $http.post(baseUrl + '/Auth/deleteUser',
                JSON.stringify(userId),
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
        lockUser: function (userId) {
            return $http.post(baseUrl + '/Auth/lockUser',
                JSON.stringify(userId),
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
        unLockUser: function (userId) {
            return $http.post(baseUrl + '/Auth/unLockUser',
                JSON.stringify(userId),
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
        resetPassword: function (data) {
            return $http.post(baseUrl + '/Auth/ResetPassword',
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
        initDropdown: function () {
            return this.get(baseUrl + '/Auth/InitDropdown');
        },
    };

}]);