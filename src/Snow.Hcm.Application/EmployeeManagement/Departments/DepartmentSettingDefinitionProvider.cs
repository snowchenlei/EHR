using Volo.Abp.Settings;

namespace Snow.Hcm.EmployeeManagement.Departments
{
    /// <summary>
    /// SettingDefinitionProvider
    /// </summary>
    public class DepartmentSettingDefinitionProvider : SettingDefinitionProvider
    {
    /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        public override void Define(ISettingDefinitionContext context)
        {
            context.Add(
                new SettingDefinition(
                    DepartmentSettings.MaxPageSize,
                    "100",
                    isVisibleToClients: true
                )
            );
        }
    }
}
