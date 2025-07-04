using System;
using System.Collections.Generic;
using System.Linq;
using AeroMessages.Common;
using AeroMessages.GSS.V66;
using AeroMessages.GSS.V66.Character;
using GameServer.Data.SDB;

namespace GameServer.Data;

public enum LoadoutSlotType : byte
{
    Primary = 1,
    Secondary = 2,
    AbilityHKM = 6,
    Ability1 = 7,
    Ability2 = 8,
    Ability3 = 9,
    Backpack = 11,
   
    GearTorso = 116,
    GearAuxWeapon = 122,
    GearMedicalSystem = 123,
    GearHead = 124,
    GearArms = 126,
    GearLegs = 127,
    GearReactor = 128,
    GearOS = 129,
    GearGadget1 = 130,
    GearGadget2 = 137,
    Vehicle = 157,
    Glider = 158,
}

public enum AbilitySlotType
{
    Ability1 = 0,
    Ability2 = 1,
    Ability3 = 2,
    AbilityHKM = 3,
    AbilityInteract = 4,
    AbilityAux = 5,
    AbilityMedical = 6,
    AbilitySIN = 13,
    AbilityCalldownVehicle = 16,
    AbilityCalldownGlider = 17
}

public class CharacterLoadout
{
    public static readonly LoadoutSlotType[] LoadoutAbilitySlots =
    {
        LoadoutSlotType.Ability1,
        LoadoutSlotType.Ability2,
        LoadoutSlotType.Ability3,
        LoadoutSlotType.AbilityHKM,
        LoadoutSlotType.GearAuxWeapon,
        LoadoutSlotType.GearMedicalSystem
    };

    public static readonly LoadoutSlotType[] LoadoutChassisSlots =
    {
        LoadoutSlotType.GearTorso,
        LoadoutSlotType.GearAuxWeapon,
        LoadoutSlotType.GearMedicalSystem,
        LoadoutSlotType.GearHead,
        LoadoutSlotType.GearArms,
        LoadoutSlotType.GearLegs,
        LoadoutSlotType.GearReactor,
        LoadoutSlotType.GearOS,
        LoadoutSlotType.GearGadget1,
        LoadoutSlotType.GearGadget2
    };

    public static readonly LoadoutSlotType[] LoadoutWeaponSlots =
    {
        LoadoutSlotType.Primary,
        LoadoutSlotType.Secondary,
    };

    public static readonly Dictionary<LoadoutSlotType, AbilitySlotType> LoadoutToAbilitySlotMap = new Dictionary<LoadoutSlotType, AbilitySlotType>()
    {
        { LoadoutSlotType.Ability1, AbilitySlotType.Ability1 },
        { LoadoutSlotType.Ability2, AbilitySlotType.Ability2 },
        { LoadoutSlotType.Ability3, AbilitySlotType.Ability3 },
        { LoadoutSlotType.AbilityHKM, AbilitySlotType.AbilityHKM },
        { LoadoutSlotType.GearAuxWeapon, AbilitySlotType.AbilityAux },
        { LoadoutSlotType.GearMedicalSystem, AbilitySlotType.AbilityMedical },
    };
    public static readonly Dictionary<AbilitySlotType, LoadoutSlotType> AbilityToLoadoutSlotMap = new Dictionary<AbilitySlotType, LoadoutSlotType>()
    {
        { AbilitySlotType.Ability1, LoadoutSlotType.Ability1 },
        { AbilitySlotType.Ability2, LoadoutSlotType.Ability2 },
        { AbilitySlotType.Ability3, LoadoutSlotType.Ability3 },
        { AbilitySlotType.AbilityHKM, LoadoutSlotType.AbilityHKM },
        { AbilitySlotType.AbilityAux, LoadoutSlotType.GearAuxWeapon },
        { AbilitySlotType.AbilityMedical, LoadoutSlotType.GearMedicalSystem },
        { AbilitySlotType.AbilityCalldownVehicle, LoadoutSlotType.Vehicle },
        { AbilitySlotType.AbilityCalldownGlider, LoadoutSlotType.Glider }
    };

    public Dictionary<LoadoutSlotType, uint> SlottedItems = new Dictionary<LoadoutSlotType, uint>();

    // Module and Character Scalars is an assumption that has not been completely confirmed. I'm not sure what the exact rule for separation between the two categories is.
    public Dictionary<ushort, float> ItemAttributes = new Dictionary<ushort, float>();
    public Dictionary<ushort, float> ItemModuleScalars = new Dictionary<ushort, float>();
    public Dictionary<ushort, float> ItemCharacterScalars = new Dictionary<ushort, float>();

