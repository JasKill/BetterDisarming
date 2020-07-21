using System.Linq;
using System.Collections.Generic;
using MEC;
using Exiled.API.Features;
using UnityEngine;
using BetterDisarming.Handlers;

namespace BetterDisarming
{
    public class Methods
	{
		public static IEnumerator<float> CheckEscape()
		{
			Vector3 espaceArea = new Vector3(177.5f, 985.0f, 29.0f);

			while (ServerHandlers.isRoundStarted)
			{
				foreach (Player player in Player.List.Where(x => x.IsCuffed))
				{
					if (Plugin.Singleton.Config.Escapelist.ContainsKey((int)player.Role) && Vector3.Distance(espaceArea, player.ReferenceHub.transform.position) <= Escape.radius)
					{
						player.Role = (RoleType)Plugin.Singleton.Config.Escapelist[(int)player.Role];
						Log.Info($"{player.Nickname} сбежал за {player.Role}({Escape.radius})");
					}
				}
				yield return Timing.WaitForSeconds(Plugin.Singleton.Config.CheckInterval);
			}
		}
	}
}
