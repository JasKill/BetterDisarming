using Exiled.Events.EventArgs;
using MEC;
using System.Collections.Generic;

namespace BetterDisarming.Handlers
{
    public class ServerHandlers
    {
        private readonly Plugin plugin;
        public ServerHandlers(Plugin plugin) => this.plugin = plugin;

        public static bool isRoundStarted = false;
        public static Dictionary<int, int> roleDict = new Dictionary<int, int>();

        public void OnWaitPlayers()
        {
            PlayerHandlers.overrideClassd = false;
            PlayerHandlers.overrideScientist = false;

            if (roleDict.ContainsKey((int)RoleType.ClassD))
            {
                PlayerHandlers.overrideClassd = true;
            }
            if (roleDict.ContainsKey((int)RoleType.Scientist))
            {
                PlayerHandlers.overrideScientist = true;
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
