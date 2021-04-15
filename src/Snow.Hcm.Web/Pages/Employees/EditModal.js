abp.modals.EmployeeEditModal = function () {
    function initModal(modalManager, args) {
        var $dateRangePicker = $('#Employee_Birthday');
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
            //startDate: moment(),
            minDate: moment().add(-100, 'years'),
            maxDate: moment(),
            firstDay: moment.localeData()._week.dow
        }, function (start, end, label) {
            console.log(start)
        });
        var birthday = moment($('#Employee_Birthday').val()).format('YYYY-MM-DD');
        $('#Employee_Birthday').val(birthday);
        $dateRangePicker.data('daterangepicker').setStartDate(birthday);
        $dateRangePicker.data('daterangepicker').setEndDate(birthday);
    };

    return {
        initModal: initModal
    };
};