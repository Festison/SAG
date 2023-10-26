using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EquimentItemType
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

public class EquimentItem : Item
{
    public EquimentItemType equimentItemType;
    public override void Equipment(PlayerController player)
    {
        switch (equimentItemType)
        {
            case EquimentItemType.Weapon:
                player.damage += 2;
                break;
            case EquimentItemType.Top:
                player.maxHp += 2;
                break;
            case EquimentItemType.Bottom:
                player.maxHp += 2;
                break;
            case EquimentItemType.Hat:
                player.maxHp += 1;
                break;
            case EquimentItemType.Gloves:
                player.maxMp += 2;
                break;
            case EquimentItemType.Shoes:
                player.maxMp += 2;
                break;
            case EquimentItemType.Ring:
                player.damage += 1;
                break;
            case EquimentItemType.Earring:
                player.damage += 1;
                break;
        }
    }
}
