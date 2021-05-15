using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Snow.Hcm.EmployeeManagement.Departments;
using Snow.Hcm.EmployeeManagement.EmergencyContacts;
using Snow.Hcm.EmployeeManagement.Employees;
using Snow.Hcm.Extension;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Guids;

namespace Snow.Hcm.Data
{
    public class HcmDataSeederContributor : IDataSeedContributor, ITransientDependency
    {
        private readonly IGuidGenerator _guidGenerator;
        private readonly IRepository<Department, Guid> _departmentRepository;
        private readonly IRepository<Employee, Guid> _employeeRepository;

        public HcmDataSeederContributor(IRepository<Department, Guid> departmentRepository, 
            IRepository<Employee, Guid> employeeRepository, IGuidGenerator guidGenerator)
        {
            _departmentRepository = departmentRepository;
            _employeeRepository = employeeRepository;
            _guidGenerator = guidGenerator;
        }

        public async Task SeedAsync(DataSeedContext context)
        {
            if (await _departmentRepository.GetCountAsync() <= 0)
            {
                await _departmentRepository.InsertManyAsync(new Department[]
                {
                    new Department()
                    {
                        Name = "信息技术部"
                    },
                    new Department()
                    {
                        Name = "人力资源部"
                    },
                    new Department()
                    {
                        Name = "财务部"
                    }
                }, true);
            }

            if (await _employeeRepository.GetCountAsync() <= 0)
            {
                Department department = await _departmentRepository
                    .FirstAsync();
                var employee = new Employee()
                {
                    EmployeeNumber = _guidGenerator.Create().ToString("N"),
                    Name = "张三",
                    Department = department,
                    PhoneNumber = "13856580566",
                    IdCardNumber = "340111199510134503",
                    Birthday = new DateTime(1995, 10, 13),
                    IsGregorianCalendar = true,
                    Gender = Gender.Man,
                    MaritalStatus = MaritalStatus.Unmarried,
                    JoinDate = DateTime.Now,
                    PoliticalStatus = PoliticalStatus.PublicPeople
                };
                employee.Age = employee.Birthday.GetAgeByBirthday();
                await _employeeRepository
                    .InsertAsync(employee);
            }
        }
    }
}
