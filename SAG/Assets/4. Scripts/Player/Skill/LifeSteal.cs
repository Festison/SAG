using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeSteal : MonoBehaviour
{
    public float movingSpeed = 4f;
    public float SmoothDamp = 1f;

    public bool ISMon = true;

    public float Damage = 0;
    public Vector3 TargetDir;

    public GameObject TartgetObj;
    private Rigidbody2D rigidbody;

    void Awake()
    {
        rigidbody = this.transform.GetComponent<Rigidbody2D>();  
    }

    public void Fire(float damage)
    {
        Damage = damage;
        TartgetObj = GameManager.UI.CurrentPlayerObj;
        TargetDir = TartgetObj.transform.position - this.transform.position;
        this.transform.right = TargetDir;      
    }

    void Update()
    {
        //타겟 동기화는 0.5초에 한번씩 해준다. 
        smoothMove();
    }

    private Vector2 Velocity = Vector2.zero;
    void smoothMove()
    {
        //회전
        if (TartgetObj == null)
        {
            Destroy(this.gameObject);
            return;
        }
     
        TargetDir = TartgetObj.transform.position - this.transform.position;
        this.transform.right = Vector2.SmoothDamp(this.transform.right, TargetDir, ref Velocity, SmoothDamp);
        this.transform.Translate(Vector2.right * Time.deltaTime * movingSpeed);
    }

    void OnTriggerEnter2D(Collider2D other)
    {     
        if (other.CompareTag("Player"))
        {
            Destroy(this.gameObject);
        }
    }

    
}
