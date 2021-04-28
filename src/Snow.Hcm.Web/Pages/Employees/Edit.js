﻿; (function ($) {
    var employeeId;
    var l = abp.localization.getResource('Hcm');
    var _emergencyContactAppService = snow.hcm.controllers.employees.emergencyContact;
    var _workExperienceAppService = snow.hcm.controllers.employees.workExperience;
    var _createEmergencyContactModal = new abp.ModalManager({
        viewUrl: '/Employees/EmergencyContacts/CreateModal',
        modalClass: 'EmergencyContactCreateModal',
        //scriptUrl: '/Pages/Employees/CreateModal.js',
    });
    var _editEmergencyContactModal = new abp.ModalManager({
        viewUrl: '/Employees/EmergencyContacts/EditModal',
        modalClass: 'EmergencyContactEditModal',
        //scriptUrl: '/Pages/Employees/EditModal.js',
    });
    var _createWorkExperienceModal = new abp.ModalManager({
        viewUrl: '/Employees/WorkExperiences/CreateModal',
        modalClass: 'WorkExperienceCreateModal',
        scriptUrl: '/Pages/WorkExperiences/CreateModal.js',
    });
    var _editWorkExperienceModal = new abp.ModalManager({
        viewUrl: '/Employees/WorkExperiences/EditModal',
        modalClass: 'WorkExperienceEditModal',
        scriptUrl: '/Pages/WorkExperience/EditModal.js',
    });
    $(function () {
        var $dateRangePicker = $('#Employee_Birthday');
        employeeId = $('#Employee_Id').val();
        $('#sel_area').change(function () {
            $('#Employee_ProvinceId').val($("#sel_province").val());
            $('#Employee_CityId').val($("#sel_city").val());
            $('#Employee_AreaId').val($("#sel_area").val());
        });
        $dateRangePicker.daterangepicker({
            singleDatePicker: true,
            showDropdowns: true,
            //autoUpdateInput: false,
            drops: "up",
            autoApply: true,
            locale: {
                format: "YYYY-MM-DD",
                separator: " - ",
                applyLabel: '确定',
                cancelLabel: '取消',
                fromLabel: '从',
                toLabel: '到',
                weekLabel: 'W',
                customRangeLabel: 'Custom Range',
                daysOfWeek: ['日', '一', '二', '三', '四', '五', '六'],
                monthNames: [
                    '一月', '二月', '三月', '四月', '五月', '六月',
                    '七月', '八月', '九月', '十月', '十一月', '十二月'
                ],
            },
            startDate: moment($('#Employee_Birthday').val()),//moment(),
            minDate: moment().add(-100, 'years'),
            maxDate: moment(),
            firstDay: moment.localeData()._week.dow
        }, function (start, end, label) {
            console.log(start)
        });
        //var birthday = moment($('#Employee_Birthday').val()).format('YYYY-MM-DD');
        //$('#Employee_Birthday').val(birthday);
        //$dateRangePicker.data('daterangepicker').setStartDate(birthday);
        //$dateRangePicker.data('daterangepicker').setEndDate(birthday);
        loadEmergencyContactTable();
        loadWorkExperienceTable();
    });
    /**
     * Load EmergencyContact Table
     */
    function loadEmergencyContactTable() {
        var _$emergencyContactWrapper = $('#contact');
        var _$emergencyContactTable = _$emergencyContactWrapper.find('table');

        var _emergencyContactTable = _$emergencyContactTable.DataTable(
            abp.libs.datatables.normalizeConfiguration({
                serverSide: true,
                paging: true,
                order: [[1, "asc"]],
                searching: true,
                scrollX: true,
                ajax: abp.libs.datatables.createAjax(function (input) {
                    return _emergencyContactAppService.getList(employeeId, input);
                }),
                columnDefs: [
                    {
                        title: l("Actions"),
                        rowAction: {
                            items: [
                                {
                                    text: l('Edit'),
                                    visible: abp.auth.isGranted(
                                        'Hcm.EmergencyContact.Update'
                                    ),
                                    action: function (data) {
                                        _editEmergencyContactModal.open({
                                            employeeId: employeeId,
                                            emergencyContactId: data.record.id
                                        });
                                    },
                                },
                                {
                                    text: l('Delete'),
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
                                                _emergencyContactTable.ajax.reload();
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

        _createEmergencyContactModal.onResult(function () {
            _emergencyContactTable.ajax.reload();
        });
        _editEmergencyContactModal.onResult(function () {
            _emergencyContactTable.ajax.reload();
        });

        _$emergencyContactWrapper.find('button[name=CreateEmergencyContact]').click(function (e) {
            e.preventDefault();
            _createEmergencyContactModal.open({
                employeeId: employeeId
            });
        });
    }
    /**
     * Load EmergencyContact Table
     */
    function loadWorkExperienceTable() {
        var _$wrapper = $('#contact');
        var _$table = _$wrapper.find('table');

        var _dataTable = _$table.DataTable(
            abp.libs.datatables.normalizeConfiguration({
                serverSide: true,
                paging: true,
                order: [[1, "asc"]],
                searching: true,
                scrollX: true,
                ajax: abp.libs.datatables.createAjax(function (input) {
                    return _emergencyContactAppService.getList(employeeId, input);
                }),
                columnDefs: [
                    {
                        title: l("Actions"),
                        rowAction: {
                            items: [
                                {
                                    text: l('Edit'),
                                    visible: abp.auth.isGranted(
                                        'Hcm.EmergencyContact.Update'
                                    ),
                                    action: function (data) {
                                        _editWorkExperienceModal.open({
                                            employeeId: employeeId,
                                            workExperienceId: data.record.id
                                        });
                                    },
                                },
                                {
                                    text: l('Delete'),
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
                                        _workExperienceAppService
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

        _createWorkExperienceModal.onResult(function () {
            _dataTable.ajax.reload();
        });
        _editEmergencyContactModal.onResult(function () {
            _dataTable.ajax.reload();
        });

        _$workExperienceWrapper.find('button[name=CreateWorkExperience]').click(function (e) {
            e.preventDefault();
            _createWorkExperienceModal.open({
                employeeId: employeeId
            });
        });
    }

})(jQuery);