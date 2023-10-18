using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public interface IHitable
{
    // 데미지를 받는다.
    public void Hit(float Damage);
}

public class Monster : MonoBehaviour,IHitable
{
    [Header("몬스터 UI 셋팅")]
    public Transform m_Canvas_Trans;
    public Image HpBarImage;

    private Animator monsterAnimation;
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
    private float dir;
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

    public float Hp
    {
        get
        {
            return hp;
        }
        set
        {
            hp = value;
            HpBarImage.fillAmount = hp / maxhp;

            if (hp <= 0)
            {             
                monsterAnimation.SetTrigger("Die");
                m_Canvas_Trans.gameObject.SetActive(false);
                Destroy(gameObject, 2);
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
