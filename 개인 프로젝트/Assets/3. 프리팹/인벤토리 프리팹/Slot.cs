using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Slot : MonoBehaviour,IPointerDownHandler,IPointerUpHandler,IPointerClickHandler
{
    public Image itemImage;
    public TextMeshProUGUI itemNameText;
    public Item item;

    public void OnPointerClick(PointerEventData eventData)
    {
        if(item != null)
        {
            item.Use(FindObjectOfType<PlayerController>());
            SetItem(null);
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log(gameObject.name + "´Ù¿î");
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        Slot swapTargetSlot = eventData.pointerEnter.gameObject.GetComponent<Slot>();
        if (swapTargetSlot != null)
        {
            Item tempItem = swapTargetSlot.item;
            swapTargetSlot.SetItem(item);
            SetItem(tempItem);
        }
        Debug.Log(gameObject.name + "¾÷");
    }

    public void SetItem(Item item)
    {
        this.item = item;
        if(this.item == null)
        {
            itemImage.sprite = null;
            itemNameText.text = "";
        }
        else
        {
            itemImage.sprite = this.item.itemSprite;
            itemNameText.text = this.item.itemName;
        }
        
    }

}
