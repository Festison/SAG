using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class PlayerAnimationController : MonoBehaviour 
{
    public enum Type
    {
        Player,
    }

    [Header("적용할 애니메이션 타입")]
    public Type CharacterType = Type.Player;
    public PlayerController characterAnimation;

    void Start () 
    {
        switch (CharacterType)
        {
            case Type.Player:
                characterAnimation = this.transform.root.transform.GetComponent<PlayerController>();
                break; 
        }           
    }

    public void LifeStealAnimationEnter()
    {
        switch (CharacterType)
        {
            case Type.Player:
                characterAnimation.LifeStealEnter();
                break;
        }
    }

    public void RushAnimationEnter()
    { 
        switch (CharacterType)
        {
            case Type.Player:
                characterAnimation.RushEnter();
                break;
        }
    }

    public void RushAnimationExit()
    {
        switch (CharacterType)
        {
            case Type.Player:
                characterAnimation.RushExit();
                break;
        }
    }

    public void AuraBladeAnimaiontEnter()
    {
        switch (CharacterType)
        {
            case Type.Player:
                characterAnimation.AuraBladeEnter();
                break;
        }
    }

    public void DieAnimationEnter()
    {
        switch (CharacterType)
        {
            case Type.Player:
                characterAnimation.DieEnter();
                break;
        }
    }
}
