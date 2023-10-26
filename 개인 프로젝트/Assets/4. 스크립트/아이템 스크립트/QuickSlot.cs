using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class QuickSlot : Slot
{
    public override void SetItem(Item item)
    {
        this.item = item;
        if (this.item == null)
        {
            itemImage.sprite = null;
        }
        else
        {
            itemImage.sprite = this.item.itemSprite;
        }
    }
}
