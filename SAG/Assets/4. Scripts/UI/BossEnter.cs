using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossEnter : MonoBehaviour
{
    public GameObject BossHpUI;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.GetComponent<Berserker>()!=null)
        {
            BossHpUI.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<Berserker>() != null)
        {
            BossHpUI.SetActive(false);
        }
    }
}
