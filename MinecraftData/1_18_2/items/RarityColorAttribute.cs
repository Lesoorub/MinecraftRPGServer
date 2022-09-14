using System;
namespace MinecraftData._1_18_2.items.minecraft
{
    public class RarityColorAttribute : Attribute
    {
        public string color;
        public RarityColorAttribute(string color) 
        { 
            this.color = color;
        }
    }

}
