using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public enum EquimentSlotType
{
    Weapon,
    Top,
    Bottom,
    Hat,
    Gloves,
    Shoes,
    Ring,
    Earring
}

public class EquimentSlot : Slot
{
    public EquimentSlotType equimentSlotType;

    public override void SetItem(Item item)
    {
        base.SetItem(item);

        if (item is EquimentItem)
        {
            item.Equipment(FindObjectOfType<PlayerController>());
        }

        switch (equimentSlotType)
        {
            case EquimentSlotType.Weapon:
                break;
            case EquimentSlotType.Top:
                break;
            case EquimentSlotType.Bottom:
                break;
            case EquimentSlotType.Hat:
                break;
            case EquimentSlotType.Gloves:
                break;
            case EquimentSlotType.Shoes:
                break;
            case EquimentSlotType.Ring:
                break;
            case EquimentSlotType.Earring:
                break;
        }
    }
}

