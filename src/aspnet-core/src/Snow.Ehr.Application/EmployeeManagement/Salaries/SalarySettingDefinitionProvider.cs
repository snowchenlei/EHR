using Volo.Abp.Settings;

namespace Snow.Ehr.EmployeeManagement.Salaries
{
    /// <summary>
    /// SettingDefinitionProvider
    /// </summary>
    public class SalarySettingDefinitionProvider : SettingDefinitionProvider
    {
    /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        public override void Define(ISettingDefinitionContext context)
        {
            context.Add(
                new SettingDefinition(
                    SalarySettings.MaxPageSize,
                    "100",
                    isVisibleToClients: true
                )
            );
        }
    }
}
