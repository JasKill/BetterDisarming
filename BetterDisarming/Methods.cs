using System.Linq;
using System.Collections.Generic;
using MEC;
using Exiled.API.Features;
using UnityEngine;
using BetterDisarming.Handlers;
using Respawning;

namespace BetterDisarming
{
	public class Methods
	{
		private static Vector3 espaceArea = new Vector3(177.5f, 985.0f, 29.0f);
		public static IEnumerator<float> CheckEscape()
		{
			while (ServerHandlers.isRoundStarted)
			{
				foreach (Player player in Player.List.Where(x => x.IsCuffed))
				{
					if (Plugin.Singleton.Config.Escapelist.ContainsKey((int)player.Role) && Vector3.Distance(espaceArea, player.ReferenceHub.transform.position) <= Escape.radius)
					{
						player.Role = (RoleType)Plugin.Singleton.Config.Escapelist[(int)player.Role];
						if (Plugin.Singleton.Config.GiveTickets > 0)
						{
							var team = SpawnableTeamType.NineTailedFox;
							if (player.Role == RoleType.ClassD || player.Role == RoleType.ChaosInsurgency) team = SpawnableTeamType.ChaosInsurgency;
							Respawning.RespawnTickets.Singleton.GrantTickets(team, Plugin.Singleton.Config.GiveTickets, false);
						}
					}
				}
				yield return Timing.WaitForSeconds(Plugin.Singleton.Config.CheckInterval);
			}
		}
	}
}
