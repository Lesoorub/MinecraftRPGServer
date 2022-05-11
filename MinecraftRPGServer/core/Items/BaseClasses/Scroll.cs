using System.Collections.Generic;

namespace Inventory.Items
{
    public class Scroll : Paper
    {
        public override string Type => "Scroll";
        public virtual string Description => "no description";
        public override List<string> GetOreDict()
        {
            var t = base.GetOreDict();
            t.Add("scroll");
            return t;
        }
        public Scroll()
        {
        }
        public virtual void Execute(Player player, v3f position, float Power) { }
        protected override void GetTooltip(ref List<Parameter> list)
        {
            base.GetTooltip(ref list);
            list.Add(new Parameter("Description", Description));
        }
    }
}