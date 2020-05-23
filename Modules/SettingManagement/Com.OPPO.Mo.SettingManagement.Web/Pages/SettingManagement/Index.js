(function ($) {
    var l = abp.localization.getResource('MoSettingManagement');

    $(document).on("AbpSettingSaved", function () {
        abp.notify.success(l("SuccessfullySaved"));
    });
})(jQuery);