using Volo.Abp.Settings;

namespace Snow.Ehr.EmployeeManagement.WorkExperiences
{
    /// <summary>
    /// SettingDefinitionProvider
    /// </summary>
    public class WorkExperienceSettingDefinitionProvider : SettingDefinitionProvider
    {
    /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        public override void Define(ISettingDefinitionContext context)
        {
            context.Add(
                new SettingDefinition(
                    WorkExperienceSettings.MaxPageSize,
                    "100",
                    isVisibleToClients: true
                )
            );
        }
    }
}
