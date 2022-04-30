using System;

[Flags]
public enum SlotType : byte
{
    All = 0,
    Armor = 0x01,
    Helmet = 0x02,
    Chest = 0x04,
    Leggins = 0x08,
    Boots = 0x1,
    CustomList = 0x2
}