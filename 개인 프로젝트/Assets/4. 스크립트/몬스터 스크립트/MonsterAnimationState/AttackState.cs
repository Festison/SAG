using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : StateMachineBehaviour
{
    private Monster monster;
    private CircleCollider2D CircleCollider2D;

    // 상태에 진입 할 때
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        monster = animator.GetComponent<Monster>();
        CircleCollider2D = monster.GetComponent<CircleCollider2D>();       
    }

    // 상태가 진행 중일 때
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        CircleCollider2D.enabled = true;
    }

    // 상태에서 나갈 때
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        monster.atkDelay = monster.atkCooltime;
        CircleCollider2D.enabled = false;
    }
}
