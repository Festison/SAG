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

    public override void OnPointerUp(PointerEventData eventData)
    {
        Slot swapTargetSlot = eventData.pointerEnter.gameObject.GetComponent<Slot>();
        if (swapTargetSlot != null)
        { 
            Item tempItem = swapTargetSlot.item;
            swapTargetSlot.SetItem(item);
            //item.Equipment(FindObjectOfType<PlayerController>());
            SetItem(tempItem);
        }
        Debug.Log(gameObject.name + "¾÷");
    }
}

