using System.ComponentModel;
using Terraria.ModLoader.Config;

namespace WrapWorld
{
    public class WrapWorldConfig : ModConfig
    {
        public override ConfigScope Mode => ConfigScope.ServerSide;

        [Label("Prevent from teleporting if a boss is alive")] [DefaultValue(true)]
        public bool DisableIfBoss;

        [Label("Cooldown between teleports")]
        [Tooltip("Recommended to set this no lower than 60, as you can get stuck.")]
        [Range(1, 360)]
        [DefaultValue(60)]
        public int TeleportCooldown;
    }
}