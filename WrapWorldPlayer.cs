using System.Linq;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace WrapWorld
{
    public class WrapWorldPlayer : ModPlayer
    {
        private int _teleportCooldown;

        public override void PostUpdate()
        {
            Vector2? newPos = null;
            if (player.position.ToTileCoordinates().X == 44)
            {
                newPos = new Vector2(Main.maxTilesX - 44, player.position.ToTileCoordinates().Y).ToWorldCoordinates();
            }
            else if (player.position.ToTileCoordinates().X == Main.maxTilesX - 44)
            {
                newPos = new Vector2(44, player.position.ToTileCoordinates().Y).ToWorldCoordinates();
            }

            var teleportCooldown = ModContent.GetInstance<WrapWorldConfig>().TeleportCooldown;
            var disableIfBoss = ModContent.GetInstance<WrapWorldConfig>().DisableIfBoss;
            if (newPos.HasValue && !Collision.SolidCollision(newPos.Value, player.width, player.height) &&
                _teleportCooldown <= 0 && !(disableIfBoss && Main.npc.Any(e => e.boss && e.active)))
            {
                player.position = newPos.Value;
                _teleportCooldown = teleportCooldown;
            }
            else if (_teleportCooldown > 0)
            {
                _teleportCooldown--;
            }

            base.PostUpdate();
        }
    }
}