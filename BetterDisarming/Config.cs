using Exiled.API.Interfaces;
using System.Collections.Generic;
using System.ComponentModel;

namespace BetterDisarming
{
    public class Config : IConfig
    {
        [Description("Плагин включен или нет.")]
        public bool IsEnabled { get; set; } = false;
        [Description("Интервал времени проверки связанных игроков.")]
        public float CheckInterval { get; set; } = 1f;
        [Description("Лист того кто может сбежать. Указывать в формате КТО СБЕГАЕТ:КЕМ БУДЕТ.")]
        public Dictionary<int, int> Escapelist { get; set; } = new Dictionary<int, int>() { { 15, 8 }, { 13, 8 }, { 4, 8 }, { 11, 8 }, { 12, 8 }, { 8, 13 } };
    }
}
