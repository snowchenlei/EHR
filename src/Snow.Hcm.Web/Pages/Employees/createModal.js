abp.modals.EmployeeCreateModal = function () {
    function initModal(modalManager, args) {
        var $dateRangePicker = $('#Employee_Birthday');
        if ($('#sel_area').val() !== '') {
            $('#Employee_ProvinceId').val($("#sel_province").val());
            $('#Employee_CityId').val($("#sel_city").val());
            $('#Employee_AreaId').val($("#sel_area").val());
        }
        $('#sel_area').change(function () {
            $('#Employee_ProvinceId').val($("#sel_province").val());
            $('#Employee_CityId').val($("#sel_city").val());
            $('#Employee_AreaId').val($("#sel_area").val());
        });
        $('#Employee_IdCardNumber').change(function () {
            if ($('#Employee_IdCardNumber_error').length > 0) {
                return;
            }
            var idCardNumber = $(this).val();
            var birthday = getBirthdayByIdCard(idCardNumber);
            $dateRangePicker.data('daterangepicker').setStartDate(birthday);
            $dateRangePicker.data('daterangepicker').setEndDate(birthday);            
            var sex = getSexByIdCard(idCardNumber);
            if (sex !== '') {
                $('#Employee_Gender').val(sex === '女' ? 'Woman' : 'Man');
            }
        })
        $('#sel_position').change(function () {
            $('#Employee_PositionId').val($(this).val());
        })
        $("#sel_position").trigger("change");
        $dateRangePicker.daterangepicker({
            singleDatePicker: true,
            showDropdowns: true,
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
            startDate: moment(),
            minDate: moment().add(-100, 'years'),
            maxDate: moment(),
            firstDay: moment.localeData()._week.dow
        }, function (start, end, label) {
        });
    };

    return {
        initModal: initModal
    };
};