using BetterDisarming.Handlers;
using Exiled.API.Enums;
using Exiled.API.Features;
using System;
using Server = Exiled.Events.Handlers.Server;
using Player = Exiled.Events.Handlers.Player;

namespace BetterDisarming
{
    public class Plugin : Plugin<Config>
	{
		public override string Name { get; } = "BetterDisarming";
		public override string Author { get; } = "Cyanox62, changed JasKill";
		public override Version Version { get; } = new Version(1, 0, 0);
		public override Version RequiredExiledVersion { get; } = new Version(2, 0, 0);
		public override string Prefix { get; } = "BetterDisarming";
		public override PluginPriority Priority { get; } = PluginPriority.Default;
		public ServerHandlers ServerHandlers;
		public PlayerHandlers PlayerHandlers;
		public static Plugin Singleton;

		public override void OnEnabled()
		{
			Singleton = this;

			RegisterEvents();
			base.OnEnabled();
		}

		public override void OnDisabled()
		{
			UnregisterEvents();
			base.OnDisabled();
		}

		public override void OnReloaded() => Log.Info($"Плагин {Name} был перезагружен!");

		private void RegisterEvents()
        {
			ServerHandlers = new ServerHandlers(this);
			PlayerHandlers = new PlayerHandlers(this);

			Server.WaitingForPlayers += ServerHandlers.OnWaitPlayers;
			Server.RoundStarted += ServerHandlers.OnStartRound;
			Server.RoundEnded += ServerHandlers.OnEndedRound;

			Player.Escaping += PlayerHandlers.OnEspace;
		}

		private void UnregisterEvents()
        {
			Server.WaitingForPlayers -= ServerHandlers.OnWaitPlayers;
			Server.RoundStarted -= ServerHandlers.OnStartRound;
			Server.RoundEnded -= ServerHandlers.OnEndedRound;

			Player.Escaping -= PlayerHandlers.OnEspace;

			ServerHandlers = null;
			PlayerHandlers = null;
		}
	}
}
