; (function ($) {
    var employeeId;
    var l = abp.localization.getResource('Hcm');
    var _emergencyContactAppService = snow.hcm.controllers.employees.emergencyContact;
    var _workExperienceAppService = snow.hcm.controllers.employees.workExperience;
    var _educationExperienceAppService = snow.hcm.controllers.employees.educationExperience;
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
        scriptUrl: '/Pages/Employees/WorkExperiences/CreateModal.js'
    });
    var _editWorkExperienceModal = new abp.ModalManager({
        viewUrl: '/Employees/WorkExperiences/EditModal',
        modalClass: 'WorkExperienceEditModal',
        scriptUrl: '/Pages/Employees/WorkExperiences/EditModal.js'
    });
    var _createEducationExperienceModal = new abp.ModalManager({
        viewUrl: '/Employees/EducationExperiences/CreateModal',
        modalClass: 'EducationExperienceCreateModal',
        scriptUrl: '/Pages/Employees/EducationExperiences/CreateModal.js'
    });
    var _editEducationExperienceModal = new abp.ModalManager({
        viewUrl: '/Employees/EducationExperiences/EditModal',
        modalClass: 'EducationExperienceEditModal',
        scriptUrl: '/Pages/Employees/EducationExperiences/EditModal.js'
    });
    $(function () {
        var _$wrapper = $('#EmployeesWrapper');

        var $dateRangePicker = _$wrapper.find('#Employee_Birthday');
        employeeId = _$wrapper.find('#Employee_Id').val();
        _$wrapper.find('#sel_area').change(function () {
            $('#Employee_ProvinceId').val($("#sel_province").val());
            $('#Employee_CityId').val($("#sel_city").val());
            $('#Employee_AreaId').val($("#sel_area").val());
        });
        _$wrapper.find('#sel_position').change(function () {
            $('#Employee_PositionId').val($(this).val());
        })
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
        var _$form = _$wrapper.find('#basic').find('form');
        _$form.abpAjaxForm();
        //$form.on("submit", function (event) {
        //    event.preventDefault();

        //    var $btn = $(this).find('button');
        //    $btn.attr('disabled', 'disabled');
        //    var url = $(this).attr("action");

        //    var formData = $(this).serialize();
        //    abp.ajax({
        //        type: 'POST',
        //        contentType: 'application/x-www-form-urlencoded; charset=UTF-8',
        //        headers: {
        //            'X-Requested-With': 'XMLHttpRequest'
        //        },
        //        url: url,
        //        data: formData,
        //        beforeSend: function (xhr) { //<--- This is important              
        //            $btn.attr('disabled', 'true');
        //            $btn.html("Please wait");
        //            xhr.setRequestHeader("RequestVerificationToken",
        //                $('input:hidden[name="__RequestVerificationToken"]').val());
        //        },
        //    }).then(function (data) {
        //        abp.notify.success('Success');
        //    }).catch(function (ex) {
        //        abp.notify.error(ex);
        //    });
        //});

        if (abp.auth.isGranted('Hcm.EmergencyContact')) {
            loadEmergencyContactTable();
        }
        if (abp.auth.isGranted('Hcm.WorkExperience')) {
            loadWorkExperienceTable();
        }
        if (abp.auth.isGranted('Hcm.EducationExperience')) {
            loadEducationExperienceTable();
        }
    });
    /**
     * Load EmergencyContact Table
     */
    function loadEmergencyContactTable() {
        var _$wrapper = $('#emergencyContact');
        var _$table = _$wrapper.find('table');

        var _dataTable = _$table.DataTable(
            abp.libs.datatables.normalizeConfiguration({
                serverSide: true,
                paging: true,
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
                                    iconClass: 'fas fa-edit',
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

        _createEmergencyContactModal.onResult(function () {
            _dataTable.ajax.reload();
        });
        _editEmergencyContactModal.onResult(function () {
            _dataTable.ajax.reload();
        });

        _$wrapper.find('button[name=CreateEmergencyContact]').click(function (e) {
            e.preventDefault();
            _createEmergencyContactModal.open({
                employeeId: employeeId
            });
        });
    }
    /**
     * Load WorkExperience Table
     */
    function loadWorkExperienceTable() {
        var _$wrapper = $('#workExperience');
        var _$table = _$wrapper.find('table');

        var _dataTable = _$table.DataTable(
            abp.libs.datatables.normalizeConfiguration({
                serverSide: true,
                paging: true,
                searching: true,
                scrollX: true,
                ajax: abp.libs.datatables.createAjax(function (input) {
                    return _workExperienceAppService.getList(employeeId, input);
                }),
                columnDefs: [
                    {
                        title: l("Actions"),
                        rowAction: {
                            items: [
                                {
                                    text: l('Edit'),
                                    iconClass: 'fas fa-edit',
                                    visible: abp.auth.isGranted(
                                        'Hcm.WorkExperience.Update'
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
                                    iconClass: 'fas fa-trash',
                                    visible: abp.auth.isGranted(
                                        'Hcm.WorkExperience.Delete'
                                    ),
                                    confirmMessage: function (data) {
                                        return l(
                                            'AreYouSure',
                                            data.record.employeeNumber
                                        );
                                    },
                                    action: function (data) {
                                        _workExperienceAppService
                                            .delete(employeeId, data.record.id)
                                            .then(function () {
                                                _dataTable.ajax.reload();
                                                abp.notify.success(l('Deleted'));
                                            });
                                    },
                                }
                            ]
                        }
                    },
                    {
                        title: l('CompanyName'),
                        data: "companyName"
                    },
                    {
                        title: l('Post'),
                        data: "post"
                    },
                    {
                        title: l('WorkTime'),
                        render: function(data, type, row) {
                            return moment(row.startTime).format('YYYY-MM-DD') + ' ~ ' + moment(row.endTime).format('YYYY-MM-DD');
                        }
                    }
                ]
            })
        );

        _createWorkExperienceModal.onResult(function () {
            _dataTable.ajax.reload();
        });
        _editWorkExperienceModal.onResult(function () {
            _dataTable.ajax.reload();
        });

        _$wrapper.find('button[name=CreateWorkExperience]').click(function (e) {
            e.preventDefault();
            _createWorkExperienceModal.open({
                employeeId: employeeId
            });
        });
    }
    /**
     * Load EducationExperience Table
     */
    function loadEducationExperienceTable() {
        var _$wrapper = $('#educationExperience');
        var _$table = _$wrapper.find('table');

        var _dataTable = _$table.DataTable(
            abp.libs.datatables.normalizeConfiguration({
                serverSide: true,
                paging: true,
                searching: true,
                scrollX: true,
                ajax: abp.libs.datatables.createAjax(function (input) {
                    return _educationExperienceAppService.getList(employeeId, input);
                }),
                columnDefs: [
                    {
                        title: l("Actions"),
                        rowAction: {
                            items: [
                                {
                                    text: l('Edit'),
                                    iconClass: 'fas fa-edit',
                                    visible: abp.auth.isGranted(
                                        'Hcm.EducationExperience.Update'
                                    ),
                                    action: function (data) {
                                        _editEducationExperienceModal.open({
                                            employeeId: employeeId,
                                            educationExperienceId: data.record.id
                                        });
                                    },
                                },
                                {
                                    text: l('Delete'),
                                    iconClass: 'fas fa-trash',
                                    visible: abp.auth.isGranted(
                                        'Hcm.EducationExperience.Delete'
                                    ),
                                    confirmMessage: function (data) {
                                        return l(
                                            'AreYouSure',
                                            data.record.employeeNumber
                                        );
                                    },
                                    action: function (data) {
                                        _educationExperienceAppService
                                            .delete(employeeId, data.record.id)
                                            .then(function () {
                                                _dataTable.ajax.reload();
                                                abp.notify.success(l('Deleted'));
                                            });
                                    },
                                }
                            ]
                        }
                    },
                    {
                        title: l('SchoolName'),
                        data: "schoolName"
                    },
                    {
                        title: l('Specialty'),
                        data: "specialty"
                    },
                    {
                        title: l('Degree'),
                        data: "degree"
                    },
                    {
                        title: l('WorkTime'),
                        render: function (data, type, row) {
                            return moment(row.startTime).format('YYYY-MM-DD') + ' ~ ' + moment(row.endTime).format('YYYY-MM-DD');
                        }
                    }
                ]
            })
        );

        _createEducationExperienceModal.onResult(function () {
            _dataTable.ajax.reload();
        });
        _editEducationExperienceModal.onResult(function () {
            _dataTable.ajax.reload();
        });

        _$wrapper.find('button[name=CreateEducationExperience]').click(function (e) {
            e.preventDefault();
            _createEducationExperienceModal.open({
                employeeId: employeeId
            });
        });
    }
})(jQuery);