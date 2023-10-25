using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Berserker : PlayerController
{
    private void Start()
    {
        CapsulleCollider = this.transform.GetComponent<CapsuleCollider2D>();
        Anime = this.transform.Find("model").GetComponent<Animator>();
        rigidbody = this.transform.GetComponent<Rigidbody2D>();

        StartCoroutine(MpRecovery());
        SkillCoolTimeInit();
        
    }

    private void Update()
    {
        CheckInput();
        StatusLerp();

        if (rigidbody.velocity.magnitude > 30)
        {
            rigidbody.velocity = new Vector2(rigidbody.velocity.x - 0.1f, rigidbody.velocity.y - 0.1f);
        }
    }

    public void StatusLerp()
    {
        hpText.text = Hp + " / " + maxHp;
        HpBarImage.fillAmount = Mathf.Lerp(HpBarImage.fillAmount, Hp / maxHp, Time.deltaTime * lerpSpeed);
        mpText.text = Mp + " / " + maxMp;
        MpBarImage.fillAmount = Mathf.Lerp(MpBarImage.fillAmount, Mp / maxMp, Time.deltaTime * lerpSpeed);
        expText.text = Exp + " / " + maxExp;
        ExpBarImage.fillAmount = Mathf.Lerp(ExpBarImage.fillAmount, Exp / maxExp, Time.deltaTime * lerpSpeed);
        levelText.text = "Lv. " + Level;
    }

    public void SkillCoolTimeInit()
    {
        lifeStealCoolTimeImage.fillAmount = 0;
        //rushCoolTimeImage.fillAmount = 0;
        //auraBladeCoolTimeImage.fillAmount = 0;
    }

    public void CheckInput()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1) && Mp >= 10 && !islifeStealCoolTime)
        {
            Anime.Play("LifeSteal");
            islifeStealCoolTime = true;
            lifeStealCoolTimeText.text = "";
            lifeStealCoolTimeImage.fillAmount = 1;
            StartCoroutine(LifeStealCoolTime());
        }
        if (Input.GetKeyDown(KeyCode.Alpha2) && Mp >= 10 && !isRushCoolTime)
        {
            Anime.Play("Rush");
            isRushCoolTime = true;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3) && Mp >= 10 && !isAuraBladeCoolTime)
        {
            Anime.Play("AuraBlade");
            isAuraBladeCoolTime = true;
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            Anime.Play("Die");
        }

        if (Anime.GetCurrentAnimatorStateInfo(0).IsName("Rush"))
        {
            if (IsRushState)
            {
                transform.transform.Translate(new Vector3(-transform.localScale.x * 25f * Time.deltaTime, 0, 0));
            }
            else
            {
                if (moveX < 0)
                {
                    if (transform.localScale.x > 0)
                    {
                        transform.transform.Translate(new Vector3(moveX * MoveSpeed * Time.deltaTime, 0, 0));
                    }
                }
                else if (moveX > 0)
                {
                    if (transform.localScale.x < 0)
                    {
                        transform.transform.Translate(new Vector3(moveX * MoveSpeed * Time.deltaTime, 0, 0));
                    }
                }
            }
        }

        if (Anime.GetCurrentAnimatorStateInfo(0).IsName("LifeSteal")
            || Anime.GetCurrentAnimatorStateInfo(0).IsName("Rush")
            || Anime.GetCurrentAnimatorStateInfo(0).IsName("AuraBlade"))
        {

            return;
        }

        if (Input.GetKey(KeyCode.Mouse1))
        {
            Anime.Play("Guard");
            return;
        }
        if (Input.GetKeyDown(KeyCode.S))  //아래 버튼 눌렀을때. 
        {
            IsSit = true;
            Anime.Play("Sit");
        }
        else if (Input.GetKeyUp(KeyCode.S))
        {
            Anime.Play("Idle");
            IsSit = false;
        }

        // sit나 die일때 애니메이션이 돌때는 다른 애니메이션이 되지 않게 한다. 
        if (Anime.GetCurrentAnimatorStateInfo(0).IsName("Sit") || Anime.GetCurrentAnimatorStateInfo(0).IsName("Die"))
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (currentJumpCount < JumpCount)
                {
                    DownJump();
                }
            }
            return;
        }

        moveX = Input.GetAxis("Horizontal");

        // 공격 상태가 아닐 때
        if (!Anime.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
        {
            if (Input.GetKey(KeyCode.Mouse0))
            {
                Anime.Play("Attack");
            }
            else
            {
                if (moveX == 0)
                {
                    if (!IsJumping)
                    {
                        Anime.Play("Idle");
                    }
                }
                else
                {
                    Anime.Play("Run");
                }
            }
        }

        // 우측 이동
        if (Input.GetKey(KeyCode.D))
        {
            if (IsGrounded)  // 땅바닥에 있었을때. 
            {
                if (Anime.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
                {
                    return;
                }

                transform.Translate(Vector2.right * moveX * MoveSpeed * Time.deltaTime);
            }
            else
            {
                transform.Translate(new Vector3(moveX * MoveSpeed * Time.deltaTime, 0, 0));
            }
            if (Anime.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
            {
                return;
            }
            if (!Input.GetKey(KeyCode.A))
            {
                Filp(false);
            }
        }

        // 좌측 이동
        else if (Input.GetKey(KeyCode.A))
        {
            if (IsGrounded)  // 땅바닥에 있었을때. 
            {
                if (Anime.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
                {
                    return;
                }

                transform.transform.Translate(Vector2.right * moveX * MoveSpeed * Time.deltaTime);
            }
            else
            {
                transform.transform.Translate(new Vector3(moveX * MoveSpeed * Time.deltaTime, 0, 0));
            }
            if (Anime.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
            {
                return;
            }
            if (!Input.GetKey(KeyCode.D))
            {
                Filp(true);
            }
        }

        // 점프
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (Anime.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
            {
                return;
            }
            if (currentJumpCount < JumpCount)
            {
                if (!IsSit)
                {
                    prefromJump();
                }
                else
                {
                    DownJump();
                }
            }
        }
    }

    // 달리지 않고 공격하지 않는 상태일시 가만히 있는 애니메이션 재생
    protected override void IdleState()
    {
        if (!Anime.GetCurrentAnimatorStateInfo(0).IsName("Run") && !Anime.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
        {
            Anime.Play("Idle");
        }
    }

    public override void Hit(float monsterDamage)
    {
        Hp -= monsterDamage;

        if (monsterDamage > 0)
        {
            SetCreateBloodEffect(monsterDamage);
        }
    }

    public void SetCreateBloodEffect(float Damage)
    {
        Instantiate(BloodPrefab, transform.position, Quaternion.identity);

        float RandomX = UnityEngine.Random.Range(0, 0.5f);
    }

    public override void DefaulAttack(GameObject hitMonster)
    {
        if (hitMonster.GetComponent<IHitable>() != null)
        {
            hitMonster.transform.GetComponent<IHitable>().Hit(damage);
        }
    }

    [Space(10)]
    [Header("플레이어 스킬")]
    public GameObject lifeStealPrefab;
    public GameObject rushPrefab;
    public GameObject auraBladePrefab;

    [Space(10)]
    [Header("스킬 쿨타임")]
    public float lifeStealCoolTime = 3.0f;
    public float rushCoolTime = 2.0f;
    public float auraBladeCoolTime = 4.0f;

    public float lifeStealCoolTimeMax = 3.0f;
    public float rushCoolTimeMax = 2.0f;
    public float auraBladeCoolTimeMax = 4.0f;

    [Space(10)]
    [Header("스킬 쿨타임 텍스트")]
    public TextMeshProUGUI lifeStealCoolTimeText;
    public TextMeshProUGUI rushCoolTimeText;
    public TextMeshProUGUI auraBladeCoolTimeText;
    public Image lifeStealCoolTimeImage;
    public Image rushCoolTimeImage;
    public Image auraBladeCoolTimeImage;

    [Space(10)]
    [Header("스킬 쿨타임 상태")]
    public bool islifeStealCoolTime=false;
    public bool isRushCoolTime=false;
    public bool isAuraBladeCoolTime=false;

    // 드레인 기술
    public override void LifeStealEnter()
    {
        Mp -= 10;
        const int hpRecorvery = 1;

        Collider2D[] cols = Physics2D.OverlapCircleAll(transform.position, 5f);
        foreach (var hitMonster in cols)
        {
            if (hitMonster.GetComponent<Monster>() != null)
            {
                GameObject lifeSteal = Instantiate(this.lifeStealPrefab, hitMonster.transform.position, Quaternion.identity);
                lifeSteal.GetComponent<LifeSteal>().Fire(5);
                hitMonster.transform.GetComponent<Monster>().Hit(5f);
                Hp += hpRecorvery * hitMonster.shapeCount;
            }
        }
        
    }

    // 레이캐스트 확인
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, 5f);
    }

    // 돌진 기술
    public override void Rush(GameObject hitMonster)
    {
        if (hitMonster.GetComponent<IHitable>() != null)
        {
            hitMonster.transform.GetComponent<IHitable>().Hit(damage * 2);
        }
    }

    public override void RushEnter()
    {
        Mp -= 10;
        IsRushState = true;
        GameObject rush = Instantiate(rushPrefab, transform.position, Quaternion.identity);
        rush.transform.localScale = new Vector3(-1 * transform.localScale.x, 1, 1);
        rush.transform.SetParent(this.transform);
        rush.transform.localPosition = new Vector3(-1.37f, 0.179f, 1);
        
    }

    public override void RushExit()
    {
        IsRushState = false;
    }

    // 검기 발사 기술
    public override void AuraBladeEnter()
    {
        Mp -= 10;
        GameObject auraBlade = Instantiate(auraBladePrefab, transform.position, Quaternion.identity);
        Vector3 auraBladeDir = transform.localScale.x * this.transform.right;
        auraBlade.GetComponent<AuraBlade>().Fire(auraBladeDir);
        
    }

    public override void DieEnter()
    {
        IsDie = true;
    }

    IEnumerator MpRecovery()
    {
        while (!IsDie)
        {
            Mp += 10;
            yield return new WaitForSeconds(mpRecovery);
        }      
    }

    IEnumerator LifeStealCoolTime()
    {
       while(true)
        { 
            if (islifeStealCoolTime)
            {
                yield return new WaitForSeconds(lifeStealCoolTime);
                islifeStealCoolTime = false;
            }
        } 
    }

    //IEnumerator TestCo()
    //{
    //    while (lifeStealCoolTimeImage.fillAmount > 0)
    //    {
    //        lifeStealCoolTimeImage.fillAmount -= Time.smoothDeltaTime / lifeStealCoolTime;
    //        yield return null;
    //    }
    //}


    IEnumerator LifeStealCountCoroutine(float currentCoolTime) //스킬 쿨타임 텍스트 표시
    {
        if (currentCoolTime > 0)
        {
            currentCoolTime -= 1;

            lifeStealCoolTimeText.text = currentCoolTime.ToString()+"초";

            yield return new WaitForSeconds(1f);
            StartCoroutine(LifeStealCountCoroutine(currentCoolTime));
        }
        else if (lifeStealCoolTimeImage.fillAmount == 0)
        {
            lifeStealCoolTimeText.text = "";
        }
    }


    public InventoryUI inven;
    // 피격
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Monster>() != null && collision is CircleCollider2D)
        {
            Debug.Log("몬스터 공격 맞음");
            Hit(5);
        }       
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.GetComponent<Item>() != null && Input.GetKeyDown(KeyCode.Z))
        {
            Debug.Log("아이템 먹음");
            inven.AddItem(collision.GetComponent<Item>());
            collision.gameObject.SetActive(false);
        }        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.GetComponent<Trap>()!=null)
        {
            Hit(5);
        }
    }


}