    private static readonly Dictionary<ushort, float> _fallbackAttributes = new()
    {
        // We fill these in if we somehow don't have them to ensure a playable experience (0 run speed = zzz)
        { 5, 75 }, // Jet Energy Recharge
        { 6, 100 }, // Health
        { 7, 3.75f }, // Health Regen
        { 12, 10 }, // Run Speed
        { 35, 500 }, // Jet Energy
        { 37, 1.75f }, // Jump Height
        { 1121, 150 }, // Jet Spring Cost
        { 1451, 100 }, // Power Rating
        { 1377, 130 }, // Sprint Speed
    };

    private static readonly Dictionary<ushort, float> _fallbackModuleScalars = new()
    {
    };

    private static readonly Dictionary<ushort, float> _fallbackCharacterScalars = new()
    {
    };
 
    /// <summary>
    /// Initializes a new instance of the <see cref="CharacterLoadout"/> class.
    /// </summary>
    public CharacterLoadout()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="CharacterLoadout"/> class.
    /// </summary>
    /// <param name="refData">Data to setup the loadout with</param>
    public CharacterLoadout(LoadoutReferenceData refData)
    {
        InitFromLoadoutReferenceData(refData);
    }

    public int LoadoutID { get; set; }
    public uint VehicleID { get; set; }
    public uint GliderID { get; set; }
    public uint ChassisID { get; set; }
    public uint BackpackID { get; set; }
    public uint ChassisChangeTime { get; set; } = 0;
    public ChassisWarpaintResult ChassisWarpaint { get; set; }

    public VisualsBlock GetChassisVisuals()
    {
        return new VisualsBlock
        {
            Decals = Array.Empty<VisualsDecalsBlock>(),
            Gradients = ChassisWarpaint.Gradients,
            Colors = ChassisWarpaint.Colors,
            Palettes = ChassisWarpaint.Palettes,
            Patterns = Array.Empty<VisualsPatternBlock>(),
            OrnamentGroupIds = Array.Empty<uint>(),
            CziMapAssetIds = Array.Empty<uint>(),
            MorphWeights = Array.Empty<HalfFloat>(),
            Overlays = Array.Empty<VisualsOverlayBlock>()
        };
    }

    public uint GetAbilityModuleIdBySlotIndex(byte slotIndex)
    {
        var slotType = (AbilitySlotType)slotIndex;
        var loadoutSlot = AbilityToLoadoutSlotMap.GetValueOrDefault(slotType);
        if (loadoutSlot == 0)
        {
            return 0;
        }

        return SlottedItems.GetValueOrDefault(loadoutSlot);
    }

    public SlottedModule[] GetBackpackModules()
    {
        return SlottedItems
        .Where(slotted => LoadoutAbilitySlots.Contains(slotted.Key))
        .Select((slotted) =>
        {
            return new SlottedModule
            {
                SdbId = slotted.Value,
                SlotIndex = (byte)LoadoutToAbilitySlotMap[slotted.Key],
                Flags = 0,
                Unk2 = 0,
            };
        })
        .ToArray();
    }

    public SlottedModule[] GetChassisModules()
    {
        return SlottedItems
        .Where(slotted => LoadoutChassisSlots.Contains(slotted.Key))
        .Select((slotted) =>
        {
            return new SlottedModule
            {
                SdbId = slotted.Value,
                SlotIndex = 0xff,
                Flags = 0,
                Unk2 = 0,
            };
        })
        .ToArray();
    }

    public StatsData[] GetItemAttributes()
    {
        return ItemAttributes
        .Select((pair) =>
        {
            return new StatsData()
            {
                Id = pair.Key,
                Value = pair.Value
            };
        })
        .ToArray();
    }

    public StatsData[] GetPrimaryWeaponAttributes()
    {
        var result = new Dictionary<ushort, float>();
        var itemId = SlottedItems.GetValueOrDefault(LoadoutSlotType.Primary);
        if (itemId != 0)
        {
            var itemAttributes = SDBInterface.GetItemAttributeRange(itemId);
            foreach (var range in itemAttributes.Values)
            {
                if (result.ContainsKey(range.AttributeId))
                {
                    result[range.AttributeId] += range.Base;
                }
                else
                {
                    result.Add(range.AttributeId, range.Base);
                }
            }
        }

        return result
        .Select((pair) =>
        {
            return new StatsData()
            {
                Id = pair.Key,
                Value = pair.Value
            };
        })
        .ToArray();
    }

    public StatsData[] GetSecondaryWeaponAttributes()
    {
        var result = new Dictionary<ushort, float>();
        var itemId = SlottedItems.GetValueOrDefault(LoadoutSlotType.Secondary);
        if (itemId != 0)
        {
            var itemAttributes = SDBInterface.GetItemAttributeRange(itemId);
            foreach (var range in itemAttributes.Values)
            {
                if (result.ContainsKey(range.AttributeId))
                {
                    result[range.AttributeId] += range.Base;
                }
                else
                {
                    result.Add(range.AttributeId, range.Base);
                }
            }
        }

        return result
        .Select((pair) =>
        {
            return new StatsData()
            {
                Id = pair.Key,
                Value = pair.Value
            };
        })
        .ToArray();
    }

