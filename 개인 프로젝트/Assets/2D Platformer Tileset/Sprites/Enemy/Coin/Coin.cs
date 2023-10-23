using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private int maxBounce = 10;

    private float xForce = 10;
    private float yForce = 15;

    private Vector2 dir;
    private int currentBounce = 0;
    private bool isGrounded = true;

    private float maxHeight;
    private float currentheight;

    private Transform cointransform;

    private void Start()
    {
        cointransform = GetComponent<Transform>();
        currentheight = Random.Range(yForce - 1, yForce);
        maxHeight = currentheight;
        Initialize(new Vector2(Random.Range(-xForce, xForce), Random.Range(-xForce, xForce)));
    }

    private void Update()
    {
        if (!isGrounded)
        {
            cointransform.position += new Vector3(0, currentheight, 0) * Time.deltaTime;
            transform.position += (Vector3)dir * Time.deltaTime;
            CheckGroundHit();
        }
    }

    void Initialize(Vector2 direction)
    {
        isGrounded = false;
        maxHeight /= 1.5f;
        dir = direction;
        currentheight = maxHeight;
        currentBounce++;
    }

    void CheckGroundHit()
    {
        if (currentBounce < maxBounce)
        {
            Initialize(dir / 1.5f);
        }
        else
        {
            isGrounded = true;
        }
    }

    

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Berserker berserkerCoin = collision.collider.GetComponent<Berserker>();

        if (berserkerCoin != null)
        {
            berserkerCoin.Coin += 10;
            Debug.Log("ÄÚÀÎ È¹µæ");          
            Destroy(this.gameObject);
        }
    }
}
