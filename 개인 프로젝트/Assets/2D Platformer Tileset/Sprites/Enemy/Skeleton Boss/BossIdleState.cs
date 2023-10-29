using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossIdleState : StateMachineBehaviour
{
    private Transform enemyTransform;
    private BossMonster bossmonster;

    // ���¿� ���� �� ��
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        bossmonster = animator.GetComponent<BossMonster>();
        enemyTransform = animator.GetComponent<Transform>();
    }

    // ���°� ���� ���� ��
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (Vector2.Distance(enemyTransform.position, bossmonster.player.position) <= 16)
        {
            animator.SetBool("IsFollow", true);
        }
    }
}
