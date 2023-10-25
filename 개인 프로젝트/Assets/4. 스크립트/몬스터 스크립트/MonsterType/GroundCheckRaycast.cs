using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheckRaycast : MonoBehaviour
{
    private float maxDistance = 2f;
    private Animator animator;
    public bool isGround;

    private void Start()
    {
        animator = GetComponent<Animator>();
       
    }

    private void Update()
    {
        Vector3 rightVec = (transform.localScale.x == -1) ? -transform.right : transform.right;

        Vector3 targetVec = (transform.position + (rightVec - transform.up)) -transform.position;
        isGround = Physics2D.Raycast(transform.position, targetVec.normalized, maxDistance ,LayerMask.GetMask("Ground"));
        Debug.DrawRay(transform.position, targetVec.normalized * maxDistance, Color.red);

        if (!isGround)
        {
            animator.SetBool("IsBack", true);
        }
    }
}
    
