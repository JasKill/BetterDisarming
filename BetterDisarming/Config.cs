using Exiled.API.Interfaces;
using System.ComponentModel;

namespace BetterDisarming
{
    public class Config : IConfig
    {
        [Description("Плагин включен или нет.")]
        public bool IsEnabled { get; set; } = false;
        [Description("После того как кто то сбежит, будет ожидать это время, чтобы опять можно было сбежать.")]
        public float CheckInterval { get; set; } = 1f;
        [Description("Лист того кто может сбежать. Указывать в формате КТО СБЕГАЕТ:КЕМ БУДЕТ.")]
        public string Escapelist { get; set; } = "15:8,13:8,4:8,11:8,12:8,8:13";
    }
}
