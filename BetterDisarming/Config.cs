using Exiled.API.Interfaces;
using Exiled.Loader;

namespace BetterDisarming
{
    public class Config : IConfig
    {
        public bool enabled;
        public float checkInterval;
        public string escapelist;

        public string Prefix { get; }
        public bool IsEnabled { get; set; }

        public void Reload()
        {
            enabled = PluginManager.YamlConfig.GetBool("bd_enabled", false);
            checkInterval = PluginManager.YamlConfig.GetFloat("bd_check_interval", 1);
            escapelist = PluginManager.YamlConfig.GetString("bd_escape_list", "15:8,13:8,4:8,11:8,12:8,8:13");
        }
    }
}
