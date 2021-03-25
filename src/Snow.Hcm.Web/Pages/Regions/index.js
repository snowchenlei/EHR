(function ($) {

    var l = abp.localization.getResource('SnowRegionManagement');

    var _regionAppService = snow.regionManagement.admin.regions.region;
    var _editModal = new abp.ModalManager(abp.appPath + 'Regions/EditModal');
    var _createModal = new abp.ModalManager(abp.appPath + 'Regions/CreateModal');

    $(function () {

        var _$wrapper = $('#RegionsWrapper');
        var _$table = _$wrapper.find('table');
        var _dataTable = _$table.DataTable(abp.libs.datatables.normalizeConfiguration({
            order: [[1, "asc"]],
            processing: true,
            serverSide: true,
            scrollX: true,
            paging: true,
            ajax: abp.libs.datatables.createAjax(_regionAppService.getList),
            columnDefs: [
                {
                    rowAction: {
                        items:
                            [
                                {
                                    text: l('Edit'),
                                    visible: abp.auth.isGranted('SnowRegionManagement.Regions.Update'),
                                    action: function (data) {
                                        _editModal.open({
                                            id: data.record.id
                                        });
                                    }
                                },
                                {
                                    text: l('Delete'),
                                    visible: abp.auth.isGranted('SnowRegionManagement.Regions.Delete'),
                                    confirmMessage: function (data) { return l('RegionDeletionConfirmationMessage', data.record.name); },
                                    action: function (data) {
                                        _regionAppService
                                            .delete(data.record.id)
                                            .then(function () {
                                                _dataTable.ajax.reload();
                                            });
                                    }
                                }
                            ]
                    }
                },
                {
                    data: "name"
                },
                {
                    data: "level"
                }
            ]
        }));

        _createModal.onResult(function () {
            _dataTable.ajax.reload();
        });

        _editModal.onResult(function () {
            _dataTable.ajax.reload();
        });

        _$wrapper.find('button[name=CreateRegion]').click(function (e) {
            e.preventDefault();
            _createModal.open();
        });
    });

})(jQuery);
