using Volo.Abp.Settings;

namespace Snow.Ehr.EmployeeManagement.Employees
{
    /// <summary>
    /// SettingDefinitionProvider
    /// </summary>
    public class EmployeeSettingDefinitionProvider : SettingDefinitionProvider
    {
    /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        public override void Define(ISettingDefinitionContext context)
        {
            context.Add(
                new SettingDefinition(
                    EmployeeSettings.MaxPageSize,
                    "100",
                    isVisibleToClients: true
                )
            );
        }
    }
}
