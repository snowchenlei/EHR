$(function () {
    var l = abp.localization.getResource('Hcm');
    var employee = snow.hcm.employeeManagement.employees.employee;

    var dataTable = $('#EmployeesTable').DataTable(
        abp.libs.datatables.normalizeConfiguration({
            serverSide: true,
            paging: true,
            order: [[1, "asc"]],
            searching: false,
            scrollX: true,
            ajax: abp.libs.datatables.createAjax(employee.getList),
            columnDefs: [
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
                    data: "gender",
                    render: function (data) {
                        return l('Enum:Gender:' + data);
                    }
                },
                {
                    title: l('BirthDay'),
                    data: "birthDay",
                    render: function (data) {
                        return luxon
                            .DateTime
                            .fromISO(data, {
                                locale: abp.localization.currentCulture.name
                            }).toLocaleString(luxon.DateTime.DATETIME_SHORT);
                    }
                },
                {
                    title: l('JoinDate'),
                    data: "joinDate",
                    render: function (data) {
                        return luxon
                            .DateTime
                            .fromISO(data, {
                                locale: abp.localization.currentCulture.name
                            }).toLocaleString(luxon.DateTime.DATETIME_SHORT);
                    }
                }
            ]
        })
    );
});