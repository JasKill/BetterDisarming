using Exiled.Events.EventArgs;

namespace BetterDisarming.Handlers
{
    public class PlayerEvents
    {
        public static bool overrideClassd = false;
        public static bool overrideScientist = false;

        public void OnEspace(EscapingEventArgs ev)
        {
            if (/*Player.IsHandCuffed(ev.Player)*/ ev.Player.IsCuffed)
            {
                if (ev.Player.Role == RoleType.ClassD && overrideClassd)
                {
                    ev.IsAllowed = false;
                }
                if (ev.Player.Role == RoleType.Scientist && overrideScientist)
                {
                    ev.IsAllowed = false;
                }
            }
        }
    }
}
