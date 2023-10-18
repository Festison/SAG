using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Berserker : PlayerController
{
    public GameObject monster;
    private void Start()
    {
        CapsulleCollider = this.transform.GetComponent<CapsuleCollider2D>();
        Anime = this.transform.Find("model").GetComponent<Animator>();
        rigidbody = this.transform.GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        CheckInput();

        if (rigidbody.velocity.magnitude > 30)
        {
            rigidbody.velocity = new Vector2(rigidbody.velocity.x - 0.1f, rigidbody.velocity.y - 0.1f);
        }
    }

    public void CheckInput()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Anime.Play("LifeSteal");
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Anime.Play("Rush");
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            Anime.Play("AuraBlade");
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
                if (m_MoveX < 0)
                {
                    if (transform.localScale.x > 0)
                    {
                        transform.transform.Translate(new Vector3(m_MoveX * MoveSpeed * Time.deltaTime, 0, 0));
                    }
                }
                else if (m_MoveX > 0)
                {
                    if (transform.localScale.x < 0)
                    {
                        transform.transform.Translate(new Vector3(m_MoveX * MoveSpeed * Time.deltaTime, 0, 0));
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

        m_MoveX = Input.GetAxis("Horizontal");

        // 공격 상태가 아닐 때
        if (!Anime.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
        {
            if (Input.GetKey(KeyCode.Mouse0))
            {
                Anime.Play("Attack");
            }
            else
            {
                if (m_MoveX == 0)
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

                transform.transform.Translate(Vector2.right * m_MoveX * MoveSpeed * Time.deltaTime);
            }
            else
            {
                transform.transform.Translate(new Vector3(m_MoveX * MoveSpeed * Time.deltaTime, 0, 0));
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

                transform.transform.Translate(Vector2.right * m_MoveX * MoveSpeed * Time.deltaTime);
            }
            else
            {
                transform.transform.Translate(new Vector3(m_MoveX * MoveSpeed * Time.deltaTime, 0, 0));
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

        // 피 달게 한다. 
    }
    public override void DefaulAttack(GameObject hitMonster)
    {
        if (hitMonster.GetComponent<IHitable>() != null)
        {
            Monster monster = hitMonster.transform.GetComponent<Monster>();
            monster.Hit(damage);
        }
    }

    [Space(10)]
    [Header("플레이어 기술")]
    public GameObject lifeStealPrefab;
    public GameObject rushPrefab;
    public GameObject auraBladePrefab;

    // 드레인 기술
    public override void LifeStealEnter()
    {
        Collider2D[] cols = Physics2D.OverlapCircleAll(transform.position, 5f);

        foreach (var hitMonster in cols)
        {
            if (hitMonster.GetComponent<IHitable>() != null)
            {
                Debug.Log(monster.name);
                GameObject lifeSteal = Instantiate(this.lifeStealPrefab, monster.transform.position, Quaternion.identity);
                lifeSteal.GetComponent<LifeSteal>().Fire(5);
                Monster monster_hp = monster.transform.GetComponent<Monster>();
                monster_hp.GetComponent<Monster>().Hit(5f);
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
            Monster monster = hitMonster.transform.GetComponent<Monster>();
            monster.Hit(damage * 2);
        }
    }

    public override void RushEnter()
    {
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
        GameObject auraBlade = Instantiate(auraBladePrefab, transform.position, Quaternion.identity);
        Vector3 auraBladeDir = transform.localScale.x * this.transform.right;
        auraBlade.GetComponent<AuraBlade>().Fire(auraBladeDir);
    }

    public override void DieEnter()
    {
        Instantiate(BloodPrefab, this.transform.localPosition, Quaternion.identity);
    }
}