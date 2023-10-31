using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangerAttackState : StateMachineBehaviour
{
    private Monster monster;
    public GameObject game;

    // ���¿� ���� �� ��
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        monster = animator.GetComponent<Monster>();
        
    }

    // ���°� ���� ���� ��
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
        
    }

    // ���¿��� ���� ��
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        GameObject game = Resources.Load<GameObject>("arrow");
        Instantiate(game, monster.transform.position, monster.transform.rotation);
        monster.atkDelay = monster.atkCooltime;       
    }
}
