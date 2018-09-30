using System;
using Smod2;
using Smod2.API;
using Smod2.EventHandlers;
using Smod2.Events;

namespace BetterDisarming
{
	class RoundEventHandler : IEventHandlerCheckEscape, IEventHandlerDoorAccess, IEventHandlerElevatorUse
	{
		private Plugin plugin;

		public RoundEventHandler(Plugin plugin)
		{
			this.plugin = plugin;
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

		public void OnCheckEscape(PlayerCheckEscapeEvent ev)
		{
			if (ev.Player.TeamRole.Role.Equals(Role.CHAOS_INSUGENCY) && ev.Player.IsHandcuffed())
			{
				if (plugin.GetConfigBool("bd_change_ci_escape"))
				{
					ev.Player.ChangeRole(Role.NTF_LIEUTENANT);
				}
			}
			if (ev.Player.TeamRole.Role.Equals(Team.NINETAILFOX) && ev.Player.IsHandcuffed())
			{
				if (plugin.GetConfigBool("bd_change_ntf_escape"))
				{
					ev.Player.ChangeRole(Role.CHAOS_INSUGENCY);
				}
			}
		}
	}
}
