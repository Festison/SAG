using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class QuickSlot2 : Slot
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

    private void Update()
    {
        QuickSlotKey();
    }

    public void QuickSlotKey()
    {       
        if (item != null && Input.GetKeyDown(KeyCode.Alpha3))
        {
            item.Use(FindObjectOfType<PlayerController>());
            this.SetItem(null);
        }
    }
}
