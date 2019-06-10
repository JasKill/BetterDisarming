using System.Collections.Generic;
using Smod2.API;
using MEC;
using System.Linq;

namespace BetterDisarming
{
	partial class EventHandler
	{
		private void LoadConfigs()
		{
			blockDoors = instance.GetConfigBool("bd_prohibit_doors");
			blockElevators = instance.GetConfigBool("bd_prohibit_elevators");
			checkInterval = instance.GetConfigFloat("bd_check_interval");
			escapeList = instance.GetConfigString("bd_escape_list");
		}

		private bool LoadEscapeList()
		{
			foreach (string entry in escapeList.Split(','))
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
						instance.Info($"ERROR! (entry: {entry}) Team is not a valid number.");
						return false;
					}
				}
				else
				{
					instance.Info($"ERROR! (entry: {entry}) Invalid formatting.");
					return false;
				}
			}
			return true;
		}

		private IEnumerator<float> CheckEscape()
		{
			while (isRoundStarted)
			{
				foreach (Player player in instance.Server.GetPlayers().Where(x => x.IsHandcuffed()))
				{
					Vector pos = player.GetPosition();
					if (roleDict.ContainsKey((int)player.TeamRole.Role) &&
						pos.x >= 174 &&
						pos.x <= 183 &&
						pos.y >= 980 &&
						pos.y <= 990 && 
						pos.z >= 25 && 
						pos.z <= 34)
					{
						player.ChangeRole((Role)roleDict[(int)player.TeamRole.Role], true, true, true, true);
					}
				}
				yield return Timing.WaitForSeconds(checkInterval);
			}
		}
	}
}
