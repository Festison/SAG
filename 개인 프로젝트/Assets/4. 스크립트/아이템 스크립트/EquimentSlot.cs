using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;



public class EquimentSlot : Slot
{
    public EquimentItemType equimentSlotType;
    public EquimentItem equimentItem;

    private void Update()
    {
        
    }

    public override void SetItem(Item item)
    {

        if (item is EquimentItem)
        {
            item.Equipment(FindObjectOfType<PlayerController>());
            if(equimentSlotType == ((EquimentItem)item).equimentItemType)
            {
                base.SetItem(item);
            }
            else
            {

            }
        }

     
    }
}

