using System;
using Smod2;
using Smod2.API;
using System.Threading;

namespace BetterDisarming
{
	class EscapeHandler
	{
		public EscapeHandler(RoundEventHandler ev, Plugin plugin)
		{
			while (ev.roundStarted)
			{
				foreach (Player player in plugin.pluginManager.Server.GetPlayers())
				{
					Vector pos = player.GetPosition();
					if ((pos.x >= 174 && pos.x <= 183) && (pos.y >= 980 && pos.y <= 990) && (pos.z >= 25 && pos.z <= 34))
					{
						if (player.TeamRole.Team.Equals(Team.NINETAILFOX) && player.IsHandcuffed() && plugin.GetConfigBool("bd_change_ntf_escape"))
							player.ChangeRole(Role.CHAOS_INSUGENCY);
						else if (player.TeamRole.Team.Equals(Team.CHAOS_INSURGENCY) && player.IsHandcuffed() && plugin.GetConfigBool("bd_change_ci_escape"))
							player.ChangeRole(Role.NTF_LIEUTENANT);
					}
				}
				System.Threading.Thread.Sleep(1000);
			}
		}
	}
}
