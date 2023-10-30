using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopNpc : MonoBehaviour
{
    public GameObject ShopUI;
    public GameObject Cansvas;

    private void OnTriggerStay2D(Collider2D collision)
    {
        Cansvas.SetActive(true);
        if (collision.GetComponent<Berserker>() != null && Input.GetKeyDown(KeyCode.F))
        {
            ShopUI.SetActive(true);           
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Cansvas.SetActive(false);
        ShopUI.SetActive(false);
    }
}
