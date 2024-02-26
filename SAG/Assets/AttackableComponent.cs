using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackableComponent : MonoBehaviour,IAttackabe
{
    public float atk;
    void IAttackabe.Attack(IHitable hitable)
    {
        hitable.Hit(atk);
    }

  
}
