using System.Collections.Generic;

namespace Inventory.Items
{
    [RPGItem("bow")]
    public class RPGBow : Bow
    {
        public RPGBow()
        {
            Name = "bow";
        }
        protected override void GetTooltip(ref List<Parameter> list)
        {
            base.GetTooltip(ref list);
            list.Add(new Parameter("Damage", ArrowDamage.ToString()));
            list.Add(new Parameter("Arrow speed", ArrowSpeed.ToString()));
        }
        protected override bool CanShot(Player player)
        {
            return true;
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