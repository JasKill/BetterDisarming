using System.Linq;
using System.Collections.Generic;
using MEC;
using EXILED;
using EXILED.Extensions;
using UnityEngine;

namespace BetterDisarming
{
	partial class EventHandlers
	{
		internal static float checkInterval;
		internal static string escapelist;

		internal static void ReloadConfigs()
		{
			checkInterval = Plugin.Config.GetFloat("bd_check_interval", 1);
			escapelist = Plugin.Config.GetString("bd_escape_list", "15:8,13:8,4:8,11:8,12:8,8:13");

		}

		private void LoadEscapeList()
		{
			foreach (string entry in escapelist.Split(','))
			{
				string[] part = entry.Split(':');
				if (part.Length == 2)
				{
					if (int.TryParse(part[0], out int a) && int.TryParse(part[1], out int b))
					{
						roleDict.Add(a, b);
					}
					else
					{
						Log.Info($"ERROR! (entry: {entry}) Team is not a valid number.");
					}
				}
				else
				{
					Log.Info($"ERROR! (entry: {entry}) Invalid formatting.");
				}
			}
		}

		private static IEnumerator<float> CheckEscape()
		{
			while (isRoundStarted)
			{
				foreach (ReferenceHub player in Player.GetHubs().Where(x => x.IsHandCuffed()))
				{
					Vector3 espaceArea = new Vector3(177.5f, 985.0f, 29.0f);
					if (roleDict.ContainsKey((int)player.GetRole()) && Vector3.Distance(espaceArea, player.transform.position) <= Escape.radius)
					{
						player.SetRole((RoleType)roleDict[(int)player.GetRole()]);
						Log.Info($"{player.GetNickname()} сбежал за {player.GetRole()}({Escape.radius})");
					}
				}
				yield return Timing.WaitForSeconds(checkInterval);
			}
		}
	}
}
