; (function ($) {
    var l = abp.localization.getResource('Hcm');
    var _departmentAppService = snow.hcm.controllers.departments.department;
    var _createModal = new abp.ModalManager('/Departments/CreateModal');
    var _editModal = new abp.ModalManager('/Departments/EditModal');

    $(function () {
        var _$wrapper = $('#DepartmentsWrapper');
        var _$table = _$wrapper.find('table');

        var _dataTable = _$table.DataTable(
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
                                        'Hcm.Department.Update'
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
                                        'Hcm.Department.Delete'
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
        _editModal.onResult(function () {
            _dataTable.ajax.reload();
        });

        _$wrapper.find('button[name=CreateDepartment]').click(function (e) {
            e.preventDefault();
            _createModal.open();
        });
    });
})(jQuery);