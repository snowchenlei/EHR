$(function () {
    var l = abp.localization.getResource('Hcm');
    var employeeAppService = snow.hcm.employeeManagement.employees.employee;

    var _dataTable = $('#EmployeesTable').DataTable(
        abp.libs.datatables.normalizeConfiguration({
            serverSide: true,
            paging: true,
            order: [[1, "asc"]],
            searching: false,
            scrollX: true,
            ajax: abp.libs.datatables.createAjax(employeeAppService.getList),
            columnDefs: [
                {
                    title: l("Actions"),
                    rowAction: {
                        items: [
                            {
                                text: l('Edit'),
                                visible: abp.auth.isGranted(
                                    'Hcm.Employee.Update'
                                ),
                                action: function (data) {
                                    _editModal.open({
                                        id: data.record.id,
                                    });
                                },
                            },
                            {
                                text: l('Delete'),
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
                                    employeeAppService
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
    var createModal = new abp.ModalManager({ viewUrl: '/Employees/CreateModal', scriptUrl: '/Pages/Employees/CreateModal.js', });

    createModal.onResult(function () {
        _dataTable.ajax.reload();
    });

    $('#NewEmployeeButton').click(function (e) {
        e.preventDefault();
        createModal.open();
    });
});