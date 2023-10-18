using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Monster : MonoBehaviour,IHitable
{
    [Header("몬스터 UI 셋팅")]
    public Transform m_Canvas_Trans;
    public Image HpBarImage;

    public Animator monsterAnimation;
    private SpriteRenderer spriteRenderer;

    [Header("플레이어 위치")]
    public Transform player;

    [Header("몬스터 스테이터스")]
    [SerializeField]
    public float speed = 2f;
    [SerializeField]
    private float hp=30;
    [SerializeField]
    private float maxhp = 30;
    [SerializeField]
    private int monsterDamage = 5;
 
    [Header("몬스터 공격 쿨타임")]
    public float atkCooltime = 1.2f;
    public float atkDelay;

    private bool isBackHome;
    public float dir;
    [Header("몬스터가 되돌아갈 좌표")]
    public Vector2 home;

    public bool IsBackHome
    {
        get
        {
            return isBackHome;
        }
        set
        {
            isBackHome = value;

            if(isBackHome == false)
            {
                dir = player.position.x - transform.position.x;
            }
            else
            {
                dir = home.x - transform.position.x;
            }
        }
    }
    bool isDie = false;
    public float Hp
    {
        get
        {
            return hp;
        }
        set
        {
            if (isDie)
            {
                return;
            }
                
            hp = value;
            HpBarImage.fillAmount = hp / maxhp;

            if (hp <= 0)
            {
                Die();
            }
        }
    }

    [Header("몬스터 피격시 나올 이펙트")]
    public GameObject BloodEffect;
    public void SetCreateBloodEffect(float Damage)
    {
        Instantiate(BloodEffect, transform.position, Quaternion.identity);

        float RandomX = Random.Range(0, 0.5f);
    }

    void Start()
    {
        monsterAnimation = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        home = transform.position;
        IsBackHome = false;
    }

    void Update()
    {
        AttackCoolTime();
        Flip();
     
        if (monsterAnimation.GetCurrentAnimatorStateInfo(0).IsName("SpiderAttack"))
        {
            
        }
    }

    public void Die()
    {
        isDie = true;
        monsterAnimation.SetTrigger("Die");
        m_Canvas_Trans.gameObject.SetActive(false);
        Destroy(gameObject, 2);
    }

    // 공격 쿨타임
    public void AttackCoolTime()
    {
        if (atkDelay >= 0)
        {
            atkDelay -= Time.deltaTime;
        }
    }

    // 좌우 반전
    public void Flip()
    {
        if (dir < 0)
        {
            spriteRenderer.flipX = true;
        }
        else
        {
            spriteRenderer.flipX = false;
        }
    }

    // 몬스터 피격
    public void Hit(float Damage)
    {
        Hp -= Damage;

        if (Damage > 0)
        {
            SetCreateBloodEffect(Damage);
        }         
    }
}