    public StatsData[] GetItemModuleScalars()
    {
        return ItemModuleScalars
        .Select((pair) =>
        {
            return new StatsData()
            {
                Id = pair.Key,
                Value = pair.Value
            };
        })
        .ToArray();
    }

    public StatsData[] GetItemCharacterScalars()
    {
        return ItemCharacterScalars
        .Select((pair) =>
        {
            return new StatsData()
            {
                Id = pair.Key,
                Value = pair.Value
            };
        })
        .ToArray();
    }

    private void InitFromLoadoutReferenceData(LoadoutReferenceData refData)
    {
        VehicleID = 77087;
        GliderID = 81423;
        LoadoutID = refData.LoadoutId;
        ChassisID = refData.ChassisId;
        BackpackID = SDBUtils.GetChassisDefaultBackpack(ChassisID);
        ChassisWarpaint = SDBUtils.GetChassisWarpaint(ChassisID, 0, 0, 0, 0);

        // Assume PvE
        foreach (var (slot, type) in refData.SlottedItemsPvE)
        {
            SlottedItems.Add(slot, type);
        }

        CalculateItemAttributes();
    }

    private void ApplyItemStats(uint itemTypeId, Dictionary<ushort, float> totalAttributes, Dictionary<ushort, float> totalModuleScalars, Dictionary<ushort, float> totalCharacterScalars)
    {
        var itemAttributes = SDBInterface.GetItemAttributeRange(itemTypeId);
        foreach (var range in itemAttributes.Values)
        {
            if (totalAttributes.ContainsKey(range.AttributeId))
            {
                totalAttributes[range.AttributeId] += range.Base;
            }
            else
            {
                totalAttributes.Add(range.AttributeId, range.Base);
            }
        }

        var itemModuleScalars = SDBInterface.GetItemModuleScalars(itemTypeId);
        foreach ((ushort attributeCategoryId, (float value, float perLevel)) in itemModuleScalars)
        {
            var attributeCategory = SDBInterface.GetAttributeCategory(attributeCategoryId);
            if (!totalCharacterScalars.ContainsKey(attributeCategoryId))
            {
                totalCharacterScalars.Add(attributeCategoryId, 0.0f);
            }

            if (attributeCategory.IsScalar == 1)
            {
                totalCharacterScalars[attributeCategoryId] += totalCharacterScalars[attributeCategoryId] / 100 * attributeCategory.ModuleEffectiveness;
            }
            else
            {
                totalCharacterScalars[attributeCategoryId] += value - 1;
            }
        }

        var itemCharacterScalars = SDBInterface.GetItemCharacterScalars(itemTypeId);
        foreach ((ushort attributeCategoryId, (float value, float perLevel)) in itemCharacterScalars)
        {
            var attributeCategory = SDBInterface.GetAttributeCategory(attributeCategoryId);
            if (!totalModuleScalars.ContainsKey(attributeCategoryId))
            {
                totalModuleScalars.Add(attributeCategoryId, 0.0f);
            }

            if (attributeCategory.IsScalar == 1)
            {
                totalModuleScalars[attributeCategoryId] += totalModuleScalars[attributeCategoryId] / 100 * attributeCategory.ModuleEffectiveness;
            }
            else
            {
                totalModuleScalars[attributeCategoryId] += value - 1;
            }
        }
    }

    private void CalculateItemAttributes()
    {
        var attributes = new Dictionary<ushort, float>()
        {
            { 12, 2.5f }, // Temporary base Run Speed boost because it's so slow otherwise
        };
        var moduleScalars = new Dictionary<ushort, float>()
        {
        };
        var characterScalars = new Dictionary<ushort, float>()
        {
        };

        ApplyItemStats(ChassisID, attributes, moduleScalars, characterScalars);
        foreach (var pair in SlottedItems)
        {
            if (LoadoutAbilitySlots.Contains(pair.Key) || LoadoutChassisSlots.Contains(pair.Key))
            {
                ApplyItemStats(pair.Value, attributes, moduleScalars, characterScalars);
            }
        }

        foreach (var pair in _fallbackAttributes)
        {
            if (!attributes.ContainsKey(pair.Key))
            {
                attributes.Add(pair.Key, pair.Value);
            }
        }

        foreach (var pair in _fallbackModuleScalars)
        {
            if (!moduleScalars.ContainsKey(pair.Key))
            {
                moduleScalars.Add(pair.Key, pair.Value);
            }
        }

        foreach (var pair in _fallbackCharacterScalars)
        {
            if (!characterScalars.ContainsKey(pair.Key))
            {
                characterScalars.Add(pair.Key, pair.Value);
            }
        }

        ItemAttributes = attributes;
        ItemModuleScalars = moduleScalars;
        ItemCharacterScalars = characterScalars;
    }
}