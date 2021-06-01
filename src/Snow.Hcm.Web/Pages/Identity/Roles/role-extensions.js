(function ($) {
    var l = abp.localization.getResource('AbpIdentity');

    var _organizationUnitModal = new abp.ModalManager(
        abp.appPath + 'OrganizationUnitManagement/OrganizationUnitManagementModal'
    );
var organizationUnitAction = {
    text: l('OrganizationUnit'),
    action: function (data) {
        _organizationUnitModal.open({
            roleId: data.record.id
        });
    }
};

abp.ui.extensions.entityActions
    .get('identity.role')
    .addContributor(function (actionList) {
        actionList.addTail(organizationUnitAction);
    });
})(jQuery);
