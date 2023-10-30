using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossRunState : StateMachineBehaviour
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
        Vector2 tmpEnemyPosition = enemyTransform.transform.position;
        tmpEnemyPosition = new Vector2(tmpEnemyPosition.x, enemyTransform.position.y);

        if (Vector2.Distance(enemyTransform.position, enemy.player.position) > 20)
        {
            animator.SetBool("IsFollow", false);
            animator.SetBool("IsBack", true);
        }
        else if (Vector2.Distance(enemyTransform.position, enemy.player.position) > 16f)
        {
            enemy.IsBackHome = false;
            enemyTransform.position = Vector2.MoveTowards(enemyTransform.transform.position, enemy.player.transform.position, Time.deltaTime * enemy.speed);
            enemyTransform.position = new Vector3(enemyTransform.position.x, tmpEnemyPosition.y, enemyTransform.position.z);
        }
        else
        {
            animator.SetBool("IsFollow", false);
            animator.SetBool("IsBack", false);
        }
    }
}
