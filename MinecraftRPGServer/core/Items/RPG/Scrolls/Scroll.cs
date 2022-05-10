namespace Scrolls
{
    public class Scroll 
    { 
        public virtual void Execute(Player player, float Power) { }

        public virtual string Description => "no description";
    }
}