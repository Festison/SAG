using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public interface IHitable
{
    // �������� �޴´�.
    public void Hit(float Damage);
}

public class Monster : MonoBehaviour,IHitable
{
    [Header("���� UI ����")]
    public Transform m_Canvas_Trans;
    public Image HpBarImage;

    private Animator monsterAnimation;
    private SpriteRenderer spriteRenderer;

    [Header("�÷��̾� ��ġ")]
    public Transform player;

    [Header("���� �������ͽ�")]
    [SerializeField]
    public float speed = 2f;
    [SerializeField]
    private float hp=30;
    [SerializeField]
    private float maxhp = 30;
    [SerializeField]
    private int monsterDamage = 5;
 
    [Header("���� ���� ��Ÿ��")]
    public float atkCooltime = 1.2f;
    public float atkDelay;

    private bool isBackHome;
    private float dir;
    [Header("���Ͱ� �ǵ��ư� ��ǥ")]
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

    [Header("���� �ǰݽ� ���� ����Ʈ")]
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

    // ���� ��Ÿ��
    public void AttackCoolTime()
    {
        if (atkDelay >= 0)
        {
            atkDelay -= Time.deltaTime;
        }
    }

    // �¿� ����
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

    // ���� �ǰ�
    public void Hit(float Damage)
    {
        Hp -= Damage;

        if (Damage > 0)
        {
            SetCreateBloodEffect(Damage);
        }         
    }
}
