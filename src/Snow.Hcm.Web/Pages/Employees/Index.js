; (function ($) {
    var l = abp.localization.getResource('Hcm');
    var _employeeAppService = snow.hcm.controllers.employees.employee;
    var _createModal = new abp.ModalManager({
        viewUrl: '/Employees/CreateModal',
        modalClass: 'EmployeeCreateModal',
        scriptUrl: '/Pages/Employees/CreateModal.js',
    });
    var _editModal = new abp.ModalManager({
        viewUrl: '/Employees/EditModal',
        modalClass: 'EmployeeEditModal',
        //scriptUrl: '/Pages/Employees/EditModal.js',
    });

    $(function () {
        var _$wrapper = $('#EmployeesWrapper');
        var _$table = _$wrapper.find('table');

        var _dataTable = _$table.DataTable(
            abp.libs.datatables.normalizeConfiguration({
                serverSide: true,
                paging: true,
                order: [[1, "asc"]],
                searching: true,
                scrollX: true,
                ajax: abp.libs.datatables.createAjax(_employeeAppService.getList),
                columnDefs: [
                    {
                        title: l("Actions"),
                        rowAction: {
                            items: [
                                {
                                    text: l('Edit'),
                                    iconClass: 'fas fa-edit',
                                    visible: abp.auth.isGranted(
                                        'Hcm.Employee.Update'
                                    ),
                                    action: function (data) {
                                        window.location.href = '/Employees/Edit/?id=' + data.record.id;
                                    },
                                },
                                {
                                    text: l('Edit'),
                                    iconClass: 'fas fa-edit',
                                    action: function (data) {
                                        // TODO:转正
                                    },
                                },
                                {
                                    text: l('Edit'),
                                    iconClass: 'fas fa-edit',
                                    action: function (data) {
                                        // TODO:升职
                                    },
                                },
                                {
                                    text: l('Edit'),
                                    iconClass: 'fas fa-edit',
                                    action: function (data) {
                                        // TODO:离职
                                    },
                                },
                                {
                                    text: l('Delete'),
                                    iconClass: 'fas fa-trash',
                                    visible: abp.auth.isGranted(
                                        'Hcm.Employee.Delete'
                                    ),
                                    confirmMessage: function (data) {
                                        return l(
                                            'AreYouSure',
                                            data.record.employeeNumber
                                        );
                                    },
                                    action: function (data) {
                                        _employeeAppService
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
                        title: l('EmployeeNumber'),
                        data: "employeeNumber"
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
                        title: l('IdCardNumber'),
                        data: "idCardNumber"
                    },
                    {
                        title: l('Age'),
                        data: "age"
                    },
                    {
                        title: l('Gender'),
                        data: "gender"
                    },
                    {
                        title: l('BirthDay'),
                        data: "birthDay",
                        render: function (data) {
                            return data.substring(0, data.indexOf(' '));
                        }
                    },
                    {
                        title: l('JoinDate'),
                        data: "joinDate",
                        render: function (data) {
                            return data.substring(0, data.indexOf(' '));
                        }
                    }
                ]
            })
        );

        _createModal.onResult(function () {
            _dataTable.ajax.reload();
        });
        _createModal.onOpen(function () {
            abp.ui.clearBusy();
        });
        _editModal.onResult(function () {            
            _dataTable.ajax.reload();
        });

        _$wrapper.find('button[name=CreateEmployee]').click(function (e) {
            e.preventDefault();
            abp.ui.setBusy('#EmployeesWrapper');
            _createModal.open();
        });
    });
})(jQuery);