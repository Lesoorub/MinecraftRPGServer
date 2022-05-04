using System;

[Flags]
public enum SlotType : byte
{
    Any = 0,
    Armor = 1,
    Helmet = 2,
    Chestplate = 4,
    Leggins = 8,
    Boots = 16,
    CustomList = 32,
    ReadOnly = 64,
}