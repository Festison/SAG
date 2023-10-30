using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSkill : MonoBehaviour
{
    public Transform player;
    public SpriteRenderer sprite;
    public Vector2 dir;
    public float arrowSpeed = 60;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        sprite = GetComponent<SpriteRenderer>();
        dir = player.position - transform.position;
        GetComponent<Rigidbody2D>().AddForce(dir * arrowSpeed, ForceMode2D.Force);

        if (player.position.x - transform.position.x < 0)
        {
            transform.localScale = new Vector3(-10, 10, 1);
        }
        else
        {
            transform.localScale = new Vector3(10, 10, 1);
        }
    }

    void Update()
    {
        Destroy(gameObject, 4);
    }
}
