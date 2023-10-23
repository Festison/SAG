using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public Slot[] slots = new Slot[3];

    public void AddItem(Item item)
    {
        for (int i = 0; i < slots.Length;i++)
        {
            if (slots[i].item == null)
            {
                slots[i].SetItem(item);
                return;
            }
        }
    }
}
