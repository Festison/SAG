using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : StateMachineBehaviour
{
    private Monster monster;
    private CircleCollider2D CircleCollider2D;

    // ���¿� ���� �� ��
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        monster = animator.GetComponent<Monster>();
        CircleCollider2D = monster.GetComponent<CircleCollider2D>();       
    }

    // ���°� ���� ���� ��
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        CircleCollider2D.enabled = true;
    }

    // ���¿��� ���� ��
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        monster.atkDelay = monster.atkCooltime;
        CircleCollider2D.enabled = false;
    }
}
