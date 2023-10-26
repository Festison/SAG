using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Potion
{
    RedPotion,
    BluePotion,
    GreenPotion
}

public class ConsumableItem : Item
{
    public Potion potion;

    public override void Use(PlayerController player)
    {
        switch (potion)
        {
            case Potion.RedPotion:
                player.Hp += 5;
                break;
            case Potion.BluePotion:
                player.Mp += 5;
                break;
            case Potion.GreenPotion:
                player.Exp += 5;
                break;
            default:
                break;
        }
    }
}
