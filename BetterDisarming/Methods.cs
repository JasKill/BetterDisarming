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
		public static void LoadEscapeList()
		{
			foreach (string entry in  Plugin.Singleton.Config.Escapelist.Split(','))
			{
				string[] part = entry.Split(':');
				if (part.Length == 2)
				{
					if (int.TryParse(part[0], out int a) && int.TryParse(part[1], out int b))
					{
						ServerHandlers.roleDict.Add(a, b);
					}
					else
					{
						Log.Info($"Ошибка! (entry: {entry}) Team is not a valid number.");
					}
				}
				else
				{
					Log.Info($"Ошибка! (entry: {entry}) Invalid formatting.");
				}
			}
		}

		public static IEnumerator<float> CheckEscape()
		{
			Vector3 espaceArea = new Vector3(177.5f, 985.0f, 29.0f);

			while (ServerHandlers.isRoundStarted)
			{
				foreach (Player player in Player.List.Where(x => x.IsCuffed))
				{					
					if (ServerHandlers.roleDict.ContainsKey((int)player.Role) && Vector3.Distance(espaceArea, player.ReferenceHub.transform.position) <= Escape.radius)
					{
						SetRole(player, (RoleType)ServerHandlers.roleDict[(int)player.Role]);
						Log.Info($"{player.Nickname} сбежал за {player.Role}({Escape.radius})");
					}
				}
				yield return Timing.WaitForSeconds(Plugin.Singleton.Config.CheckInterval);
			}
		}

		public static void SetRole(Player ply, RoleType newrole)
        {
			ply.ReferenceHub.GetComponent<CharacterClassManager>().SetClassIDAdv(newrole, true, false);
			ply.ReferenceHub.GetComponent<FirstPersonController>().ModifyStamina(100f);
			ply.ReferenceHub.GetComponent<PlayerStats>().SetHPAmount(ply.ReferenceHub.GetComponent<CharacterClassManager>().Classes.SafeGet(newrole).maxHP);
			Inventory component = ply.ReferenceHub.GetComponent<Inventory>();

			foreach (ItemType id in ply.ReferenceHub.GetComponent<CharacterClassManager>().Classes.SafeGet(newrole).startItems)
			{
				component.AddNewItem(id, -4.65664672E+11f, 0, 0, 0);
			}
		}
	}
}
