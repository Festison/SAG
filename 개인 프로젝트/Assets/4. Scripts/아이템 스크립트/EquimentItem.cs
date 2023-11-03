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
                player.damage += 5;
                break;
            case EquimentItemType.Top:
                player.maxHp += 20;
                break;
            case EquimentItemType.Bottom:
                player.maxHp += 20;
                break;
            case EquimentItemType.Hat:
                player.maxHp += 10;
                break;
            case EquimentItemType.Gloves:
                player.maxMp += 20;
                break;
            case EquimentItemType.Shoes:
                player.maxMp += 20;
                break;
            case EquimentItemType.Ring:
                player.damage += 3;
                break;
            case EquimentItemType.Earring:
                player.damage += 3;
                break;
        }
    }
}
