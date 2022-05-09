namespace Inventory.Items
{
    [RPGItem("bow")]
    public class RPGBow : Bow
    {
        public override string[] Lore => new string[]
        {
            $"Type: Bow",
            $"Damage: {ArrowDamage}",
            $"Arrow speed: {ArrowSpeed}",
        };
        public RPGBow()
        {
            Name = "bow";
        }
        public override void Shot(Player player, float charge)
        {
            ShotArrow(player, player.ForwardDir, charge * ArrowSpeed);
            if (player.IsSneaking)
            {
                float angle = 15;
                ShotArrow(player, (player.ForwardDir + v3f.FromRotationInvertX(player.Rotation + new v2f(angle, 0))).Normalized, charge);
                ShotArrow(player, (player.ForwardDir + v3f.FromRotationInvertX(player.Rotation + new v2f(-angle, 0))).Normalized, charge);
            }
            Damage--;
            if (Damage < 1)
                Damage = 1;
        }
    }
}