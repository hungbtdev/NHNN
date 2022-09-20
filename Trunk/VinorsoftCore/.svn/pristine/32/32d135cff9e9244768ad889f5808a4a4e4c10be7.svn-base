'user strict'
var app = angular.module('app', ['blockUI', 'ghiscoding.validation', 'pascalprecht.translate', 'toaster', 'ngAnimate', 'ngBootbox', 'ui.select2', 'ngSanitize', 'angular-uuid', 'ui.bootstrap', 'ui.utils.masks', '720kb.datepicker', 'moment-picker', 'textAngular', 'autoCompleteModule', 'datatables', 'datatables.bootstrap', 'datatables.colreorder', 'datatables.light-columnfilter', 'datatables.fixedcolumns','datatables.buttons']);

app.config(function ($translateProvider, blockUIConfig, $ngBootboxConfigProvider, $provide) {

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