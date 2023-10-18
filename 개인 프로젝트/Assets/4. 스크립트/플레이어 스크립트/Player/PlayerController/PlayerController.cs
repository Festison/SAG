using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerController : MonoBehaviour, IHitable
{
    [Header("현재 점프한 횟수")]
    public int currentJumpCount = 0;
    protected int JumpCount = 2;                   // 최대 점프 수

    [Space(10)]
    [Header("현재 플레이어 상태")]
    public bool IsSit = false;
    public bool IsGrounded = false;
    public bool IsJumping = false;
    public bool IsDownJumpCheck = false;   // 다운 점프를 하는데 아래 블록인지 그라운드인지 알려주는 불값

    [Space(10)]
    [Header("[스텟]")]
    [Range(0, 10)]
    public float MoveSpeed = 6;
    [Range(0, 30)]
    public float jumpForce = 15f;
    [Range(0, 20)]
    public float damage = 10;

    [Space(10)]
    [Header("플레이어 리지드바디")]
    public Rigidbody2D rigidbody;

    [Space(10)]
    [Header("피격시 나올 이펙트")]
    public GameObject BloodPrefab;

    protected float m_MoveX;
    protected CapsuleCollider2D CapsulleCollider;
    protected Animator Anime;

    // 좌우 반전 함수
    protected void Filp(bool bLeft)
    {
        transform.localScale = new Vector3(bLeft ? 1 : -1, 1, 1);
    }

    // 점프 함수
    protected void prefromJump()
    {
        Anime.Play("Jump");

        rigidbody.velocity = new Vector2(0, 0);

        rigidbody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);

        IsJumping = true;
        IsGrounded = false;

        currentJumpCount++;
    }

    // 다운 점프 함수
    protected void DownJump()
    {
        if (!IsGrounded)
        {
            return;
        }

        if (!IsDownJumpCheck)
        {
            Anime.Play("Jump");

            rigidbody.AddForce(-Vector2.up * 10);
            IsGrounded = false;

            CapsulleCollider.enabled = false;

            StartCoroutine(GroundCapsulleColliderTimmerFuc());
        }
    }

    // 캡슐 콜라이더가 활성화 되어있을시에만 다운점프가 가능
    IEnumerator GroundCapsulleColliderTimmerFuc()
    {
        yield return new WaitForSeconds(0.3f);
        CapsulleCollider.enabled = true;
    }

    protected abstract void IdleState();

    public abstract void Hit(float monsterDamage);

    public abstract void DefaulAttack(GameObject hitMonster);
    public abstract void Rush(GameObject hitMonster);

    public abstract void LifeStealEnter();

    protected bool IsRushState = false;
    public abstract void RushEnter();
    public abstract void RushExit();
    public abstract void AuraBladeEnter();
    public abstract void DieEnter();
}
