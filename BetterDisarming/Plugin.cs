using Exiled.API.Features;
using Exiled.API.Interfaces;
using Events = Exiled.Events;

namespace BetterDisarming
{
    public class Plugin : Exiled.API.Features.Plugin
	{
		public override IConfig Config { get; } = new Config();
		public Handlers.PlayerEvents PlayerEvents;
		public Handlers.ServerEvents ServerEvents;
		public static Config Cfg;

		public override void OnEnabled()
		{
			Cfg = (Config)Config;
			Cfg.Reload();

			if (!Cfg.enabled)
			{
				Log.Info($"{Name} выключен");
				return;
			}

			RegisterEvents();
		}

		public override void OnDisabled()
		{
			if (!Cfg.enabled)
			{
				Log.Info($"{Name} выключен");
				return;
			}

			UnregisterEvents();
			Log.Info($"{Name} выключен!");
		}

		public override void OnReloaded() => Log.Info($"{Name} был перезагружен!");

		private void RegisterEvents()
        {
			ServerEvents = new Handlers.ServerEvents();
			PlayerEvents = new Handlers.PlayerEvents();

			Events.Handlers.Server.WaitingForPlayers += ServerEvents.OnWaitPlayers;
			Events.Handlers.Server.RoundStarted += ServerEvents.OnStartRound;
			Events.Handlers.Server.RoundEnded += ServerEvents.OnEndedRound;

			Events.Handlers.Player.Escaping += PlayerEvents.OnEspace;
		}

		private void UnregisterEvents()
        {
			Events.Handlers.Server.WaitingForPlayers -= ServerEvents.OnWaitPlayers;
			Events.Handlers.Server.RoundStarted -= ServerEvents.OnStartRound;
			Events.Handlers.Server.RoundEnded -= ServerEvents.OnEndedRound;

			Events.Handlers.Player.Escaping -= PlayerEvents.OnEspace;

			ServerEvents = null;
			PlayerEvents = null;
		}
	}
}
