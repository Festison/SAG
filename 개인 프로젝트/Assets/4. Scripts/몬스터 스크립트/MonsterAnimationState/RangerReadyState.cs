using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangerReadyState : StateMachineBehaviour
{
    private Transform enemyTransform;
    private Monster enemy;

    // 상태에 진입 할 때
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        enemy = animator.GetComponent<Monster>();
        enemyTransform = animator.GetComponent<Transform>();
    }

    // 상태가 진행 중일 때
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (enemy.atkDelay <= 0 && Vector2.Distance(enemy.player.transform.position, enemyTransform.position) < 8f)
        {
            animator.SetTrigger("Attack");
        }

        if (Vector2.Distance(enemy.player.position, enemyTransform.position) > 8f)
        {
            animator.SetBool("IsFollow", true);
        }
    }
}
