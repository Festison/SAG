using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public interface IAttackabe
{
    void Attack(IHitable hitable);
}
public class Monster : MonoBehaviour, IHitable, IAttackabe
{
    [Header("���� UI ����")]
    public Transform m_Canvas_Trans;
    public Image HpBarImage;
    private float lerpSpeed = 10;

    public Animator monsterAnimation;

    [Header("�÷��̾� ��ġ")]
    public Transform player;

    [Header("���� �������ͽ�")]
    [SerializeField]
    public float speed = 2f;
    [SerializeField]
    private float hp = 30;
    [SerializeField]
    private float maxhp = 30;
    [SerializeField]
    public int monsterDamage = 5;
    public float dropExp = 10;

    [Header("���� ���� ��Ÿ��")]
    public float atkCooltime = 1.2f;
    public float atkDelay;

    private bool isBackHome;
    public float dir;
    [Header("���Ͱ� �ǵ��ư� ��ǥ")]
    public Vector2 home;

    private Berserker berserker;

    public bool IsBackHome
    {
        get
        {
            return isBackHome;
        }
        set
        {
            isBackHome = value;

            if (isBackHome == false)
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

            if (hp <= 0)
            {
                Die();
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
        player = GameObject.FindGameObjectWithTag("Player").transform;
        berserker = GameObject.FindGameObjectWithTag("Player").GetComponent<Berserker>();
        home = transform.position;
        IsBackHome = false;
    }

    void Update()
    {
        AttackCoolTime();
        Flip();
        HpLerp();
    }

    public void HpLerp()
    {
        HpBarImage.fillAmount = Mathf.Lerp(HpBarImage.fillAmount, Hp / maxhp, Time.deltaTime * lerpSpeed);
    }

    public void Die()
    {
        isDie = true;
        monsterAnimation.SetTrigger("Die");
        m_Canvas_Trans.gameObject.SetActive(false);
        berserker.Exp += dropExp;
        Destroy(gameObject, 2);
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
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else
        {
            transform.localScale = new Vector3(1, 1, 1);
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

    void IAttackabe.Attack(IHitable hitable)
    {
        throw new System.NotImplementedException();
    }
}
