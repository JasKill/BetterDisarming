using System.Collections.Generic;
using EXILED;
using EXILED.Extensions;
using MEC;

namespace BetterDisarming
{
	partial class EventHandlers
	{
		private static Dictionary<int, int> roleDict = new Dictionary<int, int>();
		private static bool isRoundStarted = false;
		private bool overrideClassd = false;
		private bool overrideScientist = false;

		public void OnWaitingForPlayers()
		{
			overrideClassd = false;
			overrideScientist = false;
			roleDict.Clear();

			LoadEscapeList();

			if (roleDict.ContainsKey((int)RoleType.ClassD)) overrideClassd = true;
			if (roleDict.ContainsKey((int)RoleType.Scientist)) overrideScientist = true;
		}

		public void OnRoundStart()
		{
			isRoundStarted = true;
			Timing.RunCoroutine(CheckEscape());
		}

		public void OnRoundEnd()
		{
			isRoundStarted = false;
		}

		public void OnCheckEscape(ref CheckEscapeEvent ev)
		{
			if (Player.IsHandCuffed(ev.Player))
			{
				if (Player.GetRole(ev.Player) == RoleType.ClassD && overrideClassd)
					ev.Allow = false;
				if (Player.GetRole(ev.Player) == RoleType.Scientist && overrideScientist)
					ev.Allow = false;
			}
		}
	}
}
