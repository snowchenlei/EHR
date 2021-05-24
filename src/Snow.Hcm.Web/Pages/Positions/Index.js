; (function ($) {
    var l = abp.localization.getResource('Hcm');
    var _positionAppService = snow.hcm.controllers.positions.position;
    var _createModal = new abp.ModalManager('/Positions/CreateModal');
    var _editModal = new abp.ModalManager('/Positions/EditModal');

    $(function () {
        var _$wrapper = $('#PositionsWrapper');
        var _$table = _$wrapper.find('table');

        var _dataTable = _$table.DataTable(
            abp.libs.datatables.normalizeConfiguration({
                serverSide: true,
                paging: true,
                order: [[1, "asc"]],
                searching: true,
                scrollX: true,
                ajax: abp.libs.datatables.createAjax(_positionAppService.getList),
                columnDefs: [
                    {
                        title: l("Actions"),
                        rowAction: {
                            items: [
                                {
                                    text: l('Edit'),
                                    iconClass: 'fas fa-edit',
                                    visible: abp.auth.isGranted(
                                        'Hcm.Position.Update'
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
                                        'Hcm.Position.Delete'
                                    ),
                                    confirmMessage: function (data) {
                                        return l(
                                            'AreYouSure',
                                            data.record.employeeNumber
                                        );
                                    },
                                    action: function (data) {
                                        _positionAppService
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
                        title: l('Department'),
                        data: "department"
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

        _$wrapper.find('button[name=CreatePosition]').click(function (e) {
            e.preventDefault();
            _createModal.open();
        });
    });
})(jQuery);