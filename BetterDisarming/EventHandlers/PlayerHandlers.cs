using Exiled.API.Features;
using Exiled.Events.EventArgs;

namespace BetterDisarming.Handlers
{
    public class PlayerHandlers
    {
        private readonly Plugin plugin;
        public PlayerHandlers(Plugin plugin) => this.plugin = plugin;

        public static bool overrideClassd = false;
        public static bool overrideScientist = false;

        public void OnEspace(EscapingEventArgs ev)
        {
            if (ev.Player.IsCuffed)
            {
                if (ev.Player.Role == RoleType.ClassD && overrideClassd)
                {
                    ev.IsAllowed = false;
                }
                else if (ev.Player.Role == RoleType.Scientist && overrideScientist)
                {
                    ev.IsAllowed = false;
                }
            }
        }
    }
}
