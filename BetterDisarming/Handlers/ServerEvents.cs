using Exiled.Events.EventArgs;
using MEC;
using System.Collections.Generic;

namespace BetterDisarming.Handlers
{
    public class ServerEvents
    {
        public static bool isRoundStarted = false;
        public static Dictionary<int, int> roleDict = new Dictionary<int, int>();

        public void OnWaitPlayers()
        {
            PlayerEvents.overrideClassd = false;
            PlayerEvents.overrideScientist = false;
            roleDict.Clear();

            Methods.LoadEscapeList();

            if (roleDict.ContainsKey((int)RoleType.ClassD))
            {
                PlayerEvents.overrideClassd = true;
            }
            if (roleDict.ContainsKey((int)RoleType.Scientist))
            {
                PlayerEvents.overrideScientist = true;
            }
        }

        public void OnStartRound()
        {
            isRoundStarted = true;
            Timing.RunCoroutine(Methods.CheckEscape());
        }

        public void OnEndedRound(RoundEndedEventArgs ev)
        {
            isRoundStarted = false;
        }
    }
}
