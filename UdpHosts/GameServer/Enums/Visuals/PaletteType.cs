﻿namespace GameServer.Enums.Visuals;

/// <summary>
/// Types of Warpaint Palettes for VisualsPaletteBlock.
/// https://github.com/themeldingwars/Documentation/wiki/Warpaint-Palette-Types
/// </summary>
public enum PaletteType : byte
{
    FullBody = 0x0,
    Armor = 0x01,
    BodySuit = 0x02,
    Glow = 0x03,
    WeaponA = 0x4,
    WeaponB = 0x5,
    Skin = 0x06,
    Hair = 0x07,
    FacialHair = 0x08,
    Eye = 0x09,
    WeaponAExtra = 0x0a,
    WeaponBExtra = 0x0b,
}