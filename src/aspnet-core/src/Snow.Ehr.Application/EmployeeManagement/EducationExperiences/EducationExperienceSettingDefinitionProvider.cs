using Volo.Abp.Settings;

namespace Snow.Ehr.EmployeeManagement.EducationExperiences
{
    /// <summary>
    /// SettingDefinitionProvider
    /// </summary>
    public class EducationExperienceSettingDefinitionProvider : SettingDefinitionProvider
    {
    /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        public override void Define(ISettingDefinitionContext context)
        {
            context.Add(
                new SettingDefinition(
                    EducationExperienceSettings.MaxPageSize,
                    "100",
                    isVisibleToClients: true
                )
            );
        }
    }
}
