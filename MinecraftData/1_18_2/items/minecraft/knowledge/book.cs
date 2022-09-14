using System.Collections.Generic;
namespace MinecraftData._1_18_2.items.minecraft
{
    [Item(ItemNameID.knowledge_book)]
    public class knowledge_book : IBaseItem
    {
        public short id => 1013;
        public Rarity rarity => Rarity.epic;
        public byte max_stack_size => 1;
        public short max_damage => 0;
        public bool is_fire_resistant => false;
        public string translation_key => "item.minecraft.knowledge_book";
        public ItemClasses @class => ItemClasses.KnowledgeBookItem;
    }
}
