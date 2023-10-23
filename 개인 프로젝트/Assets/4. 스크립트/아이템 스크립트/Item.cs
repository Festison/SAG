using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public int value;
    public Sprite itemSprite;
    public string itemName;
  
    public void Use(PlayerController player)
    {
        player.Hp += value;
    }
}
