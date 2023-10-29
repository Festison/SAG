using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossIdleState : StateMachineBehaviour
{
    private Transform enemyTransform;
    private BossMonster bossmonster;

    // 상태에 진입 할 때
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        bossmonster = animator.GetComponent<BossMonster>();
        enemyTransform = animator.GetComponent<Transform>();
    }

    // 상태가 진행 중일 때
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (Vector2.Distance(enemyTransform.position, bossmonster.player.position) <= 16)
        {
            animator.SetBool("IsFollow", true);
        }
    }
}
