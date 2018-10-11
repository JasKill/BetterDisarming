using System;
using Smod2;
using Smod2.API;
using Smod2.Attributes;

namespace BetterDisarming
{
	[PluginDetails(
	author = "Cyanox",
	name = "BetterDisarming",
	description = "Changes up how disarming works",
	id = "cyan.betterdisarming",
	version = "0.6",
	SmodMajor = 3,
	SmodMinor = 0,
	SmodRevision = 0
	)]
	public class BetterDisarming : Plugin
	{
		public override void OnDisable(){}

		public override void OnEnable(){}

		public override void Register()
		{
			this.AddEventHandlers(new RoundEventHandler(this));
			this.AddConfig(new Smod2.Config.ConfigSetting("bd_prohibit_doors", true, Smod2.Config.SettingType.BOOL, true, "Prevent cuffed players from accessing doors."));
			this.AddConfig(new Smod2.Config.ConfigSetting("bd_prohibit_elevators", true, Smod2.Config.SettingType.BOOL, true, "Prevent cuffed players from calling elevators."));
			this.AddConfig(new Smod2.Config.ConfigSetting("bd_change_ci_escape", true, Smod2.Config.SettingType.BOOL, true, "Makes cuffed CI turn into NTF."));
			this.AddConfig(new Smod2.Config.ConfigSetting("bd_change_ntf_escape", true, Smod2.Config.SettingType.BOOL, true, "Makes cuffed NTF turn into CI on escape."));
		}
	}
}
