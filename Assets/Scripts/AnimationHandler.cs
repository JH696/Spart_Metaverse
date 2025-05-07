using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationHandler : MonoBehaviour
{
    private static readonly int isMoving = Animator.StringToHash("IsMove");
    private static readonly int isHit = Animator.StringToHash("IsHit");

    protected Animator animator;

    protected virtual void Awake()
    {
        animator = GetComponentInChildren<Animator>();
    }

    public void Move(Vector2 obj)
    {
        animator.SetBool(isMoving, obj.magnitude > .5f);
    }
    public void Hit()
    {
        animator.SetBool(isHit, true);
    } 

    public void InvincibilityEnd()
    {
        animator.SetBool(isHit, false);
    }

}
