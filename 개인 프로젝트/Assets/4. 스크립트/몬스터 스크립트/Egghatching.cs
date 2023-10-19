using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Egghatching : MonoBehaviour, IHitable
{
    [Header("���� UI ����")]
    public GameObject Spider;
    public Transform m_Canvas_Trans;
    public Image HpBarImage;
    protected float lerpSpeed = 10;

    private Animator monsterAnimation;

    [Header("���� �������ͽ�")]
    [SerializeField]
    private float hp = 30;
    [SerializeField]
    private float maxhp = 30;

    [Header("�÷��̾� ��ġ")]
    public Transform player;

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
        StartCoroutine(Hatch());
    }

    private void Update()
    {
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
        Destroy(gameObject, 2);
    }

    // 10�ʵڿ� ��ȭ�ϴ� �ڵ�
    IEnumerator Hatch()
    {       
        yield return new WaitForSeconds(30f);
        Instantiate(Spider, gameObject.transform.position, Quaternion.identity);
        Die();
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

