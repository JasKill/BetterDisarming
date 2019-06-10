using Smod2;
using Smod2.EventHandlers;
using Smod2.Events;
using MEC;
using System.Collections.Generic;

namespace BetterDisarming
{
	partial class EventHandler : IEventHandlerRoundStart, IEventHandlerRoundEnd, IEventHandlerDoorAccess,
		IEventHandlerElevatorUse, IEventHandlerWaitingForPlayers, IEventHandlerCheckEscape
	{
		private Plugin instance;
		private Dictionary<int, int> roleDict = new Dictionary<int, int>();
		private bool isRoundStarted = false;
		private bool overrideClassd = false;
		private bool overrideScientist = false;

		// Configs
		private bool blockDoors;
		private bool blockElevators;
		private float checkInterval;
		private string escapeList;

		public EventHandler(Plugin plugin)
		{
			instance = plugin;
		}

		public void OnWaitingForPlayers(WaitingForPlayersEvent ev)
		{
			// Reset data
			overrideClassd = false;
			overrideScientist = false;
			roleDict.Clear();

			LoadConfigs();
			LoadEscapeList();
			if (roleDict.ContainsKey((int)Smod2.API.Role.CLASSD)) overrideClassd = true;
			if (roleDict.ContainsKey((int)Smod2.API.Role.SCIENTIST)) overrideScientist = true;
		}

		public void OnRoundStart(RoundStartEvent ev)
		{
			isRoundStarted = true;
			Timing.RunCoroutine(CheckEscape());
		}

		public void OnRoundEnd(RoundEndEvent ev)
		{
			isRoundStarted = false;
		}

		public void OnDoorAccess(PlayerDoorAccessEvent ev)
		{
			if (blockDoors && ev.Player.IsHandcuffed())
			{
				ev.Allow = false;
			}
		}

		public void OnElevatorUse(PlayerElevatorUseEvent ev)
		{
			if (blockElevators && ev.Player.IsHandcuffed())
			{
				ev.AllowUse = false;
			}
		}

		public void OnCheckEscape(PlayerCheckEscapeEvent ev)
		{
			if (ev.Player.IsHandcuffed())
			{
				if (ev.Player.TeamRole.Role == Smod2.API.Role.CLASSD && overrideClassd) ev.AllowEscape = false;
				if (ev.Player.TeamRole.Role == Smod2.API.Role.SCIENTIST && overrideScientist) ev.AllowEscape = false;
			}
		}
	}
}
