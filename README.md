# Exactly like [JasKill/BetterDisarming](https://github.com/JasKill/BetterDisarming) but with the added option to give a custom number of respawn tickets to the cuffed person's new team when they escape.

# Installation

Install the latest of version of [EXILED](https://github.com/galaxy119/EXILED) if you don't have it, then download [BetterDisarming.dll](https://github.com/Aevann1/BetterDisarming/releases) and place it in in "%appdata%\EXILED\Plugins"

# Default configs:
```yaml
# Whether or not the plugin is enabled.
  is_enabled: true
  # How long before every escape check in seconds.
  check_interval: 1
  # A list of roles who can escape and what they turn into. Format EntryTeam:ExitTeam
  escapelist:
    15: 8
    13: 8
    4: 8
    11: 8
    12: 8
    8: 13
  # How many respawn tickets to give to the disarmed person's new team when they escape while cuffed.
  give_tickets: 1
```
