using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class WeaponCollider : MonoBehaviour
{
    public  enum AttackState
    {
        Default,
        Rush,
    }

    private PlayerController playerController;
    private AttackState attackState = AttackState.Default;

    [Header("내가 공격중인 오브젝트")]
    public List<GameObject> HittedObjectList = new List<GameObject>();

    void Start()
    {
        playerController = this.transform.root.transform.GetComponent<PlayerController>();
    }

    void OnEnable()
    {
        if(HittedObjectList.Count>0)
        {
            HittedObjectList.Clear();
        }          
    }

    void OnDisable()
    {
        HittedObjectList.Clear();
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (!HittedObjectList.Contains(other.gameObject))
        {
            HittedObjectList.Add(other.gameObject);
        }
        else
        {
            return;
        }

        switch (attackState)
        {
            case AttackState.Default:
                playerController.DefaulAttack(other.gameObject);
                break;
            case AttackState.Rush:
                playerController.Rush(other.gameObject);
                break;
        }
    }
}
  
