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
    public static bool isSpecificTool(ToolType tool, DefaultBlockState block)
    {
        if (tool == ToolType.none) return false;
        return hasIn(Tags_1_18_2.TagType.blocks, "mineable/" + tool.ToString(), block.ToString());
    }
    public static bool canHarvest(ItemNameID itemid, DefaultBlockState block)
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
    public static float getToolSpeed(ItemNameID itemid)
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
    public static ToolType GetToolType(ItemNameID itemId)
    {
        switch (itemId)
        {
            case ItemNameID.wooden_axe:
            case ItemNameID.stone_axe:
            case ItemNameID.iron_axe:
            case ItemNameID.diamond_axe:
            case ItemNameID.netherite_axe:
            case ItemNameID.golden_axe:
                return ToolType.axe;
            case ItemNameID.wooden_hoe:
            case ItemNameID.stone_hoe:
            case ItemNameID.iron_hoe:
            case ItemNameID.diamond_hoe:
            case ItemNameID.netherite_hoe:
            case ItemNameID.golden_hoe:
                return ToolType.hoe;
            case ItemNameID.wooden_pickaxe:
            case ItemNameID.stone_pickaxe:
            case ItemNameID.iron_pickaxe:
            case ItemNameID.diamond_pickaxe:
            case ItemNameID.netherite_pickaxe:
            case ItemNameID.golden_pickaxe:
                return ToolType.pickaxe;
            case ItemNameID.wooden_shovel:
            case ItemNameID.stone_shovel:
            case ItemNameID.iron_shovel:
            case ItemNameID.diamond_shovel:
            case ItemNameID.netherite_shovel:
            case ItemNameID.golden_shovel:
                return ToolType.shovel;
            case ItemNameID.shears:
                return ToolType.shears;
            case ItemNameID.wooden_sword:
            case ItemNameID.stone_sword:
            case ItemNameID.iron_sword:
            case ItemNameID.diamond_sword:
            case ItemNameID.netherite_sword:
            case ItemNameID.golden_sword:
                return ToolType.sword;
        }
        return ToolType.none;
    }
    public static ToolMaterial GetMaterial(ItemNameID itemId)
    {
        switch (itemId)
        {
            case ItemNameID.wooden_axe:
            case ItemNameID.wooden_hoe:
            case ItemNameID.wooden_pickaxe:
            case ItemNameID.wooden_shovel:
                return ToolMaterial.wood;
            case ItemNameID.stone_axe:
            case ItemNameID.stone_hoe:
            case ItemNameID.stone_pickaxe:
            case ItemNameID.stone_shovel:
                return ToolMaterial.stone;
            case ItemNameID.iron_axe:
            case ItemNameID.iron_hoe:
            case ItemNameID.iron_pickaxe:
            case ItemNameID.iron_shovel:
                return ToolMaterial.iron;
            case ItemNameID.diamond_axe:
            case ItemNameID.diamond_hoe:
            case ItemNameID.diamond_pickaxe:
            case ItemNameID.diamond_shovel:
                return ToolMaterial.diamond;
            case ItemNameID.netherite_axe:
            case ItemNameID.netherite_hoe:
            case ItemNameID.netherite_pickaxe:
            case ItemNameID.netherite_shovel:
                return ToolMaterial.netherite;
            case ItemNameID.golden_axe:
            case ItemNameID.golden_hoe:
            case ItemNameID.golden_pickaxe:
            case ItemNameID.golden_shovel:
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