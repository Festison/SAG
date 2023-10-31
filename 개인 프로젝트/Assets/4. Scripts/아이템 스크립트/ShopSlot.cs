using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ShopSlot : MonoBehaviour, IPointerClickHandler
{
    public Image itemImage;
    public TextMeshProUGUI itemNameText;
    public Item item;
    public InventoryUI inven;
    public PlayerController player;

    private void Start()
    {
        player = FindObjectOfType<PlayerController>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (item != null)
        {
            if (item is ConsumableItem && player.Coin >= 100)
            {
                inven.AddItem(item);
                player.Coin -= 100;
            }
        }
    }


    public virtual void SetItem(Item item)
    {
        this.item = item;
        if (this.item == null)
        {
            itemImage.sprite = null;
            if (itemNameText != null)
            {
                itemNameText.text = "";
            }
        }
        else
        {
            itemImage.sprite = this.item.itemSprite;
            itemNameText.text = this.item.itemName;
        }
    }
}

