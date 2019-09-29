# BetterDisarming

**I am no longer supporting this project, if you would like to contribute feel free to send a PR.**

### A plugin for SCP: Secret Laboratory

- Doors and elevators are locked for those who are disarmed.
- Configurable custom escapes

# Installation

**[Smod2](https://github.com/Grover-c13/Smod2) must be installed for this to work.**

Place the "BetterDisarming.dll" file in your sm_plugins folder.

| Config        |  Default          | Description  |
| :-------------: | :-----:|:-----:|
| bd_prohibit_doors | True | Prevents handcuffed players from using doors.  |
| bd_prohibit_elevators | True | Prevents handcuffed players from using delevators. |
| bd_check_interval | 1.00 | How long before every escape check in seconds. |
| bd_escape_list | 11:8,12:8,13:8,8:11 | A list of roles who can escape and what they turn into. Every entry is separated with a comma in the format `EntryTeam:ExitTeam`. You can view a list of role IDs [here.](https://github.com/Cyanox62/BetterDisarming/wiki/Role-IDs) |
