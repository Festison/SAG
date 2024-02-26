using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyState : StateMachineBehaviour
{
    private Transform enemyTransform;
    private Monster enemy;

    // ���¿� ���� �� ��
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        enemy = animator.GetComponent<Monster>();
        enemyTransform = animator.GetComponent<Transform>();
    }

    // ���°� ���� ���� ��
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (Vector2.Distance(enemyTransform.position, enemy.player.position) > 8)
        {
            animator.SetBool("IsFollow", false);
            animator.SetBool("IsBack", true);
        }
        else if (Vector2.Distance(enemyTransform.position, enemy.player.position) > 0.5f)
        {
            enemy.IsBackHome = false;
            enemyTransform.position = Vector2.MoveTowards(enemyTransform.transform.position, enemy.player.transform.position, Time.deltaTime * enemy.speed);
        }
        else
        {
            animator.SetBool("IsFollow", false);
            animator.SetBool("IsBack", false);
        }
    }
}
