using System;
using Smod2;
using Smod2.API;
using Smod2.EventHandlers;
using Smod2.Events;
using System.Threading;

namespace BetterDisarming
{
	class RoundEventHandler : IEventHandlerRoundStart, IEventHandlerRoundEnd, IEventHandlerDoorAccess, IEventHandlerElevatorUse
	{
		private Plugin plugin;

		public bool roundStarted = false;

		public RoundEventHandler(Plugin plugin)
		{
			this.plugin = plugin;
		}

		public void OnRoundStart(RoundStartEvent ev)
		{
			roundStarted = true;
			Thread EscapeHandler = new Thread(new ThreadStart(() => new EscapeHandler(this, plugin)));
			EscapeHandler.Start();
		}

		public void OnRoundEnd(RoundEndEvent ev)
		{
			roundStarted = false;
		}

		public void OnDoorAccess(PlayerDoorAccessEvent ev)
		{
			if (plugin.GetConfigBool("bd_prohibit_doors"))
			{
				if (ev.Player.IsHandcuffed())
					ev.Allow = false;
			}
		}

		public void OnElevatorUse(PlayerElevatorUseEvent ev)
		{
			if (plugin.GetConfigBool("bd_prohibit_elevators"))
			{
				if (ev.Player.IsHandcuffed())
					ev.AllowUse = false;
			}
		}
	}
}
