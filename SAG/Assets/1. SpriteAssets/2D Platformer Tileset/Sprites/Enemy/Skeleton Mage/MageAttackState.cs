using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MageAttackState : StateMachineBehaviour
{
    private Monster monster;
    public GameObject game;

    // 상태에 진입 할 때
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        monster = animator.GetComponent<Monster>();

    }

    // 상태가 진행 중일 때
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {


    }

    // 상태에서 나갈 때
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        GameObject game = Resources.Load<GameObject>("Fireball");
        Instantiate(game, monster.transform.position, monster.transform.rotation);
        monster.atkDelay = monster.atkCooltime;
    }
}
