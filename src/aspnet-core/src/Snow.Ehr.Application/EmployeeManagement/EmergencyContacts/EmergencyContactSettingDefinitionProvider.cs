using Volo.Abp.Settings;

namespace Snow.Ehr.EmployeeManagement.EmergencyContacts
{
    /// <summary>
    /// SettingDefinitionProvider
    /// </summary>
    public class EmergencyContactSettingDefinitionProvider : SettingDefinitionProvider
    {
    /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        public override void Define(ISettingDefinitionContext context)
        {
            context.Add(
                new SettingDefinition(
                    EmergencyContactSettings.MaxPageSize,
                    "100",
                    isVisibleToClients: true
                )
            );
        }
    }
}
