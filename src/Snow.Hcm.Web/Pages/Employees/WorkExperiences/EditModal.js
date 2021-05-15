abp.modals.WorkExperienceEditModal = function () {
    function initModal(modalManager, args) {
        var $dateRangePicker = $('#WorkExperience_WorkTime');
        $dateRangePicker.daterangepicker({
            showDropdowns: true,
            drops: "up",
            autoApply: true,
            locale: {
                format: "YYYY-MM-DD",
                separator: " ~ ",
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
            minDate: moment().add(-100, 'years'),
            maxDate: moment(),
            firstDay: moment.localeData()._week.dow
        }, function (start, end, label) {
        });
    }

    return {
        initModal: initModal
    };
}