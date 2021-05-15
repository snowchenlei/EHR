; (function ($) {
    var l = abp.localization.getResource('Hcm');
    var _emergencyContactAppService = snow.hcm.controllers.employees.emergencyContact;
    var _createModal = new abp.ModalManager({
        viewUrl: '/EmergencyContacts/CreateModal',
        modalClass: 'EmergencyContactCreateModal',
        //scriptUrl: '/Pages/Employees/CreateModal.js',
    });
    var _editModal = new abp.ModalManager({
        viewUrl: '/EmergencyContacts/EditModal',
        modalClass: 'EmergencyContactEditModal',
        //scriptUrl: '/Pages/Employees/EditModal.js',
    });

    $(function () {
        var _$wrapper = $('#EmergencyContactsWrapper');
        var _$table = _$wrapper.find('table');

        var _dataTable = _$table.DataTable(
            abp.libs.datatables.normalizeConfiguration({
                serverSide: true,
                paging: true,
                order: [[1, "asc"]],
                searching: true,
                scrollX: true,
                ajax: abp.libs.datatables.createAjax(_emergencyContactAppService.getList),
                columnDefs: [
                    {
                        title: l("Actions"),
                        rowAction: {
                            items: [
                                {
                                    text: l('Edit'),
                                    iconClass: 'fas fa-edit',
                                    visible: abp.auth.isGranted(
                                        'Hcm.EmergencyContact.Update'
                                    ),
                                    action: function (data) {
                                        _editModal.open({
                                            id: data.record.id,
                                        });
                                    },
                                },
                                {
                                    text: l('Delete'),
                                    iconClass: 'fas fa-trash',
                                    visible: abp.auth.isGranted(
                                        'Hcm.EmergencyContact.Delete'
                                    ),
                                    confirmMessage: function (data) {
                                        return l(
                                            'AreYouSure',
                                            data.record.employeeNumber
                                        );
                                    },
                                    action: function (data) {
                                        _emergencyContactAppService
                                            .delete(data.record.id)
                                            .then(function () {
                                                _dataTable.ajax.reload();
                                            });
                                    },
                                }
                            ]
                        }
                    },
                    {
                        title: l('Name'),
                        data: "name"
                    },
                    {
                        title: l('PhoneNumber'),
                        data: "phoneNumber"
                    },
                    {
                        title: l('Relation'),
                        data: "relation"
                    }
                ]
            })
        );

        _createModal.onResult(function () {
            _dataTable.ajax.reload();
        });
        _editModal.onResult(function () {
            _dataTable.ajax.reload();
        });

        _$wrapper.find('button[name=CreateEmergencyContact]').click(function (e) {
            e.preventDefault();
            _createModal.open();
        });
    });
})(jQuery);