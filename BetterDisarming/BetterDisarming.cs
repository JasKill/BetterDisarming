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
	version = "0.1",
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
		}
	}
}
