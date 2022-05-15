using Volo.Abp.Settings;

namespace Snow.Ehr.EmployeeManagement.Contracts
{
    /// <summary>
    /// SettingDefinitionProvider
    /// </summary>
    public class ContractSettingDefinitionProvider : SettingDefinitionProvider
    {
    /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        public override void Define(ISettingDefinitionContext context)
        {
            context.Add(
                new SettingDefinition(
                    ContractSettings.MaxPageSize,
                    "100",
                    isVisibleToClients: true
                )
            );
        }
    }
}
