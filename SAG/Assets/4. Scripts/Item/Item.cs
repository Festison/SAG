using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public Sprite itemSprite;
    public string itemName;

    public virtual void Use(PlayerController player)
    {

    }

    public virtual void Equipment(PlayerController player)
    {

    }
}
