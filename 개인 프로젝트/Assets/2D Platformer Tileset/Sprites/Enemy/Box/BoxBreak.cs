using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxBreak : MonoBehaviour, IHitable
{
    [SerializeField]
    private float hp = 30;
    private int dropCoinCount;
    public GameObject Coin;
    public Animator boxAnimation;

    private bool isBreak = false;

    public float Hp
    {
        get
        {
            return hp;
        }
        set
        {
            if (isBreak)
            {
                return;
            }

            hp = value;

            if (hp <= 0)
            {
                Break();
            }
        }
    }

    private void Start()
    {
        boxAnimation = GetComponent<Animator>();
        dropCoinCount = Random.Range(2, 8);
    }

    public void Break()
    {
        isBreak = true;
        boxAnimation.SetTrigger("Break");       
        Destroy(gameObject, 2);

        for (int i = 0; i < dropCoinCount; i++)
        {
            Instantiate(Coin, transform.position + Vector3.down / 3, Quaternion.identity);
        }
    }

    public void Hit(float Damage)
    {
        Hp -= Damage;
        boxAnimation.SetTrigger("Hit");
    }  
}
