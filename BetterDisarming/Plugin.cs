using EXILED;

namespace BetterDisarming
{
	public class Plugin : EXILED.Plugin
	{
		private EventHandlers ev;

		private bool enabled;

		public override void OnEnable()
		{
			enabled = Config.GetBool("bd_enabled", true);

			if (!enabled)
			{
				Log.Info("BetterDisarming disabled");
				return;
			}

			ev = new EventHandlers();

			Events.WaitingForPlayersEvent += ev.OnWaitingForPlayers;
			Events.RoundStartEvent += ev.OnRoundStart;
			Events.RoundEndEvent += ev.OnRoundEnd;
			Events.CheckEscapeEvent += ev.OnCheckEscape;
		}

		public override void OnDisable()
		{
			Events.WaitingForPlayersEvent += ev.OnWaitingForPlayers;
			Events.RoundStartEvent += ev.OnRoundStart;
			Events.RoundEndEvent += ev.OnRoundEnd;
			Events.CheckEscapeEvent += ev.OnCheckEscape;

			ev = null;
		}

		public override void OnReload() { }

		public override string getName { get; } = "BetterDisarming";
	}
}
