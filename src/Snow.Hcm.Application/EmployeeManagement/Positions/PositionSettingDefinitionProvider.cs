using Volo.Abp.Settings;

namespace Snow.Hcm.EmployeeManagement.Positions
{
    /// <summary>
    /// SettingDefinitionProvider
    /// </summary>
    public class PositionSettingDefinitionProvider : SettingDefinitionProvider
    {
    /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        public override void Define(ISettingDefinitionContext context)
        {
            context.Add(
                new SettingDefinition(
                    PositionSettings.MaxPageSize,
                    "100",
                    isVisibleToClients: true
                )
            );
        }
    }
}
