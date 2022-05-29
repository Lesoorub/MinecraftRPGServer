using System.Collections.Generic;
using System;
using System.Linq;

public static class ToolMath
{
    public enum ToolType : byte
    {
        none = 0, axe, hoe, pickaxe, shovel, sword, shears
    }
    public enum ToolMaterial : byte
    {
        none, wood, stone, iron, diamond, netherite, gold
    }
    public static bool isSpecificTool(ToolType tool, BlockID block)
    {
        if (tool == ToolType.none) return false;
        return hasIn(Tags_1_18_2.TagType.blocks, "mineable/" + tool.ToString(), block.ToString());
    }
    public static bool canHarvest(ItemID itemid, BlockID block)
    {
        switch (GetMaterial(itemid))
        {
            case ToolMaterial.diamond:
            case ToolMaterial.netherite:
                if (Tags_1_18_2.blocks.needs_diamond_tool_names.Contains(block.ToString())) return true;
                if (Tags_1_18_2.blocks.needs_iron_tool_names.Contains(block.ToString())) return true;
                if (Tags_1_18_2.blocks.needs_stone_tool_names.Contains(block.ToString())) return true;
                break;
            case ToolMaterial.iron:
                if (Tags_1_18_2.blocks.needs_iron_tool_names.Contains(block.ToString())) return true;
                if (Tags_1_18_2.blocks.needs_stone_tool_names.Contains(block.ToString())) return true;
                break;
            case ToolMaterial.stone:
            case ToolMaterial.gold:
                if (Tags_1_18_2.blocks.needs_stone_tool_names.Contains(block.ToString())) return true;
                break;
        }
        return false;
    }
    public static float getToolSpeed(ItemID itemid)
    {
        ToolMaterial mat = GetMaterial(itemid);
        switch (mat)
        {
            case ToolMaterial.wood:
                return 2;
            case ToolMaterial.stone:
                return 4;
            case ToolMaterial.iron:
                return 6;
            case ToolMaterial.diamond:
                return 8;
            case ToolMaterial.netherite:
                return 9;
            case ToolMaterial.gold:
                return 12;
        }
        ToolType type = GetToolType(itemid);
        if (type == ToolType.sword || type == ToolType.shears) return 1.5f;
        return 1;
    }
    public static ToolType GetToolType(ItemID itemId)
    {
        switch (itemId)
        {
            case ItemID.wooden_axe:
            case ItemID.stone_axe:
            case ItemID.iron_axe:
            case ItemID.diamond_axe:
            case ItemID.netherite_axe:
            case ItemID.golden_axe:
                return ToolType.axe;
            case ItemID.wooden_hoe:
            case ItemID.stone_hoe:
            case ItemID.iron_hoe:
            case ItemID.diamond_hoe:
            case ItemID.netherite_hoe:
            case ItemID.golden_hoe:
                return ToolType.hoe;
            case ItemID.wooden_pickaxe:
            case ItemID.stone_pickaxe:
            case ItemID.iron_pickaxe:
            case ItemID.diamond_pickaxe:
            case ItemID.netherite_pickaxe:
            case ItemID.golden_pickaxe:
                return ToolType.pickaxe;
            case ItemID.wooden_shovel:
            case ItemID.stone_shovel:
            case ItemID.iron_shovel:
            case ItemID.diamond_shovel:
            case ItemID.netherite_shovel:
            case ItemID.golden_shovel:
                return ToolType.shovel;
            case ItemID.shears:
                return ToolType.shears;
            case ItemID.wooden_sword:
            case ItemID.stone_sword:
            case ItemID.iron_sword:
            case ItemID.diamond_sword:
            case ItemID.netherite_sword:
            case ItemID.golden_sword:
                return ToolType.sword;
        }
        return ToolType.none;
    }
    public static ToolMaterial GetMaterial(ItemID itemId)
    {
        switch (itemId)
        {
            case ItemID.wooden_axe:
            case ItemID.wooden_hoe:
            case ItemID.wooden_pickaxe:
            case ItemID.wooden_shovel:
                return ToolMaterial.wood;
            case ItemID.stone_axe:
            case ItemID.stone_hoe:
            case ItemID.stone_pickaxe:
            case ItemID.stone_shovel:
                return ToolMaterial.stone;
            case ItemID.iron_axe:
            case ItemID.iron_hoe:
            case ItemID.iron_pickaxe:
            case ItemID.iron_shovel:
                return ToolMaterial.iron;
            case ItemID.diamond_axe:
            case ItemID.diamond_hoe:
            case ItemID.diamond_pickaxe:
            case ItemID.diamond_shovel:
                return ToolMaterial.diamond;
            case ItemID.netherite_axe:
            case ItemID.netherite_hoe:
            case ItemID.netherite_pickaxe:
            case ItemID.netherite_shovel:
                return ToolMaterial.netherite;
            case ItemID.golden_axe:
            case ItemID.golden_hoe:
            case ItemID.golden_pickaxe:
            case ItemID.golden_shovel:
                return ToolMaterial.gold;
        }
        return ToolMaterial.none;
    }

    public static bool hasIn(Tags_1_18_2.TagType tagType, string tagPath, string value)
    {
        tagPath = tagPath.Replace("/", ".");
        value = value.Replace("#", "__");
        List<string> names = Enum.GetNames(Type.GetType($"Tags_1_18_2.{tagType}.{tagPath}")).ToList();
        if (names.Contains(value)) return true;
        while (names.Any(x => x.StartsWith("__")))
        {
            foreach (var name in names.ToArray())
            {
                names.Remove(name);
                names.AddRange(Enum.GetNames(Type.GetType($"Tags_1_18_2.{tagType}.{name}")));
            }
        }
        if (names.Contains(value)) return true;
        return false;
    }
}