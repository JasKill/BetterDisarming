using Smod2;
using Smod2.Attributes;

namespace BetterDisarming
{
	[PluginDetails(
	author = "Cyanox",
	name = "BetterDisarming",
	description = "Changes up how disarming works.",
	id = "cyan.better.disarming",
	version = "0.8",
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
			AddEventHandlers(new EventHandler(this));
			AddConfig(new Smod2.Config.ConfigSetting("bd_prohibit_doors", true, false, true, "Prevent cuffed players from accessing doors."));
			AddConfig(new Smod2.Config.ConfigSetting("bd_prohibit_elevators", true, false, true, "Prevent cuffed players from calling elevators."));
			AddConfig(new Smod2.Config.ConfigSetting("bd_check_interval", 1f, false, true, "How long before every escape check."));
			AddConfig(new Smod2.Config.ConfigSetting("bd_escape_list", "11:8,12:8,13:8,8:11", false, true, "A list of roles who can escape and what they turn into."));
		}
	}
}
