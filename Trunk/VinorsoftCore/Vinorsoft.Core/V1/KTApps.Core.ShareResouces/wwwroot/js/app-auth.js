'user strict'
var app = angular.module('appAuth', ['blockUI', 'ghiscoding.validation', 'pascalprecht.translate', 'toaster', 'ngAnimate', 'ngBootbox', 'ui.select2', 'ngSanitize', 'angular-uuid', 'ui.bootstrap']);

app.config(function ($translateProvider, blockUIConfig, $ngBootboxConfigProvider) {

    $ngBootboxConfigProvider.addLocale('vi', { OK: 'OK', CANCEL: 'Hủy', CONFIRM: 'Xác nhận' });

    $ngBootboxConfigProvider.setDefaultLocale('vi');


    $translateProvider.useStaticFilesLoader({
        prefix: subDomain + '/lib/angular-validation/locales/',
        suffix: '.json'
    })
        .useSanitizeValueStrategy('escape')
        .useMissingTranslationHandlerLog();

    angular.lowercase = angular.$$lowercase;
    blockUIConfig.message = 'Vui lòng chờ...';

    // define translation maps you want to use on startup
    $translateProvider.preferredLanguage('en');
});