using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestOpen : MonoBehaviour
{
    private Animator chestAnimation;

    [Header("들어있는 아이템")]
    public GameObject[] items;
    public int randomItem;


    private void Start()
    {
        chestAnimation = GetComponent<Animator>();
        randomItem = Random.Range(0, 2);
    }


    public void Break()
    {
        chestAnimation.SetTrigger("Break");
        Destroy(gameObject, 2);
    }

    public void ItemDrop()
    {
        Instantiate(items[randomItem], gameObject.transform.position + Vector3.down / 3, Quaternion.identity);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.GetComponent<Berserker>() != null && Input.GetKeyDown(KeyCode.F))
        {
            Debug.Log("충돌");
            Break();
        }
    }

}

