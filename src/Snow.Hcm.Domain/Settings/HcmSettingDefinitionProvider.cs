using Volo.Abp.Settings;

namespace Snow.Hcm.Settings
{
    public class HcmSettingDefinitionProvider : SettingDefinitionProvider
    {
        public override void Define(ISettingDefinitionContext context)
        {
            //Define your own settings here. Example:
            //context.Add(new SettingDefinition(HcmSettings.MySetting1));
        }
    }
}
