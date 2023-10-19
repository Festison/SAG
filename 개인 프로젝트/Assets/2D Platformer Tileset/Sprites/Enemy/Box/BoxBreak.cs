using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxBreak : MonoBehaviour, IHitable
{
    [SerializeField]
    private float hp = 10;
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
    }

    public void Break()
    {
        isBreak = true;
        boxAnimation.SetTrigger("Break");
        Instantiate(Coin, transform.position + Vector3.down / 3, Quaternion.identity);
        Destroy(gameObject, 2);
    }

    public void Hit(float Damage)
    {
        Hp -= Damage;
    }  
}
