using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBackState : StateMachineBehaviour
{
    private Transform enemyTransform;
    private BossMonster enemy;

    // ���¿� ���� �� ��
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        enemy = animator.GetComponent<BossMonster>();
        enemyTransform = animator.GetComponent<Transform>();
    }

    // ���°� ���� ���� ��
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (Vector2.Distance(enemy.home, enemyTransform.position) < 0.1f || Vector2.Distance(enemyTransform.position, enemy.player.position) < 16f)
        {
            animator.SetBool("IsBack", false);
            animator.SetBool("IsFollow", false);
        }
        else
        {
            enemy.IsBackHome = true;
            enemyTransform.position = Vector2.MoveTowards(enemyTransform.transform.position, enemy.home, Time.deltaTime * enemy.speed);
        }
    }
}
