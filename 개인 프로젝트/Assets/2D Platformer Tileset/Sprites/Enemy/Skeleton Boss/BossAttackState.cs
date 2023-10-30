using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttackState : StateMachineBehaviour
{
    private BossMonster monster;
    private CircleCollider2D CircleCollider2D;

    // 상태에 진입 할 때
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        monster = animator.GetComponent<BossMonster>();
        CircleCollider2D = monster.GetComponent<CircleCollider2D>();
        CircleCollider2D.enabled = true;
    }

    // 상태가 진행 중일 때
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        CircleCollider2D.enabled = false;
    }

    // 상태에서 나갈 때
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        GameObject game = Resources.Load<GameObject>("BossSkill");
        Instantiate(game, monster.transform.position + Vector3.down * 5, monster.transform.rotation);
        monster.atkDelay = monster.atkCooltime;
    }
}
