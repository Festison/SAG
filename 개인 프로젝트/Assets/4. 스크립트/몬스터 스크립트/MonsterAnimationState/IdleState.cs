using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : StateMachineBehaviour
{
    private Transform enemyTransform;
    private Monster monster;

    // 상태에 진입 할 때
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        monster = animator.GetComponent<Monster>();
        enemyTransform = animator.GetComponent<Transform>();
    }

    // 상태가 진행 중일 때
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (Vector2.Distance(enemyTransform.position, monster.player.position) <= 8)
        {
            animator.SetBool("IsFollow", true);
        }
    }

    // 상태에서 나갈 때
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }


}
