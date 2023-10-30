using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttackState : StateMachineBehaviour
{
    private BossMonster monster;
    private CircleCollider2D CircleCollider2D;

    // ���¿� ���� �� ��
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        monster = animator.GetComponent<BossMonster>();
        CircleCollider2D = monster.GetComponent<CircleCollider2D>();
        CircleCollider2D.enabled = true;
    }

    // ���°� ���� ���� ��
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        CircleCollider2D.enabled = false;
    }

    // ���¿��� ���� ��
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        GameObject game = Resources.Load<GameObject>("BossSkill");
        Instantiate(game, monster.transform.position + Vector3.down * 5, monster.transform.rotation);
        monster.atkDelay = monster.atkCooltime;
    }
}
