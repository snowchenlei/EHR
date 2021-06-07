using System;
using System.Threading.Tasks;
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
        private readonly IRepository<Employee, Guid> _employeeRepository;

        public HcmDataSeederContributor(
            IRepository<Employee, Guid> employeeRepository, IGuidGenerator guidGenerator)
        {
            _employeeRepository = employeeRepository;
            _guidGenerator = guidGenerator;
        }

        public async Task SeedAsync(DataSeedContext context)
        {

            if (await _employeeRepository.GetCountAsync() <= 0)
            {
                var employee = new Employee()
                {
                    EmployeeNumber = _guidGenerator.Create().ToString("N"),
                    Name = "张三",
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
