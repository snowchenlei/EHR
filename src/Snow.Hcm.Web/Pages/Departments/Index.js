$(function () {
    var l = abp.localization.getResource('Hcm');
    var _departmentAppService = snow.hcm.employeeManagement.departments.department;
    var _createModal = new abp.ModalManager({ viewUrl: '/Departments/CreateModal', scriptUrl: '/Pages/Departments/CreateModal.js', });
    var _editModal = new abp.ModalManager({ viewUrl: '/Departments/EditModal', scriptUrl: '/Pages/Departments/EditModal.js', });

    var _dataTable = $('#DepartmentsTable').DataTable(
        abp.libs.datatables.normalizeConfiguration({
            serverSide: true,
            paging: true,
            order: [[1, "asc"]],
            searching: true,
            scrollX: true,
            ajax: abp.libs.datatables.createAjax(_departmentAppService.getList),
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
                                    _departmentAppService
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
                }
            ]
        })
    );

    _createModal.onResult(function () {
        _dataTable.ajax.reload();
    });

    $('#NewDepartmentButton').click(function (e) {
        e.preventDefault();
        _createModal.open();
    });
});